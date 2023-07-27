using CadierBiblioteca;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadierDesktop
{
    public partial class FormListaOrdem : Form
    {
        private List<OrdemServico> _ordens;
        private readonly List<Atendente> _atendentes;

        public FormListaOrdem(List<OrdemServico> ordens, List<Atendente> atendentes, DateTime? dataReuniao = null)
        {
            this._atendentes = atendentes;
            this._ordens = ordens;
            InitializeComponent();
            this.Disposed += FormListaOrdem_Disposed;

            if(dataReuniao != null)
            {
                dateTimeReuniao.Value = dataReuniao.Value;
            }

            CarregaLista(ordens);
        }

        private void CarregaLista(List<OrdemServico> ordens, bool primeiraExecucao = true)
        {
            listViewOrdem.Items.Clear();
            listViewOrdem.View = View.Details;
            listViewOrdem.FullRowSelect = true;
            listViewOrdem.MultiSelect = false;
            foreach (var ordem in ordens)
            {
                int id = ordem.PFisica != null ? ordem.PFisica.IdPFisica : ordem.PJuridica.IdPJuridica;
                DateTime dataPedido = ordem.DataPedido ?? new DateTime(1970, 1, 1);
                DateTime dataFeito = ordem.DataFeito ?? new DateTime(1970,1,1);
                DateTime dataEntregue = ordem.DataEntregue ?? new DateTime(1970, 1, 1);

                ListViewItem item = new ListViewItem(new[] { ordem.IdOrdem.ToString(), id.ToString(), ordem.Servico,
                ordem.Valor.ToString(), ordem.Pago.ToString(), ordem.Resta.ToString(), dataPedido.Year != 1970 ? dataPedido.ToString("dd/MM/yyyy") : null,
                dataFeito.Year != 1970 ? dataFeito.ToString("dd/MM/yyyy") : null,
                dataEntregue.Year != 1970 ? dataEntregue.ToString("dd/MM/yyyy") : null});
                listViewOrdem.Items.Add(item);
            }
            listViewOrdem.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewOrdem.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            if (primeiraExecucao)
            {
                listViewOrdem.Activation = System.Windows.Forms.ItemActivation.TwoClick;
                listViewOrdem.ItemActivate += new System.EventHandler(this.listViewOrdem_DoubleClick);
            }
        }

        private void listViewOrdem_DoubleClick(object sender, EventArgs e)
        {
            var tipo = _ordens.Where(x => x.IdOrdem == Convert.ToInt32(listViewOrdem.SelectedItems[0].SubItems[0].Text)).Select(x => x.PFisica).FirstOrDefault() != null ? 0 : 1;
            FormOrdemServico ordemServico = new FormOrdemServico(_atendentes, Convert.ToInt32(listViewOrdem.SelectedItems[0].SubItems[1].Text), tipo, _ordens.First(x => x.IdOrdem == Convert.ToInt32(listViewOrdem.SelectedItems[0].SubItems[0].Text)));
            if (!(this.MdiParent is FormPrincipal))
            {
                this.Disposed -= FormListaOrdem_Disposed;
                this.Close();
            }
            ordemServico.Show();
        }

        void FormListaOrdem_Disposed(object sender, EventArgs e)
        {
            if (this.MdiParent is FormOrdemServico)
            {
                var tipo = _ordens.Where(x => x.IdOrdem == Convert.ToInt32(listViewOrdem.SelectedItems[0].SubItems[0].Text)).Select(x => x.PFisica).FirstOrDefault() != null ? 0 : 1;
                FormOrdemServico ordemServico = new FormOrdemServico(_atendentes, _ordens.Any(x => x.PFisica != null) ? _ordens.Select(x => x.PFisica.IdPFisica).First() : _ordens.Select(x => x.PJuridica.IdPJuridica).First(), tipo);
                this.Close();
                ordemServico.Show();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            JsonParaClasse jsonParaClasse = new JsonParaClasse();
            var json = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet("http://cadier.com.br/api/OrdemServico?Tipo=R&Data=" + dateTimeReuniao.Value.ToString("dd/MM/yyyy")));
            var ordens = ((List<OrdemServico>)jsonParaClasse.GetOrdens(json));

            this._ordens = new List<OrdemServico>();
            this._ordens = ordens;

            CarregaLista(ordens, false);
        }

        private void FormListaOrdem_Activated(object sender, EventArgs e)
        {
            if ((this.MdiParent is FormPrincipal))
            {
                btnAtualizar.Visible = true;
                lblReuniao.Visible = true;
                dateTimeReuniao.Visible = true;                
            }
        }

        private dynamic TransformaJson(WebResponse valor)
        {
            if (((HttpWebResponse)valor).StatusCode == HttpStatusCode.NotFound)
            {
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
    }
}