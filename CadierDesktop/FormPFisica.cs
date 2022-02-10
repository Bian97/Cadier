using CadierBiblioteca;
using CadierBiblioteca.Enums;
using CadierBiblioteca.ModelosAtuais;
using CadierBiblioteca.Utilitarios;
using CadierDesktop.Utilitarios;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
//using Microsoft.Office.Interop.Word;
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
using DocumentFormat.OpenXml;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace CadierDesktop
{
    public partial class FormPFisica : Form
    {
        private readonly JsonParaClasse _jsonParaClasse;
        private string arquivoEscolhido;
        private readonly List<Atendente> _atendentes;
        FormListaPFisica _formListaPFisica;

        public FormPFisica(PFisica pfisica = null)
        {
            InitializeComponent();
            cmbCargo.DataSource = Enum.GetValues(typeof(CargosEnum));
            cmbCondicao.DataSource = Enum.GetValues(typeof(CondicaoEnum));
            imgFiliado.Image = Properties.Resources.camera;
            _jsonParaClasse = new JsonParaClasse();

            var jsonAtendentes = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet("http://cadier.com.br/api/Atendente"));
            _atendentes = ((List<Atendente>)_jsonParaClasse.GetAtendentes(jsonAtendentes));
            cmbAtendente.DisplayMember = "Nome";
            cmbAtendente.ValueMember = "CodAtendente";
            cmbAtendente.DataSource = _atendentes;

            txtCEP.LostFocus += txtCEP_LostFocus;
            if (pfisica != null)
            {
                MostrarDados(pfisica);
                AtivarBotoes();
            }
            else
            {
                DesativarBotoes();
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

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtIdPFisica.Text.Length == 0)
            {
                MessageBoxes.MostraMensagens("Você precisa digitar um número do Rol.", "Erro!");
            }
            else
            {
                var jsonPFisica = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PFisica/" + txtIdPFisica.Text));
                if (jsonPFisica != null)
                {
                    PFisica pfisica = ((List<PFisica>)_jsonParaClasse.GetPFisicas(jsonPFisica)).First();
                    MostrarDados(pfisica);
                }
            }
        }

        private void MostrarDados(PFisica pfisica)
        {
            imgFiliado.Image = null;
            imgFiliado.Update();
            txtIdPFisica.Enabled = false;
            txtIdPFisica.Text = pfisica.IdPFisica.ToString();
            txtNome.Text = pfisica.Nome;
            txtProfissao.Text = pfisica.Profissao;
            txtEmail.Text = pfisica.Email;
            txtTelefone1.Text = pfisica.Telefone1;
            txtTelefone2.Text = pfisica.Telefone2;
            txtFiliacao.Text = pfisica.Filiacao;
            dateTimeNascimento.Value = pfisica.DataNascimento ?? DateTime.Now;
            if (pfisica.Sexo) { radioMasculino.Checked = true; } else { radioFeminino.Checked = true; }
            cmbCargo.SelectedIndex = (int)pfisica.Cargo;
            txtConjuge.Text = pfisica.Conjuge;
            if (pfisica.Info != null)
            {
                txtCPF.Text = pfisica.Info.Cpf;
                txtRG.Text = pfisica.Info.Rg;
            }
            if (pfisica.Endereco != null)
            {
                txtCEP.Text = pfisica.Endereco.Cep;
                txtRua.Text = pfisica.Endereco.Rua;
                txtBairro.Text = pfisica.Endereco.Bairro;
                txtCidade.Text = pfisica.Endereco.Cidade;
                txtEstado.Text = pfisica.Endereco.Estado;
                txtPais.Text = pfisica.Endereco.Pais;
                lblLatitude.Text = pfisica.Endereco.Latitude.ToString();
                lblLongitude.Text = pfisica.Endereco.Longitude.ToString();
            }
            if (pfisica.SituacaoCadastral != null)
            {
                txtObs.Text = pfisica.SituacaoCadastral.Obs;
                dateTimeEntrou.Value = pfisica.SituacaoCadastral.DataEntrou ?? DateTime.Now;
                dateTimeUltimaVisita.Value = pfisica.SituacaoCadastral.DataUltimaVisita ?? DateTime.Now;
                cmbCondicao.SelectedIndex = (int)pfisica.SituacaoCadastral.Condicao;
                cmbAtendente.SelectedValue = pfisica.SituacaoCadastral.Atendente.CodAtendente;
                if (pfisica.SituacaoCadastral.EFiliado) { radioEFiliado.Checked = true; } else { radioNaoFiliado.Checked = true; }
                lblDataAtualizado.Text = "Atualizado em: " + (pfisica.SituacaoCadastral.DataAtualizado != null ? pfisica.SituacaoCadastral.DataAtualizado.Value.ToString("dd/MM/yyyy") : "Sem Data!");
            }
            txtApresentou.Text = pfisica.ApresentouConv;
            if (pfisica.IdPJuridica != null)
            {
                lblIdPJuridica.Text = "Rol: " + pfisica.IdPJuridica.IdPJuridica;
                lblNomePJuridica.Text = "Nome: " + pfisica.IdPJuridica.Nome;
            }

            if (pfisica.Foto != null)
            {
                imgFiliado.LoadAsync(pfisica.Foto);
                imgFiliado.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            AtivarBotoes();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            imgFiliado.Image = null;
            txtIdPFisica.Enabled = true;
            txtIdPFisica.Text = "";
            txtNome.Text = "";
            txtProfissao.Text = "";
            txtEmail.Text = "";
            txtTelefone1.Text = "";
            txtTelefone2.Text = "";
            txtFiliacao.Text = "";
            dateTimeNascimento.Value = DateTime.Now;
            radioMasculino.Checked = false;
            radioFeminino.Checked = false;
            cmbCargo.SelectedIndex = 0;
            txtConjuge.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            txtCEP.Text = "";
            txtRua.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtPais.Text = "";
            txtObs.Text = "";
            dateTimeEntrou.Value = DateTime.Now;
            dateTimeUltimaVisita.Value = DateTime.Now;
            cmbCondicao.SelectedIndex = 0;
            cmbAtendente.SelectedValue = 1;
            radioEFiliado.Checked = false;
            radioNaoFiliado.Checked = false;
            lblDataAtualizado.Text = "Atualizado em:";
            txtApresentou.Text = "";
            lblIdPJuridica.Text = "Rol:";
            lblNomePJuridica.Text = "Nome:";
            imgFiliado.Image = Properties.Resources.camera;
            lblLatitude.Text = "";
            lblLongitude.Text = "";
            DesativarBotoes();
        }

        private void btnProcurarPJuridica_Click(object sender, EventArgs e)
        {
            var opcaoEscolhida = MessageBoxes.EscolherOpcao("Essa Igreja já foi cadastrada?", "Procurar PJurídica");
            if (opcaoEscolhida == DialogResult.Yes)
            {
                var listaPJuridica = new FormListaPJuridica(0, lblIdPJuridica, lblNomePJuridica);
                listaPJuridica.Show();
            }
            else if (opcaoEscolhida == DialogResult.No)
            {
                var txtNome = "";
                if (MessageBoxes.InputBox("Dados de PJurídica", "Nome", out txtNome) == DialogResult.OK)
                {

                    var pjuridica = new PJuridica() { Nome = txtNome, SituacaoCadastral = new SituacaoCadastral() { EFiliado = false, Condicao = CondicaoEnum.Inativo, Atendente = new Atendente() { CodAtendente = Convert.ToInt32(cmbAtendente.SelectedValue) } } };
                    var resultado = InserePJuridicaAsync(pjuridica);
                    if (Int32.TryParse(resultado.ToString(), out var idPJuridica))
                    {
                        MessageBoxes.MostraMensagens("Igreja cadastrada com sucesso!", "Sucesso!");
                        lblIdPJuridica.Text = "Rol: " + idPJuridica;
                        lblNomePJuridica.Text = "Nome: " + txtNome;
                    }
                    else
                    {
                        MessageBoxes.MostraMensagens("Erro ao guardar Igreja!", "Erro!");
                    }
                }
            }
        }

        private void txtCEP_LostFocus(object sender, System.EventArgs e)
        {
            //var endereco = new Endereco();
            /*GoogleMapsUtil mapsUtil = new GoogleMapsUtil();
            var endereco = mapsUtil.GoogleMapsEnderecoCep(txtCEP.Text);

            if (endereco == null)
            {
                MessageBoxes.MostraMensagens("AVISO: CEP não conhecido pelo Google Maps!", "Aviso!");
                lblLatitude.Text = "0";
                lblLongitude.Text = "0";
            }
            else
            {
                if (endereco.Rua != null && endereco.Rua != "")
                {
                    txtRua.Text = endereco.Rua;
                }
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Cidade;
                txtEstado.Text = endereco.Estado;
                txtPais.Text = endereco.Pais;
                lblLatitude.Text = endereco.Latitude.ToString();
                lblLongitude.Text = endereco.Longitude.ToString();
            }*/
            //if (endereco.Rua != null && endereco.Rua != "")
            //{
            //    txtRua.Text = endereco.Rua;
            //}
            //txtBairro.Text = endereco.Bairro;
            //txtCidade.Text = endereco.Cidade;
            //txtEstado.Text = endereco.Estado;
            //txtPais.Text = endereco.Pais;
            lblLatitude.Text = "0";
            lblLongitude.Text = "0";
        }

        private string InserePJuridicaAsync(PJuridica pjuridica)
        {
            Task<string> tarefa = System.Threading.Tasks.Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(new { PJuridicas = new List<PJuridica>() { pjuridica } }, "PJuridicas", TipoRequisicaoEnum.Inserir));
            MessageBoxes.MostraMensagens("Cadastrando igreja!", "Aguarde!");

            return tarefa.Result;
        }

        private string EnviaPFisicaAsync(PFisica pfisica, TipoRequisicaoEnum requisicaoEnum)
        {
            Task<string> tarefa = System.Threading.Tasks.Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(new { PFisicas = new List<PFisica>() { pfisica } }, "PFisicas", requisicaoEnum));
            MessageBoxes.MostraMensagens("Enviando dados de pessoa física!", "Aguarde!");

            return tarefa.Result;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                var pfisica = PegaFormulario();
                var resultado = EnviaPFisicaAsync(pfisica, TipoRequisicaoEnum.Inserir);
                if (Int32.TryParse(resultado.ToString(), out var idPFisica))
                {
                    if (pfisica.SituacaoCadastral.EFiliado)
                    {
                        MessageBoxes.MostraMensagens("Pessoa física filiada com sucesso!", "Sucesso!");                        
                    }
                    else
                    {
                        MessageBoxes.MostraMensagens("Pessoa física cadastrada com sucesso!", "Sucesso!");
                    }
                    txtIdPFisica.Text = idPFisica.ToString();
                    AtivarBotoes();
                }
                else
                {
                    MessageBoxes.MostraMensagens("Erro ao guardar pessoa física!", "Erro!");
                }
            }
        }

        private void imgFiliado_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.png)|*.png|(*.jpg)|*.jpg|(*.JPEG)|*.JPEG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream st = openFileDialog.OpenFile())
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        imgFiliado.Image = Image.FromStream(fs);
                        imgFiliado.SizeMode = PictureBoxSizeMode.StretchImage;
                        arquivoEscolhido = openFileDialog.FileName;
                        fs.Dispose();
                    }
                }
            }
        }

        private PFisica PegaFormulario()
        {
            lblDataAtualizado.Text = "Atualizado em: " + DateTime.Now.ToString("dd/MM/yyyy");

            return new PFisica()
            {
                IdPFisica = txtIdPFisica.Text != "" ? Convert.ToInt32(txtIdPFisica.Text) : 0,
                Nome = txtNome.Text,
                Profissao = txtProfissao.Text,
                Email = txtEmail.Text,
                Telefone1 = Regex.Match(txtTelefone1.Text, @"\d+").Value != "" ? txtTelefone1.Text : "",
                Telefone2 = Regex.Match(txtTelefone2.Text, @"\d+").Value != "" ? txtTelefone2.Text : "",
                Filiacao = txtFiliacao.Text,
                DataNascimento = dateTimeNascimento.Value,
                Sexo = radioMasculino.Checked ? true : false,
                Cargo = (CargosEnum)cmbCargo.SelectedIndex,
                Conjuge = txtConjuge.Text,
                Info = Regex.Match(txtCPF.Text, @"\d+").Value != "" || txtRG.Text != "" ? new Infos() { Cpf = txtCPF.Text, Rg = txtRG.Text } : null,
                Endereco = Regex.Match(txtCEP.Text, @"\d+").Value != "" && txtRua.Text != "" ? new Endereco()
                {
                    Cep = txtCEP.Text,
                    Rua = txtRua.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstado.Text,
                    Pais = txtPais.Text,
                    Latitude = Convert.ToDouble(lblLatitude.Text),
                    Longitude = Convert.ToDouble(lblLongitude.Text)
                } : null,
                SituacaoCadastral = new SituacaoCadastral()
                {
                    Obs = txtObs.Text,
                    DataEntrou = dateTimeEntrou.Value,
                    DataUltimaVisita = dateTimeUltimaVisita.Value,
                    Condicao = (CondicaoEnum)cmbCondicao.SelectedIndex,
                    Atendente = new Atendente() { CodAtendente = Convert.ToInt32(cmbAtendente.SelectedValue) },
                    EFiliado = radioEFiliado.Checked ? true : false,
                    DataAtualizado = DateTime.Now
                },
                ApresentouConv = txtApresentou.Text,
                IdPJuridica = lblIdPJuridica.Text != "Rol:" ? new PJuridica() { IdPJuridica = Convert.ToInt32(new String(lblIdPJuridica.Text.Where(Char.IsDigit).ToArray())) } : null,
                Foto = arquivoEscolhido
            };
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                var pfisica = PegaFormulario();

                var resultado = EnviaPFisicaAsync(pfisica, TipoRequisicaoEnum.Alterar);
                if (Int32.TryParse(resultado.ToString(), out _))
                {
                    MessageBoxes.MostraMensagens("Pessoa física alterada com sucesso!", "Sucesso!");
                }
                else
                {
                    MessageBoxes.MostraMensagens("Erro ao alterar pessoa física!", "Erro!");
                }
            }
        }

        private void btnServico_Click(object sender, EventArgs e)
        {
            Form form = new FormOrdemServico(_atendentes, Convert.ToInt32(txtIdPFisica.Text), 0);
            form.Show();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (_formListaPFisica == null)
            {
                _formListaPFisica = new FormListaPFisica();
                _formListaPFisica.FormClosed += formListaPFisica_FormClosed;
            }

            _formListaPFisica.Show(this);
        }

        void formListaPFisica_FormClosed(object sender, FormClosedEventArgs e)
        {
            var pFisicas = _formListaPFisica.PFisicaEscolhida;
            _formListaPFisica = null;
            Show();
            if (pFisicas != null)
            {
                MostrarDados(pFisicas);
            }
        }

        private void btnConsagracoes_Click(object sender, EventArgs e)
        {
            FormHistoricoConsagracao formLista = new FormHistoricoConsagracao(Convert.ToInt32(txtIdPFisica.Text));
            formLista.Show();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            FormHistoricoCursos formLista = new FormHistoricoCursos(Convert.ToInt32(txtIdPFisica.Text));
            formLista.Show();
        }

        private void btnPVC_Click(object sender, EventArgs e)
        {
            if (MessageBoxes.InputBox("Escolha o PVC", "Qual PVC será gerado? 1-Verde | 2-Cinza", out var opcao) == DialogResult.OK)
            {
                var pfisica = PegaFormulario();
                WordUtil wordUtil = new WordUtil();

                if (Convert.ToInt32(opcao) == 1)
                {
                    wordUtil.GerarPVC(new List<PFisica>() { pfisica }, TipoPVCEnum.Verde, imgFiliado.Image);
                } else
                {
                    wordUtil.GerarPVC(new List<PFisica>() { pfisica }, TipoPVCEnum.Cinza, imgFiliado.Image);
                }

                MessageBoxes.MostraMensagens("PVC gerado com sucesso", "Sucesso!");
            }
        }

        private void AtivarBotoes()
        {
            btnInserir.Enabled = false;
            btnAlterar.Enabled = true;
            btnServico.Enabled = true;
            btnConsagracoes.Enabled = true;
            btnCursos.Enabled = true;
            btnPVC.Enabled = true;
            btnCertificado.Enabled = true;
        }

        private void DesativarBotoes()
        {
            btnInserir.Enabled = true;
            btnAlterar.Enabled = false;
            btnServico.Enabled = false;
            btnConsagracoes.Enabled = false;
            btnCursos.Enabled = false;
            btnPVC.Enabled = false;
            btnCertificado.Enabled = false;
        }

        private bool Validacao()
        {
            if(!radioEFiliado.Checked && !radioNaoFiliado.Checked)
            {
                MessageBoxes.MostraMensagens("Deve ser definido se a pessoa física é filiada ou não!", "Erro!");
                return false;
            }
            if(!radioMasculino.Checked && !radioFeminino.Checked)
            {
                MessageBoxes.MostraMensagens("Deve ser definido se a pessoa física é masculino ou feminino!", "Erro!");
                return false;
            }
            return true;
        }

        private void btnCertificado_Click(object sender, EventArgs e)
        {
            var pfisica = PegaFormulario();
            WordUtil wordUtil = new WordUtil();

            wordUtil.GerarCertificado(new List<PFisica>() { pfisica }, DateTime.Now);
            MessageBoxes.MostraMensagens("Certificado gerado com sucesso", "Sucesso!");
        }

        private void btnRemoverIgreja_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Regex.Match(lblIdPJuridica.Text, @"\d+").Value) != 0)
            {
                lblIdPJuridica.Text = "Rol:";
                lblNomePJuridica.Text = "Nome:";
            } else
            {
                lblIdPJuridica.Text = "Rol:" + 1;
                lblNomePJuridica.Text = "Nome:";
            }
        }
    }
}