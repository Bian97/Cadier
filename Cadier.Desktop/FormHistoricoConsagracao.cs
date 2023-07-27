using Cadier.Model.Enums;
using Cadier.Model.Models;
using Cadier.Model.Utilitarios;
using Cadier.Desktop.Utilitarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadier.Desktop
{
    public partial class FormHistoricoConsagracao : Form
    {
        FormListaHistoricoConsagracao formHistoricoConsagracao;
        private readonly JsonParaClasse _jsonParaClasse;

        public FormHistoricoConsagracao(int idPFisica)
        {
            InitializeComponent();
            _jsonParaClasse = new JsonParaClasse();
            cmbCargo.DataSource = Enum.GetValues(typeof(CargosEnum));

            txtIdPFisica.Text = idPFisica.ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblIdConsagracao.Text = "Registro:";
            cmbCargo.SelectedIndex = 0;
            txtLocal.Text = "";
            txtIgreja.Text = "";
            dateTimeConsagracao.Value = DateTime.Now;
            txtNomeIndicou.Text = "";
            txtObs.Text = "";
        }

        private HistoricoConsagracao PegaFormulario()
        {
            return new HistoricoConsagracao() {
                IdConsagracao = !lblIdConsagracao.Text.Equals("Registro:") ? Convert.ToInt32(Regex.Match(lblIdConsagracao.Text, @"\d+").Value) : 0,
                PFisica = new PFisica() { IdPFisica = Convert.ToInt32(txtIdPFisica.Text) },
                Cargo = (CargosEnum) cmbCargo.SelectedIndex,
                Local = txtLocal.Text,
                Igreja = txtIgreja.Text,
                Data = dateTimeConsagracao.Value,
                NomeIndicou = txtNomeIndicou.Text,
                Obs = txtObs.Text
            };
        }

        private string EnviaHistoricoAsync(HistoricoConsagracao historico, TipoRequisicaoEnum requisicaoEnum)
        {
            Task<string> tarefa = Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(new { HistoricoConsagracao = new List<HistoricoConsagracao>() { historico } }, "HistoricoConsagracao", requisicaoEnum));
            MessageBoxes.MostraMensagens("Enviando dados de histórico!", "Aguarde!");

            return tarefa.Result;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            var historico = PegaFormulario();

            var resultado = EnviaHistoricoAsync(historico, TipoRequisicaoEnum.Inserir);
            if (Int32.TryParse(resultado.ToString(), out var idConsagracao))
            {
                MessageBoxes.MostraMensagens("Histórico guardado com sucesso!", "Sucesso!");

                lblIdConsagracao.Text += idConsagracao.ToString();
                btnInserir.Enabled = false;
                btnAlterar.Enabled = true;
                btnRemover.Enabled = true;
                btnLimpar.Enabled = true;
            }
            else
            {
                MessageBoxes.MostraMensagens("Erro ao guardar histórico!", "Erro!");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var historico = PegaFormulario();

            var resultado = EnviaHistoricoAsync(historico, TipoRequisicaoEnum.Alterar);
            if (Int32.TryParse(resultado.ToString(), out _))
            {
                MessageBoxes.MostraMensagens("Histórico alterado com sucesso!", "Sucesso!");
            } else
            {
                MessageBoxes.MostraMensagens("Erro ao salvar histórico!", "Erro!");
            }
        }

        private static dynamic TransformaJson(WebResponse valor)
        {
            if (((HttpWebResponse)valor).StatusCode == HttpStatusCode.NotFound)
            {
                MessageBoxes.MostraMensagens("Número do Rol não encontrado!", "Erro!");
                return null;
            }
            else
            {
                var serializer = new JsonSerializer();
                using (var response = new StreamReader(valor.GetResponseStream()))
                {
                    using (var jsonTextReader = new JsonTextReader(response))
                    {
                        return serializer.Deserialize<dynamic>(jsonTextReader);
                    }
                }
            }
        }

        private void btnListaServico_Click(object sender, EventArgs e)
        {
            if (formHistoricoConsagracao == null)
            {                
                var jsonHistoricos = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/Consagracao?Rol=" + txtIdPFisica.Text));

                if (jsonHistoricos != null && jsonHistoricos.Count > 0)
                {
                    var historicos = ((List<HistoricoConsagracao>)_jsonParaClasse.GetConsagracoes(jsonHistoricos));
                    formHistoricoConsagracao = new FormListaHistoricoConsagracao(historicos);
                    formHistoricoConsagracao.FormClosed += formHistoricoConsagracao_FormClosed;
                    formHistoricoConsagracao.Show(this);
                } else
                {
                    MessageBoxes.MostraMensagens("Não existe nenhuma consagração registrada dessa pessoa física!","Aviso!");
                }
            }            
        }

        private void formHistoricoConsagracao_FormClosed(object sender, FormClosedEventArgs e)
        {
            var historico = formHistoricoConsagracao.HistoricoEscolhido;
            formHistoricoConsagracao = null;
            Show();
            if (historico != null)
            {
                MostrarDados(historico);
            }
        }

        private void MostrarDados(HistoricoConsagracao historico)
        {
            lblIdConsagracao.Text = "Registro:" + historico.IdConsagracao;
            cmbCargo.SelectedIndex = (int) historico.Cargo;
            txtIdPFisica.Text = historico.PFisica.IdPFisica.ToString();
            txtLocal.Text = historico.Local;
            txtIgreja.Text = historico.Igreja;
            dateTimeConsagracao.Value = historico.Data.Value;
            txtNomeIndicou.Text = historico.NomeIndicou;
            txtObs.Text = historico.Obs;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var jsonHistorico = TransformaJson(RequisicaoMediador.RealizaRequisicaoDelete(@"http://127.0.0.1:8000/api/Consagracao/" + Regex.Match(lblIdConsagracao.Text, @"\d+").Value));
            if (jsonHistorico != null)
            {
                MessageBoxes.MostraMensagens("Histórico apagado com sucesso!", "Sucesso!");
            }
            else
            {
                MessageBoxes.MostraMensagens("Erro ao apagar histórico!", "Erro!");
            }
        }
    }
}