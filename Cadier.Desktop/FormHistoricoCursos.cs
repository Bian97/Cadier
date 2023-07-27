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
    public partial class FormHistoricoCursos : Form
    {
        FormListaHistoricoCursos formHistoricoCursos;
        private readonly JsonParaClasse _jsonParaClasse;

        public FormHistoricoCursos(int idPFisica)
        {
            InitializeComponent();
            _jsonParaClasse = new JsonParaClasse();

            txtIdPFisica.Text = idPFisica.ToString();
            btnInserir.Enabled = true;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblIdCurso.Text = "Registro:";
            txtCurso.Text = "";
            txtRestaPagar.Text = "";
            txtPeriodo.Text = "";
            dateTimePagamento.Value = DateTime.Now;
            lblLevou.Enabled = false;
            checkLevou.Checked = false;
            dateTimeLevou.Value = DateTime.Now;
            dateTimeLevou.Enabled = false;
            checkFormou.Checked = false;
            lblFormatura.Enabled = false;
            dateTimeFormatura.Enabled = false;
            dateTimeFormatura.Value = DateTime.Now;
            txtObs.Text = "";

            btnInserir.Enabled = true;
            btnAlterar.Enabled = false;
            btnRemover.Enabled = false;
        }

        private static decimal TextoParaDecimal(string texto)
        {
            return texto != "" ? Convert.ToDecimal(texto.Replace(".", ",")) : 0;
        }

        private HistoricoCursos PegaFormulario()
        {
            DateTime? dataLevou;
            DateTime? dataFormatura;
            if (checkLevou.Checked)
            {
                dataLevou = dateTimeLevou.Value;
            }
            else
            {
                dataLevou = null;
            }

            if (checkFormou.Checked)
            {
                dataFormatura = dateTimeFormatura.Value;
            }
            else
            {
                dataFormatura = null;
            }

            return new HistoricoCursos() { 
                IdCurso = !lblIdCurso.Text.Equals("Registro:") ? Convert.ToInt32(Regex.Match(lblIdCurso.Text, @"\d+").Value) : 0,
                PFisica = new PFisica() { IdPFisica = Convert.ToInt32(txtIdPFisica.Text) },
                Periodo = txtPeriodo.Text,
                Curso = txtCurso.Text,
                RestaPagar = TextoParaDecimal(txtRestaPagar.Text),
                DataUltimPagam = dateTimePagamento.Value,
                DataLevouCert = dataLevou,
                DataFormatura = dataFormatura,
                Obs = txtObs.Text
            };
        }

        private string EnviaHistoricoAsync(HistoricoCursos historico, TipoRequisicaoEnum requisicaoEnum)
        {
            Task<string> tarefa = Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(new { HistoricoCurso = new List<HistoricoCursos>() { historico } }, "HistoricoCurso", requisicaoEnum));
            MessageBoxes.MostraMensagens("Enviando dados de histórico!", "Aguarde!");

            return tarefa.Result;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            var historico = PegaFormulario();

            var resultado = EnviaHistoricoAsync(historico, TipoRequisicaoEnum.Inserir);
            if (Int32.TryParse(resultado.ToString(), out var idCurso))
            {
                MessageBoxes.MostraMensagens("Histórico guardado com sucesso!", "Sucesso!");

                lblIdCurso.Text += idCurso.ToString();
                btnInserir.Enabled = false;
                btnAlterar.Enabled = true;
                btnRemover.Enabled = true;
            }
            else
            {
                MessageBoxes.MostraMensagens("Erro ao guardar histórico!", "Erro!");
            }
        }

        private dynamic TransformaJson(WebResponse valor)
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var historico = PegaFormulario();

            var resultado = EnviaHistoricoAsync(historico, TipoRequisicaoEnum.Alterar);
            if (Int32.TryParse(resultado.ToString(), out _))
            {
                MessageBoxes.MostraMensagens("Histórico alterado com sucesso!", "Sucesso!");
            }
            else
            {
                MessageBoxes.MostraMensagens("Erro ao alterar histórico!", "Erro!");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var jsonHistorico = TransformaJson(RequisicaoMediador.RealizaRequisicaoDelete(@"http://127.0.0.1:8000/api/Curso/" + Regex.Match(lblIdCurso.Text, @"\d+").Value));
            if (jsonHistorico != null)
            {
                MessageBoxes.MostraMensagens("Histórico apagado com sucesso!", "Sucesso!");
                btnInserir.Enabled = true;
                btnAlterar.Enabled = false;
                btnRemover.Enabled = false;
            } else
            {
                MessageBoxes.MostraMensagens("Erro ao apagar histórico!", "Erro!");
            }
        }

        private void btnListaServico_Click(object sender, EventArgs e)
        {
            if (formHistoricoCursos == null)
            {
                var jsonHistoricos = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/Curso?Rol=" + txtIdPFisica.Text));

                if (jsonHistoricos != null && jsonHistoricos.Count > 0)
                {
                    var historicos = ((List<HistoricoCursos>)_jsonParaClasse.GetCursos(jsonHistoricos));
                    formHistoricoCursos = new FormListaHistoricoCursos(historicos);
                    formHistoricoCursos.FormClosed += formHistoricoCursos_FormClosed;
                    formHistoricoCursos.Show(this);
                }
                else
                {
                    MessageBoxes.MostraMensagens("Não existe nenhum curso registrado dessa pessoa física!", "Aviso!");
                }
            }            
        }

        void formHistoricoCursos_FormClosed(object sender, FormClosedEventArgs e)
        {
            var historico = formHistoricoCursos.HistoricoEscolhido;
            formHistoricoCursos = null;
            Show();
            if (historico != null)
            {
                MostrarDados(historico);
            }
        }

        private void MostrarDados(HistoricoCursos historico)
        {
            lblIdCurso.Text = "Registro:" + historico.IdCurso;
            txtCurso.Text = historico.Curso;
            txtRestaPagar.Text = historico.RestaPagar.ToString();
            txtPeriodo.Text = historico.Periodo;
            if (historico.DataUltimPagam != null) dateTimePagamento.Value = historico.DataUltimPagam.Value;

            if (historico.DataLevouCert != null && historico.DataLevouCert.Value.Year < 2000)
            {
                lblLevou.Enabled = false;
                checkLevou.Checked = false;
                dateTimeLevou.Value = DateTime.Now;
                dateTimeLevou.Enabled = false;
            } else
            {
                lblLevou.Enabled = true;
                checkLevou.Checked = true;
                if (historico.DataLevouCert != null) dateTimeLevou.Value = historico.DataLevouCert.Value;
                dateTimeLevou.Enabled = true;
            }

            if (historico.DataFormatura != null && historico.DataFormatura.Value.Year < 2000)
            {
                checkFormou.Checked = false;
                lblFormatura.Enabled = false;
                dateTimeFormatura.Enabled = false;
                dateTimeFormatura.Value = DateTime.Now;
            } else
            {
                checkFormou.Checked = true;
                lblFormatura.Enabled = true;
                dateTimeFormatura.Enabled = true;
                if (historico.DataFormatura != null) dateTimeFormatura.Value = historico.DataFormatura.Value;
            }
            txtObs.Text = historico.Obs;

            btnInserir.Enabled = false;
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
        }

        private void checkLevou_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLevou.Checked)
            {
                lblLevou.Enabled = true;
                dateTimeLevou.Enabled = true;
            }
            else
            {
                lblLevou.Enabled = false;
                dateTimeLevou.Enabled = false;
            }
        }

        private void checkFormou_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFormou.Checked)
            {
                lblFormatura.Enabled = true;
                dateTimeFormatura.Enabled = true;
            }
            else
            {
                lblFormatura.Enabled = false;
                dateTimeFormatura.Enabled = false;
            }
        }
    }
}
