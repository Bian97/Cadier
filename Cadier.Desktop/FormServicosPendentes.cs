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
using Cadier.Model;
using Cadier.Model.Models;
using Cadier.Model.Utilitarios;
using Cadier.Desktop.Utilitarios;
using Newtonsoft.Json;

namespace Cadier.Desktop
{
    public partial class FormServicosPendentes : Form
    {
        private List<OrdemServico> _ordens;
        private readonly List<Atendente> _atendentes;

        public FormServicosPendentes()
        {
            var jsonParaClasse = new JsonParaClasse();
            var jsonAtendentes = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet("http://cadier.com.br/api/Atendente"));
            _atendentes = ((List<Atendente>)jsonParaClasse.GetAtendentes(jsonAtendentes));
            InitializeComponent();
        }

        private void FormServicosPendentes_Load(object sender, EventArgs e)
        {
            JsonParaClasse jsonParaClasse = new JsonParaClasse();
            var json = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet("http://cadier.com.br/api/allPendingOrders"));
            _ordens = ((List<OrdemServico>)jsonParaClasse.GetOrdens(json)).AsParallel().ToList();
            if (_ordens.Count <= 0)
            {
                MessageBoxes.MostraMensagens("Não há serviços pendentes!", "Aviso!");
                this.Close();
                return;
            }
            CarregaLista(_ordens);
        }

        private void CarregaLista(List<OrdemServico> ordens, bool primeiraExecucao = true)
        {
            listViewServicosPendentes.Items.Clear();
            listViewServicosPendentes.View = View.Details;
            listViewServicosPendentes.FullRowSelect = true;
            listViewServicosPendentes.MultiSelect = false;
            foreach (var ordem in ordens)
            {
                int id = ordem.PFisica != null ? ordem.PFisica.IdPFisica : ordem.PJuridica.IdPJuridica;
                DateTime dataPedido = ordem.DataPedido != null ? ordem.DataPedido.Value : new DateTime(1970, 1, 1);
                DateTime dataFeito = ordem.DataFeito != null ? ordem.DataFeito.Value : new DateTime(1970, 1, 1);
                DateTime dataEntregue = ordem.DataEntregue != null ? ordem.DataEntregue.Value : new DateTime(1970, 1, 1);

                ListViewItem item = new ListViewItem(new[] { ordem.IdOrdem.ToString(), id.ToString(), ordem.Servico,
                    ordem.Valor.ToString(), ordem.Pago.ToString(), ordem.Resta.ToString(), dataPedido.Year != 1970 ? dataPedido.ToString("dd/MM/yyyy") : null,
                    dataFeito.Year != 1970 ? dataFeito.ToString("dd/MM/yyyy") : null,
                    dataEntregue.Year != 1970 ? dataEntregue.ToString("dd/MM/yyyy") : null});
                listViewServicosPendentes.Items.Add(item);
            }
            listViewServicosPendentes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewServicosPendentes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //listViewServicosPendentes.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.None);
            listViewServicosPendentes.Columns[2].Width = 300;
            if (primeiraExecucao)
            {
                listViewServicosPendentes.Activation = System.Windows.Forms.ItemActivation.TwoClick;
                listViewServicosPendentes.ItemActivate += new System.EventHandler(this.listViewServicosPendentes_DoubleClick);
            }
        }

        private void listViewServicosPendentes_DoubleClick(object sender, EventArgs e)
        {
            var tipo = _ordens.Where(x => x.IdOrdem == Convert.ToInt32(listViewServicosPendentes.SelectedItems[0].SubItems[0].Text)).Select(x => x.PFisica).FirstOrDefault() != null ? 0 : 1;
            FormOrdemServico ordemServico = new FormOrdemServico(_atendentes, Convert.ToInt32(listViewServicosPendentes.SelectedItems[0].SubItems[1].Text), tipo, _ordens.First(x => x.IdOrdem == Convert.ToInt32(listViewServicosPendentes.SelectedItems[0].SubItems[0].Text)));
            if (!(this.MdiParent is FormPrincipal))
            {
                this.Close();
            }
            ordemServico.Show();
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            JsonParaClasse jsonParaClasse = new JsonParaClasse();
            var json = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet("http://cadier.com.br/api/allPendingOrders"));
            _ordens = ((List<OrdemServico>)jsonParaClasse.GetOrdens(json)).AsParallel().ToList();

            CarregaLista(_ordens, false);
        }
    }
}
