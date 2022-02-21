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
    public partial class FormOrdemServico : Form
    {
        private readonly JsonParaClasse _jsonParaClasse;
        private readonly List<Atendente> _atendentes;

        public FormOrdemServico(List<Atendente> atendentes, int id, int tipo, OrdemServico ordem = null)
        {
            InitializeComponent();
            _jsonParaClasse = new JsonParaClasse();
            cmbTipoServico.DataSource = Enum.GetValues(typeof(TipoServicoEnum));
            cmbAtendente.DisplayMember = "Nome";
            cmbAtendente.ValueMember = "CodAtendente";
            cmbAtendente.DataSource = atendentes;
            this._atendentes = atendentes;
            if (tipo == 0)
            {
                radioPFisica.Checked = true;
            }
            else
            {
                radioPJuridica.Checked = true;
            }
            if (ordem == null)
            {
                txtId.Text = id.ToString();
                btnAlterar.Enabled = false;
                btnInserir.Enabled = true;

                LimparCampos();
            } else
            {
                btnInserir.Enabled = false;
                btnAlterar.Enabled = true;
                MostraDados(ordem, tipo);
            }
        }

        private void checkFeito_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFeito.Checked)
            {
                lblFeito.Enabled = true;
                dateTimeFeito.Enabled = true;
            } else
            {
                lblFeito.Enabled = false;
                dateTimeFeito.Enabled = false;
            }
        }

        private void checkEntregue_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEntregue.Checked)
            {
                lblEntregue.Enabled = true;
                dateTimeEntregue.Enabled = true;
            } else
            {
                lblEntregue.Enabled = false;
                dateTimeEntregue.Enabled = false;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            lblIdOrdem.Text = "Número do Pedido:";
            cmbAtendente.SelectedItem = 0;
            txtServico.Text = "";
            txtValor.Text = "0";
            txtPago.Text = "0";
            txtCredito.Text = "0";
            txtDeposito.Text = "0";
            lblResta.Text = "Resta:";
            txtObs.Text = "";
            txtLevou.Text = "";
            dateTimePedido.Value = DateTime.Now;
            dateTimeEntregue.Value = DateTime.Now;
            dateTimeFeito.Value = DateTime.Now;
            lblEntregue.Enabled = false;
            dateTimeEntregue.Enabled = false;
            lblFeito.Enabled = false;
            dateTimeFeito.Enabled = false;
            checkEntregue.Checked = false;
            checkFeito.Checked = false;
            btnAlterar.Enabled = false;
            btnInserir.Enabled = true;
            cmbTipoServico.SelectedIndex = 1;
            lblMensalidade.Visible = false;
            dateTimeMensalidade.Visible = false;
            dateTimeInicio.Visible = false;
            lblMensalidadeInicio.Visible = false;
            lblValor.Text = "Valor à Acrescentar: ";
            lblValor.Visible = false;
        }

        private static decimal TextoParaDecimal(string texto)
        {
            return texto != "" ? Convert.ToDecimal(texto.Replace(".",",")) : 0;
        }

        private OrdemServico PegaFormulario()
        {
            DateTime? dataFeito;
            DateTime? dataEntregue;
            DateTime? dataMensalidade = null;

            if (checkFeito.Checked) {
                dataFeito = dateTimeFeito.Value;
            } else
            {
                dataFeito = null;
            }

            if (checkEntregue.Checked)
            {
                dataEntregue = dateTimeEntregue.Value;
            }
            else
            {
                dataEntregue = null;
            }

            if ((TipoServicoEnum)cmbTipoServico.SelectedIndex == TipoServicoEnum.Mensalidade)
            {
                dataMensalidade = new DateTime(dateTimeMensalidade.Value.Year, dateTimeMensalidade.Value.Month, DateTime.DaysInMonth(dateTimeMensalidade.Value.Year, dateTimeMensalidade.Value.Month));
                Int32.TryParse(lblResta.Text, out var valor);
                if(Regex.Match(lblResta.Text, @"\d+").Value != "" && valor == 0 && lblIdOrdem.Text.Equals("Número do Pedido:"))
                {
                    dataFeito = DateTime.Now;
                    dataEntregue = DateTime.Now;
                }
            }

            return new OrdemServico()
            {
                IdOrdem = !lblIdOrdem.Text.Equals("Número do Pedido:") ? Convert.ToInt32(Regex.Match(lblIdOrdem.Text, @"\d+").Value) : 0,
                Servico = txtServico.Text,
                PFisica = radioPFisica.Checked ? new PFisica() { IdPFisica = Convert.ToInt32(txtId.Text) } : null,
                PJuridica = radioPJuridica.Checked ? new PJuridica() { IdPJuridica = Convert.ToInt32(txtId.Text) } : null,
                Atendente = new Atendente() { CodAtendente = Convert.ToInt32(cmbAtendente.SelectedValue) },
                TipoServico = (TipoServicoEnum)cmbTipoServico.SelectedIndex,
                DataMensalidade = dataMensalidade,
                Valor = TextoParaDecimal(txtValor.Text),
                CreditoAnterior = TextoParaDecimal(txtCredito.Text),
                Deposito = TextoParaDecimal(txtDeposito.Text),
                Pago = TextoParaDecimal(txtPago.Text),
                DataPedido = dateTimePedido.Value,
                DataFeito = dataFeito,
                DataEntregue = dataEntregue,
                Obs = txtObs.Text,
                QuemLevou = txtLevou.Text
            };
        }

        private static string EnviaOrdemAsync(OrdemServico ordemServico, TipoRequisicaoEnum requisicaoEnum)
        {
            Task<string> tarefa = Task.Run(() => RequisicaoMediador.RealizaRequisicaoPostEPutAsync(new { Ordens = new List<OrdemServico>() { ordemServico } }, "Ordens", requisicaoEnum));

            return tarefa.Result;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                var ordemServico = PegaFormulario();

                var resultado = EnviaOrdemAsync(ordemServico, TipoRequisicaoEnum.Inserir);
                if (Int32.TryParse(resultado.ToString(), out var idOrdem))
                {
                    MessageBoxes.MostraMensagens("Ordem de serviço enviada com sucesso!", "Sucesso!");
                    lblIdOrdem.Text += " " + idOrdem;
                    btnAlterar.Enabled = true;
                    btnInserir.Enabled = false;
                }
                else
                {
                    MessageBoxes.MostraMensagens("Erro ao guardar ordem de serviço!", "Erro!");
                }
            }
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            lblResta.Text = "Resta: " + (Convert.ToDecimal(txtValor.Text) - (txtPago.Text != "" ? Convert.ToDecimal(txtPago.Text) : 0) - (txtDeposito.Text != "" ? Convert.ToDecimal(txtDeposito.Text) : 0) - (txtCredito.Text != "" ? Convert.ToDecimal(txtCredito.Text) : 0));
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            lblResta.Text = "Resta: " + (Convert.ToDecimal(txtValor.Text) - (txtPago.Text != "" ? Convert.ToDecimal(txtPago.Text) : 0) - (txtDeposito.Text != "" ? Convert.ToDecimal(txtDeposito.Text) : 0) - (txtCredito.Text != "" ? Convert.ToDecimal(txtCredito.Text) : 0));
        }

        private void txtCredito_TextChanged(object sender, EventArgs e)
        {
            lblResta.Text = "Resta: " + (Convert.ToDecimal(txtValor.Text) - (txtPago.Text != "" ? Convert.ToDecimal(txtPago.Text) : 0) - (txtDeposito.Text != "" ? Convert.ToDecimal(txtDeposito.Text) : 0) - (txtCredito.Text != "" ? Convert.ToDecimal(txtCredito.Text) : 0));
        }

        private void txtDeposito_TextChanged(object sender, EventArgs e)
        {
            lblResta.Text = "Resta: " + (Convert.ToDecimal(txtValor.Text) - (txtPago.Text != "" ? Convert.ToDecimal(txtPago.Text) : 0) - (txtDeposito.Text != "" ? Convert.ToDecimal(txtDeposito.Text) : 0) - (txtCredito.Text != "" ? Convert.ToDecimal(txtCredito.Text) : 0));
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

        private void btnMensalidades_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length == 0)
            {
                MessageBoxes.MostraMensagens("Você precisa digitar um número do Rol.", "Erro!");
            }
            else
            {
                var jsonOrdem = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/OrdemServico?Rol=" + txtId.Text + "&Tipo=M&Fonte=" + (radioPFisica.Checked ? "F" : "J")));
                if (jsonOrdem != null && jsonOrdem.Count > 0)
                {
                    List<OrdemServico> ordens = ((List<OrdemServico>)_jsonParaClasse.GetOrdens(jsonOrdem)).ToList();
                    FormListaOrdem formLista = new FormListaOrdem(ordens, _atendentes);
                    this.Close();
                    formLista.Show();
                } else
                {
                    MessageBoxes.MostraMensagens("Não existem mensalidades cadastradas para esta pessoa " + (radioPFisica.Checked ? "física!" : "jurídica!"), "Aviso");
                }
            }
        }

        private void MostraDados(OrdemServico ordem, int tipo)
        {
            lblIdOrdem.Text = "Número do Pedido: " + ordem.IdOrdem;
            if(ordem.PFisica != null)
            {
                txtId.Text = ordem.PFisica.IdPFisica.ToString();
            } else
            {
                txtId.Text = ordem.PJuridica.IdPJuridica.ToString();
            }

            cmbAtendente.SelectedItem = ordem.Atendente.CodAtendente;
            txtServico.Text = ordem.Servico;
            cmbTipoServico.SelectedIndex = (int) ordem.TipoServico;
            txtValor.Text = ordem.Valor.ToString();
            txtPago.Text = ordem.Pago.ToString();
            txtCredito.Text = ordem.CreditoAnterior.ToString();
            txtDeposito.Text = ordem.Deposito.ToString();
            lblResta.Text = "Resta: " + ordem.Resta;
            txtObs.Text = ordem.Obs;
            txtLevou.Text = ordem.QuemLevou;
            dateTimePedido.Value = ordem.DataPedido != null && ordem.DataPedido.Value.Year != 1970 ? ordem.DataPedido.Value : DateTime.Now;
            dateTimeEntregue.Value = ordem.DataEntregue != null && ordem.DataEntregue.Value.Year != 1970 ? ordem.DataEntregue.Value : DateTime.Now;
            dateTimeFeito.Value = ordem.DataFeito != null && ordem.DataFeito.Value.Year != 1970 ? ordem.DataFeito.Value : DateTime.Now;
            lblEntregue.Enabled = ordem.DataEntregue != null && ordem.DataEntregue.Value.Year != 1970 ? true : false;
            dateTimeEntregue.Enabled = ordem.DataEntregue != null && ordem.DataEntregue.Value.Year != 1970 ? true : false;
            lblFeito.Enabled = ordem.DataFeito != null && ordem.DataFeito.Value.Year != 1970 ? true : false;
            dateTimeFeito.Enabled = ordem.DataFeito != null && ordem.DataFeito.Value.Year != 1970 ? true : false;            
            checkEntregue.Checked = ordem.DataEntregue != null && ordem.DataEntregue.Value.Year != 1970 ? true : false;
            checkFeito.Checked = ordem.DataFeito != null && ordem.DataFeito.Value.Year != 1970 ? true : false;

            lblMensalidadeInicio.Visible = ordem.DataMensalidade != null && ordem.DataMensalidade.Value.Year != 1970 ? true : false;
            dateTimeInicio.Visible = ordem.DataMensalidade != null && ordem.DataMensalidade.Value.Year != 1970 ? true : false;
            lblMensalidade.Visible = ordem.DataMensalidade != null && ordem.DataMensalidade.Value.Year != 1970 ? true : false;
            dateTimeMensalidade.Visible = ordem.DataMensalidade != null && ordem.DataMensalidade.Value.Year != 1970 ? true : false;
            if(ordem.DataMensalidade != null)
            {
                dateTimeMensalidade.Value = new DateTime(ordem.DataMensalidade.Value.Year, ordem.DataMensalidade.Value.Month, 28);
                dateTimeInicio.Value = new DateTime(ordem.DataMensalidade.Value.Year, ordem.DataMensalidade.Value.Month, 28);
            }
            radioPFisica.Checked = tipo == 0 ? true : false;
            radioPJuridica.Checked = tipo == 1 ? true : false;
        }

        private void btnListaServico_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length == 0)
            {
                MessageBoxes.MostraMensagens("Você precisa digitar um número do Rol.", "Erro!");
            }
            else
            {
                var jsonOrdem = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/OrdemServico?Rol=" + txtId.Text + "&Tipo=L&Fonte=" + (radioPFisica.Checked ? "F" : "J")));
                if (jsonOrdem != null && jsonOrdem.Count > 0)
                {
                    List<OrdemServico> ordens = ((List<OrdemServico>)_jsonParaClasse.GetOrdens(jsonOrdem)).ToList();
                    FormListaOrdem formLista = new FormListaOrdem(ordens, _atendentes);
                    this.Close();
                    formLista.Show();
                } else
                {
                    MessageBoxes.MostraMensagens("Não existem serviços realizados para esta pessoa " + (radioPFisica.Checked ? "física!" : "jurídica!"), "Aviso");
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Validacao())
            {
                var ordemServico = PegaFormulario();

                var resultado = EnviaOrdemAsync(ordemServico, TipoRequisicaoEnum.Alterar);
                if (Int32.TryParse(resultado.ToString(), out _))
                {
                    MessageBoxes.MostraMensagens("Ordem de serviço alterada com sucesso!", "Sucesso!");
                }
                else
                {
                    MessageBoxes.MostraMensagens("Erro ao alterar ordem de serviço!", "Erro!");
                }
            }
        }

        private bool Validacao()
        {
            if (!radioPFisica.Checked && !radioPJuridica.Checked)
            {
                MessageBoxes.MostraMensagens("Deve ser definido se é pessoa física ou jurídica!", "Erro!");
                return false;
            }
            if (txtValor.Text == "")
            {
                MessageBoxes.MostraMensagens("Defina um valor para o serviço!", "Erro!");
                return false;
            }
            if (txtId.Text == "")
            {
                MessageBoxes.MostraMensagens("O número do Rol está em branco!", "Erro!");
                return false;
            }
            return true;
        }

        private void cmbTipoServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoServico.SelectedIndex == 0)
            {
                lblMensalidade.Visible = true;
                dateTimeMensalidade.Visible = true;
                lblMensalidadeInicio.Visible = true;
                dateTimeInicio.Visible = true;                
                lblValor.Visible = true;
                lblValor.Text = "Valor à Acrescentar: ";

                if (txtId.Text != "")
                {
                    OrdemServico ordemServico = null;
                    if (radioPFisica.Checked)
                    {
                        ordemServico = new OrdemServico() { PFisica = new PFisica() { IdPFisica = Int32.Parse(txtId.Text) } };
                    } else
                    {
                        ordemServico = new OrdemServico() { PJuridica = new PJuridica() { IdPJuridica = Int32.Parse(txtId.Text) } };
                    }

                    var jsonOrdem = JsonConvert.DeserializeObject(EnviaOrdemAsync(ordemServico, TipoRequisicaoEnum.Pegar));
                    
                    if (jsonOrdem != null)
                    {
                        List<OrdemServico> ordens = ((List<OrdemServico>)_jsonParaClasse.GetOrdens(jsonOrdem)).ToList();
                        dateTimeInicio.Value = ordens.First().DataMensalidade.Value;

                        if (dateTimeInicio.Value < dateTimeMensalidade.Value)
                        {
                            int valorMensal = radioPFisica.Checked ? 9 : 7;
                            lblValor.Text = "Valor à Acrescentar: " + ((((dateTimeMensalidade.Value.Year - dateTimeInicio.Value.Year) * 12) + dateTimeMensalidade.Value.Month - dateTimeInicio.Value.Month) * valorMensal).ToString();
                        }
                        else
                        {
                            lblValor.Text = "Valor à Acrescentar: ";
                        }
                    } else
                    {
                        MessageBoxes.MostraMensagens("Aviso! Este Filiado não possui registros de mensalidades anteriores!", "Aviso!");
                    }
                }

            } else
            {
                lblMensalidade.Visible = false;
                dateTimeMensalidade.Visible = false;
            }
        }

        private void dateTimeMensalidade_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeInicio.Value < dateTimeMensalidade.Value)
            {
                int valorMensal = radioPFisica.Checked ? 9 : 7;
                lblValor.Text = "Valor à Acrescentar: " + ((((dateTimeMensalidade.Value.Year - dateTimeInicio.Value.Year) * 12) + dateTimeMensalidade.Value.Month - dateTimeInicio.Value.Month) * valorMensal).ToString();
            } else
            {
                lblValor.Text = "Valor à Acrescentar: ";
            }
        }
    }
}