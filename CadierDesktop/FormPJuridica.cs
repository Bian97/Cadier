using CadierBiblioteca;
using CadierBiblioteca.Enums;
using CadierBiblioteca.ModelosAtuais;
using CadierBiblioteca.Utilitarios;
using CadierDesktop.Utilitarios;
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

namespace CadierDesktop
{
    public partial class FormPJuridica : Form
    {
        private readonly JsonParaClasse _jsonParaClasse;
        private readonly List<Atendente> _atendentes;
        FormListaPFisica _formListaPFisica;
        FormListaPJuridica _formListaPJuridica;
        int tipo;

        public FormPJuridica(PJuridica pJuridica = null)
        {
            InitializeComponent();
            cmbCondicao.DataSource = Enum.GetValues(typeof(CondicaoEnum));

            _jsonParaClasse = new JsonParaClasse();

            var jsonAtendentes = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/Atendente"));
            _atendentes = ((List<Atendente>)_jsonParaClasse.GetAtendentes(jsonAtendentes));
            cmbAtendente.DisplayMember = "Nome";
            cmbAtendente.ValueMember = "CodAtendente";
            cmbAtendente.DataSource = _atendentes;
            checkFundacao.Checked = true;

            txtCEP.LostFocus += txtCEP_LostFocus;
            txtCEPVice.LostFocus += txtCEPVice_LostFocus;

            DesativaBotoes();
            DesativaBotõesVice();
        }
        private void txtCEP_LostFocus(object sender, System.EventArgs e)
        {
            /*GoogleMapsUtil mapsUtil = new GoogleMapsUtil();
            var endereco = mapsUtil.GoogleMapsEnderecoCep(txtCEP.Text);

            if (endereco == null)
            {
                MessageBoxes.MostraMensagens("AVISO: CEP não conhecido pelo Google Maps!", "Aviso!");
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
            var endereco = new Endereco();
            if (endereco.Rua != null && endereco.Rua != "")
            {
                txtRua.Text = endereco.Rua;
            }
            txtBairro.Text = endereco.Bairro;
            txtCidade.Text = endereco.Cidade;
            txtEstado.Text = endereco.Estado;
            txtPais.Text = endereco.Pais;
            lblLatitude.Text = "0";
            lblLongitude.Text = "0";
        }

        private void txtCEPVice_LostFocus(object sender, System.EventArgs e)
        {
            //var endereco = new Endereco();
            /*GoogleMapsUtil mapsUtil = new GoogleMapsUtil();
            var endereco = mapsUtil.GoogleMapsEnderecoCep(txtCEPVice.Text);

            if (endereco == null)
            {
                MessageBoxes.MostraMensagens("AVISO: CEP não conhecido pelo Google Maps!", "Aviso!");
            }
            else
            {
                if (endereco.Rua != null && endereco.Rua != "")
                {
                    txtRuaVice.Text = endereco.Rua;
                }                
                txtBairroVice.Text = endereco.Bairro;
                txtCidadeVice.Text = endereco.Cidade;
                lblLatitudeVice.Text = endereco.Latitude.ToString();
                lblLongitudeVice.Text = endereco.Longitude.ToString();
            }*/
            //if (endereco.Rua != null && endereco.Rua != "")
            //{
            //    txtRuaVice.Text = endereco.Rua;
            //}
            //txtBairroVice.Text = endereco.Bairro;
            //txtCidadeVice.Text = endereco.Cidade;
            lblLatitudeVice.Text = "0";
            lblLongitudeVice.Text = "0";
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

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtIdPJuridica.Text.Length == 0)
            {
                MessageBoxes.MostraMensagens("Você precisa digitar um número do Rol.", "Erro!");
            }
            else
            {
                var jsonPJuridica = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PJuridica/" + txtIdPJuridica.Text));
                if (jsonPJuridica == null) return;
                PJuridica pJuridica = ((List<PJuridica>)_jsonParaClasse.GetPJuridicas(jsonPJuridica)).First();
                if (pJuridica.PFisicaVice != null)
                {
                    MostrarDados(pJuridica, ProcurarPFisica(pJuridica.PFisicaVice.IdPFisica));
                }
                else
                {
                    MostrarDados(pJuridica);
                }
            }
        }

        private PFisica ProcurarPFisica(int idPFisica)
        {
            var jsonPFisica = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PFisica/" + idPFisica));
            if (jsonPFisica == null) return null;
            PFisica pfisica = ((List<PFisica>)_jsonParaClasse.GetPFisicas(jsonPFisica)).First();
            return pfisica;
        }

        private void LimparCampos()
        {
            txtIdPJuridica.Text = "";
            txtNome.Text = "";
            dateTimeFundacao.Value = DateTime.Now;
            txtCNPJ.Text = "";
            txtCEP.Text = "";
            txtRua.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtPais.Text = "";
            lblIdPFisicaPresidente.Text = "Rol:";
            lblNomePresidente.Text = "Nome:";
            lblTelefonePresidente.Text = "Telefone:";
            txtIdPFisicaVice.Text = "";
            txtNomeVice.Text = "";
            txtCPFVice.Text = "";
            txtTelefoneVice.Text = "";
            txtRGVice.Text = "";
            txtCEPVice.Text = "";
            txtRuaVice.Text = "";
            txtBairroVice.Text = "";
            txtCidadeVice.Text = "";
            radioEFiliadoVice.Checked = false;
            radioNaoFiliadoVice.Checked = true;
            radioEFiliado.Checked = false;
            radioNaoFiliado.Checked = true;
            lblDataAtualizado.Text = "Atualizado em:";
            txtEmail.Text = "";
            txtObs.Text = "";
            lblLatitude.Text = "";
            lblLongitude.Text = "";
            lblLatitudeVice.Text = "";
            lblLongitudeVice.Text = "";
            checkFundacao.Checked = true;
            DesativaBotoes();
            DesativaBotõesVice();
        }

        private void MostrarDados(PJuridica pJuridica, PFisica pFisicaVice = null)
        {
            txtIdPJuridica.Text = pJuridica.IdPJuridica.ToString();
            txtNome.Text = pJuridica.Nome;
            if (pJuridica.DataFundacao != null)
            {
                dateTimeFundacao.Value = pJuridica.DataFundacao.Value;
                checkFundacao.Checked = true;
            } else
            {
                checkFundacao.Checked = false;
            }
            txtCNPJ.Text = pJuridica.Info?.Cnpj;
            if (pJuridica.Endereco != null)
            {
                txtCEP.Text = pJuridica.Endereco.Cep;
                txtRua.Text = pJuridica.Endereco.Rua;
                txtBairro.Text = pJuridica.Endereco.Bairro;
                txtCidade.Text = pJuridica.Endereco.Cidade;
                txtEstado.Text = pJuridica.Endereco.Estado;
                txtPais.Text = pJuridica.Endereco.Pais;
                lblLongitude.Text = pJuridica.Endereco.Longitude.ToString();
                lblLatitude.Text = pJuridica.Endereco.Latitude.ToString();
            }
            if (pJuridica.PFisicaPresidente != null)
            {
                lblIdPFisicaPresidente.Text = "Rol:" + pJuridica.PFisicaPresidente.IdPFisica.ToString();
                lblNomePresidente.Text = "Nome:" + pJuridica.PFisicaPresidente.Nome;
                lblTelefonePresidente.Text = "Telefone:" + pJuridica.PFisicaPresidente.Telefone1;
            }
            if (pFisicaVice != null)
            {
                txtIdPFisicaVice.Text = pFisicaVice.IdPFisica.ToString();
                txtNomeVice.Text = pFisicaVice.Nome;
                txtCPFVice.Text = pFisicaVice.Info?.Cpf;
                txtTelefoneVice.Text = pFisicaVice.Telefone1;
                txtRGVice.Text = pFisicaVice.Info?.Rg;
                if (pFisicaVice.Endereco != null)
                {
                    txtCEPVice.Text = pFisicaVice.Endereco.Cep;
                    txtRuaVice.Text = pFisicaVice.Endereco.Rua;
                    txtBairroVice.Text = pFisicaVice.Endereco.Bairro;
                    txtCidadeVice.Text = pFisicaVice.Endereco.Cidade;
                    lblLatitudeVice.Text = pFisicaVice.Endereco.Latitude.ToString();
                    lblLongitudeVice.Text = pFisicaVice.Endereco.Longitude.ToString();
                }
                if (pFisicaVice.SituacaoCadastral.EFiliado)
                {
                    radioEFiliadoVice.Checked = true;
                }
                else
                {
                    radioNaoFiliadoVice.Checked = true;
                }
            }
            if (pJuridica.SituacaoCadastral.EFiliado)
            {
                radioEFiliado.Checked = true;
            }
            else
            {
                radioNaoFiliado.Checked = true;
            }
            lblDataAtualizado.Text = "Atualizado em: " + (pJuridica.SituacaoCadastral.DataAtualizado != null ? pJuridica.SituacaoCadastral.DataAtualizado.Value.ToString("dd/MM/yyyy") : "");
            txtEmail.Text = pJuridica.Email;
            txtObs.Text = pJuridica.SituacaoCadastral.Obs;
            cmbAtendente.SelectedItem = pJuridica.SituacaoCadastral.Atendente.CodAtendente;
            cmbCondicao.SelectedIndex = (int) pJuridica.SituacaoCadastral.Condicao;
            dateTimeEntrou.Value = pJuridica.SituacaoCadastral.DataEntrou != null ? pJuridica.SituacaoCadastral.DataEntrou.Value : DateTime.Now;
            dateTimeUltimaVisita.Value = pJuridica.SituacaoCadastral.DataUltimaVisita != null ? pJuridica.SituacaoCadastral.DataUltimaVisita.Value : DateTime.Now;

            AtivaBotoes();
            if (pFisicaVice != null)
            {
                AtivaBotõesVice();
            } else
            {
                DesativaBotõesVice();
            }
        }

        private PJuridica PegaFormulario()
        {
            lblDataAtualizado.Text = "Atualizado em:" + DateTime.Now.ToString("dd/MM/yyyy");
            return new PJuridica() {
                IdPJuridica = txtIdPJuridica.Text != "" ? Convert.ToInt32(txtIdPJuridica.Text) : 0,
                Nome = txtNome.Text,
                DataFundacao = dateTimeFundacao.Value,
                Email = txtEmail.Text,                
                Endereco = Regex.Match(txtCEP.Text, @"\d+").Value != "" && txtRua.Text != "" ? new Endereco() {
                    Cep = Regex.Match(txtCEP.Text, @"\d+").Value != "" ? txtCEP.Text : null,
                    Rua = txtRua.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    Estado = txtEstado.Text,
                    Pais = txtPais.Text,
                    Latitude = Convert.ToDouble(lblLatitude.Text),
                    Longitude = Convert.ToDouble(lblLongitude.Text)
                } : null,
                Info = Regex.Match(txtCNPJ.Text, @"\d+").Value != "" ? new Infos() { Cnpj = txtCNPJ.Text } : null,
                PFisicaPresidente = new PFisica() { IdPFisica = Convert.ToInt32(Regex.Match(lblIdPFisicaPresidente.Text, @"\d+").Value) },
                PFisicaVice = txtIdPFisicaVice.Text != "" ? new PFisica()
                {
                    IdPFisica = Convert.ToInt32(txtIdPFisicaVice.Text)
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
                }
            };
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnProcurarPresidente_Click(object sender, EventArgs e)
        {
            tipo = 0;
            if (_formListaPFisica == null)
            {
                _formListaPFisica = new FormListaPFisica();
                _formListaPFisica.FormClosed += formListaPFisica_FormClosed;
            }

            _formListaPFisica.Show(this);
        }

        private void formListaPFisica_FormClosed(object sender, FormClosedEventArgs e)
        {
            var pFisicas = _formListaPFisica.PFisicaEscolhida;
            _formListaPFisica = null;
            Show();
            if (tipo == 0)
            { 
                MostrarDadosPresidente(pFisicas);                
            } else
            {
                MostrarDadosVicePresidente(pFisicas);
                AtivaBotõesVice();
                AtivaBotoes();
            }
        }

        private void MostrarDadosPresidente(PFisica pFisicas)
        {
            lblIdPFisicaPresidente.Text = "Rol:" + pFisicas.IdPFisica.ToString();
            lblNomePresidente.Text = "Nome:" + pFisicas.Nome;
            lblTelefonePresidente.Text = "Telefone:" + pFisicas.Telefone1;
        }

        private void MostrarDadosVicePresidente(PFisica pFisicas)
        {
            txtIdPFisicaVice.Text = pFisicas.IdPFisica.ToString();
            txtNomeVice.Text = pFisicas.Nome;
            txtCPFVice.Text = pFisicas.Info?.Cpf;
            txtTelefoneVice.Text = pFisicas.Telefone1;
            txtRGVice.Text = pFisicas.Info?.Rg;
            if (pFisicas.Endereco != null)
            {
                txtCEPVice.Text = pFisicas.Endereco.Cep;
                txtRuaVice.Text = pFisicas.Endereco.Rua;
                txtBairroVice.Text = pFisicas.Endereco.Bairro;
                txtCidadeVice.Text = pFisicas.Endereco.Cidade;
            }
            if (pFisicas.SituacaoCadastral.EFiliado)
            {
                radioEFiliadoVice.Checked = true;
            }
            else
            {
                radioNaoFiliadoVice.Checked = true;
            }
        }

        private void btnProcurarVice_Click(object sender, EventArgs e)
        {
            tipo = 1;
            if (_formListaPFisica == null)
            {
                _formListaPFisica = new FormListaPFisica();
                _formListaPFisica.FormClosed += formListaPFisica_FormClosed;
            }

            _formListaPFisica.Show(this);
        }

        private void btnInserirVice_Click(object sender, EventArgs e)
        {
            var pfisicaVice = new PFisica() {
                Nome = txtNomeVice.Text,
                Telefone1 = Regex.Match(txtTelefoneVice.Text, @"\d+").Value != "" ? txtTelefoneVice.Text : null,
                DataNascimento = null,
                Info = txtRGVice.Text != "" || Regex.Match(txtCPFVice.Text, @"\d+").Value != "" ? new Infos() { Cpf = txtCPFVice.Text, Rg = txtRGVice.Text} : null,
                Endereco = Regex.Match(txtCEPVice.Text, @"\d+").Value != "" ? new Endereco() { Cep = txtCEPVice.Text, Rua = txtRuaVice.Text, Bairro = txtBairroVice.Text, Cidade = txtCidadeVice.Text, Latitude = Convert.ToDouble(lblLatitudeVice.Text), Longitude = Convert.ToDouble(lblLongitudeVice.Text) } : null,
                SituacaoCadastral = new SituacaoCadastral() { EFiliado = radioEFiliadoVice.Checked ? true : false, Atendente = new Atendente() { CodAtendente = Convert.ToInt32(cmbAtendente.SelectedValue) }, Condicao = (CondicaoEnum)cmbCondicao.SelectedIndex, DataAtualizado = DateTime.Now }
            };

            var resultado = EnviaPFisicaAsync(pfisicaVice, TipoRequisicaoEnum.Inserir);
            if (Int32.TryParse(resultado.ToString(), out var idPFisica))
            {
                if (pfisicaVice.SituacaoCadastral.EFiliado)
                {
                    MessageBoxes.MostraMensagens("Pessoa física filiada com sucesso!", "Sucesso!");
                    AtivaBotõesVice();
                }
                else
                {
                    MessageBoxes.MostraMensagens("Pessoa física cadastrada com sucesso!", "Sucesso!");
                }
                txtIdPFisicaVice.Text = idPFisica.ToString();                
            }
            else
            {
                MessageBoxes.MostraMensagens("Erro ao guardar pessoa física!", "Erro!");
            }
        }

        private static string EnviaPFisicaAsync(PFisica pfisica, TipoRequisicaoEnum requisicaoEnum)
        {
            Task<string> tarefa = Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(new { PFisicas = new List<PFisica>() { pfisica } }, "PFisicas", requisicaoEnum));
            MessageBoxes.MostraMensagens("Enviando dados de pessoa física!", "Aguarde!");

            return tarefa.Result;
        }

        private void btnAlterarVice_Click(object sender, EventArgs e)
        {
            var pfisicaVice = new PFisica()
            {
                IdPFisica = Convert.ToInt32(txtIdPFisicaVice.Text),
                Nome = txtNomeVice.Text,
                Telefone1 = txtTelefoneVice.Text,
                Info = txtRGVice.Text != "" || Regex.Match(txtCPFVice.Text, @"\d+").Value != "" ? new Infos() { Cpf = txtCPFVice.Text, Rg = txtRGVice.Text } : null,
                Endereco = Regex.Match(txtCEPVice.Text, @"\d+").Value != "" ? new Endereco() { Cep = txtCEPVice.Text, Rua = txtRuaVice.Text, Bairro = txtBairroVice.Text, Cidade = txtCidadeVice.Text } : null,
                SituacaoCadastral = new SituacaoCadastral() { EFiliado = radioEFiliadoVice.Checked ? true : false, Atendente = new Atendente() { CodAtendente = Convert.ToInt32(cmbAtendente.SelectedValue) }, Condicao = (CondicaoEnum)cmbCondicao.SelectedIndex, DataAtualizado = DateTime.Now }
            };

            var resultado = EnviaPFisicaAsync(pfisicaVice, TipoRequisicaoEnum.Alterar);
            if (Int32.TryParse(resultado.ToString(), out _))
            {
                MessageBoxes.MostraMensagens("Pessoa física alterada com sucesso!", "Sucesso!");
            }
            else
            {
                MessageBoxes.MostraMensagens("Erro ao alterar pessoa física!", "Erro!");
            }
        }

        private void btnApagarVice_Click(object sender, EventArgs e)
        {
            if (radioNaoFiliadoVice.Checked)
            {
                var jsonPFisica = TransformaJson(RequisicaoMediador.RealizaRequisicaoDelete(@"http://127.0.0.1:8000/api/PFisica/" + txtIdPFisicaVice.Text));
                if (jsonPFisica != null)
                {
                    MessageBoxes.MostraMensagens("Vice apagado com sucesso!", "Sucesso!");
                }
                else
                {
                    MessageBoxes.MostraMensagens("Erro ao apagar vice!", "Erro!");
                }
            }

            txtIdPFisicaVice.Text = "";
            txtNomeVice.Text = "";
            txtTelefoneVice.Text = "";
            txtRGVice.Text = "";
            txtCPFVice.Text = "";
            txtCEPVice.Text = "";
            txtRuaVice.Text = "";
            txtBairroVice.Text = "";
            txtCidadeVice.Text = "";
            radioEFiliadoVice.Checked = false;
            cmbAtendente.SelectedValue = 1;
            cmbCondicao.SelectedIndex = 1;
            DesativaBotõesVice();
        }

        private void AtivaBotõesVice()
        {
            btnInserirVice.Enabled = false;
            btnAlterarVice.Enabled = true;
            btnApagarVice.Enabled = true;
            btnProcurarVice.Enabled = false;
        }

        private void DesativaBotõesVice()
        {
            btnInserirVice.Enabled = true;
            btnAlterarVice.Enabled = false;
            btnApagarVice.Enabled = false;
            btnProcurarVice.Enabled = true;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                var pjuridica = PegaFormulario();
                var resultado = EnviaPJuridicaAsync(pjuridica, TipoRequisicaoEnum.Inserir);
                if (Int32.TryParse(resultado.ToString(), out var idPJuridica))
                {
                    if (radioEFiliado.Checked)
                    {
                        MessageBoxes.MostraMensagens("Igreja filiada com sucesso!", "Sucesso!");
                        txtIdPJuridica.Text = idPJuridica.ToString();
                    }
                    else
                    {
                        MessageBoxes.MostraMensagens("Igreja cadastrada com sucesso!", "Sucesso!");
                    }
                }
                else
                {
                    MessageBoxes.MostraMensagens("Erro ao guardar Igreja!", "Erro!");
                }
            }
        }

        private static string EnviaPJuridicaAsync(PJuridica pjuridica, TipoRequisicaoEnum requisicaoEnum)
        {
            Task<string> tarefa = Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(new { PJuridicas = new List<PJuridica>() { pjuridica } }, "PJuridicas", requisicaoEnum));
            MessageBoxes.MostraMensagens("Enviando igreja!", "Aguarde!");

            return tarefa.Result;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                var pjuridica = PegaFormulario();
                var resultado = EnviaPJuridicaAsync(pjuridica, TipoRequisicaoEnum.Alterar);

                if (Int32.TryParse(resultado.ToString(), out _))
                {
                    MessageBoxes.MostraMensagens("Igreja alterada com sucesso!", "Sucesso!");
                }
                else
                {
                    MessageBoxes.MostraMensagens("Erro ao alterar Igreja!", "Erro!");
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (_formListaPJuridica == null)
            {
                _formListaPJuridica = new FormListaPJuridica(1);
                _formListaPJuridica.FormClosed += formListaPJuridica_FormClosed;
            }

            _formListaPJuridica.Show(this);
        }

        private void formListaPJuridica_FormClosed(object sender, FormClosedEventArgs e)
        {
            var pJuridicas = _formListaPJuridica.PJuridicaEscolhida;
            _formListaPJuridica = null;
            Show();
            if (pJuridicas != null)
            {
                MostrarDados(pJuridicas);
            }
        }

        private void btnServico_Click(object sender, EventArgs e)
        {
            Form form = new FormOrdemServico(_atendentes, Convert.ToInt32(txtIdPJuridica.Text), 1);
            form.Show();
        }

        private void AtivaBotoes()
        {
            btnInserir.Enabled = false;
            btnAlterar.Enabled = true;
            btnServico.Enabled = true;
            btnCredencial.Enabled = true;
        }

        private void DesativaBotoes()
        {
            btnInserir.Enabled = true;
            btnAlterar.Enabled = false;
            btnServico.Enabled = false;
            btnCredencial.Enabled = false;
        }

        private bool Validacao()
        {
            if (!radioEFiliado.Checked && !radioNaoFiliado.Checked)
            {
                MessageBoxes.MostraMensagens("Deve ser definido se a pessoa física é filiada ou não!", "Erro!");
                return false;
            }
            if (Regex.Match(lblIdPFisicaPresidente.Text, @"\d+").Value == "")
            {
                MessageBoxes.MostraMensagens("É necessário escolher um Presidente para a pessoa jurídica!", "Erro!");
                return false;
            }
            return true;
        }

        private void btnCredencial_Click(object sender, EventArgs e)
        {
            var pjuridica = PegaFormulario();
            pjuridica.PFisicaPresidente = ProcurarPFisica(pjuridica.PFisicaPresidente.IdPFisica);
            WordUtil wordUtil = new WordUtil();
            wordUtil.GerarCredencial(new List<PJuridica>() { pjuridica });

            MessageBoxes.MostraMensagens("Credencial gerada com sucesso!", "Sucesso!");
        }

        private void checkFundacao_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFundacao.Checked)
            {
                lblFundacao.Visible = true;
                dateTimeFundacao.Visible = true;
                checkFundacao.Text = "";
            } else
            {
                lblFundacao.Visible = false;
                dateTimeFundacao.Visible = false;
                checkFundacao.Text = "Data da Fundação";
            }
        }
    }
}