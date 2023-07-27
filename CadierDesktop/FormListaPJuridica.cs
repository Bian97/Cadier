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
    public partial class FormListaPJuridica : Form
    {
        private readonly JsonParaClasse _jsonParaClasse;
        Label lblIdPJuridica, lblNomePJuridica;
        private List<PJuridica> _pjuridicas;
        private int pai;
        public PJuridica PJuridicaEscolhida { get; set; }        

        public FormListaPJuridica(int pai, Label lblIdPJuridica = null, Label lblNomePJuridica = null)
        {          
            InitializeComponent();
            _jsonParaClasse = new JsonParaClasse();
            this.pai = pai;

            if (pai == 0)
            {
                this.lblIdPJuridica = lblIdPJuridica;
                this.lblNomePJuridica = lblNomePJuridica;                
            }
            var jsonPJuridicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PJuridica"));
            _pjuridicas = ((List<PJuridica>)_jsonParaClasse.GetPJuridicas(jsonPJuridicas)).AsParallel().ToList();
            CarregaLista(_pjuridicas);
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

        private void CarregaLista(List<PJuridica> pjuridicas)
        {
            listViewPJuridica.Items.Clear();
            listViewPJuridica.View = View.Details;
            listViewPJuridica.FullRowSelect = true;
            listViewPJuridica.MultiSelect = false;
            foreach (var pjuridica in pjuridicas)
            {
                ListViewItem item = new ListViewItem(new[] { pjuridica.IdPJuridica.ToString(), pjuridica.Nome, pjuridica.PFisicaPresidente?.IdPFisica.ToString(), pjuridica.PFisicaPresidente?.Nome,
                pjuridica.Endereco?.Bairro, pjuridica.Endereco?.Cidade});
                listViewPJuridica.Items.Add(item);
            }
            listViewPJuridica.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewPJuridica.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewPJuridica.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            listViewPJuridica.ItemActivate += new System.EventHandler(this.listViewPJuridica_DoubleClick);
        }

        private void txtIdPJuridica_TextChanged(object sender, EventArgs e)
        {
            listViewPJuridica.Items.Clear();
            listViewPJuridica.Items.AddRange(_pjuridicas.Where(i => string.IsNullOrEmpty(txtIdPJuridica.Text) || i.IdPJuridica.ToString().StartsWith(txtIdPJuridica.Text))
                .Select(c => new ListViewItem(new[] { c.IdPJuridica.ToString(), c.Nome, c.PFisicaPresidente?.IdPFisica.ToString(), c.PFisicaPresidente?.Nome, c.Endereco?.Bairro, c.Endereco?.Cidade })).ToArray());
        }

        private void txtNomeIgreja_TextChanged(object sender, EventArgs e)
        {
            listViewPJuridica.Items.Clear();
            listViewPJuridica.Items.AddRange(_pjuridicas.Where(i => string.IsNullOrEmpty(txtNomeIgreja.Text) || i.Nome.ToString().Contains(txtNomeIgreja.Text))
                .Select(c => new ListViewItem(new[] { c.IdPJuridica.ToString(), c.Nome, c.PFisicaPresidente?.IdPFisica.ToString(), c.PFisicaPresidente?.Nome, c.Endereco?.Bairro, c.Endereco?.Cidade })).ToArray());
        }

        private void txtIdPFisicaPresidente_TextChanged(object sender, EventArgs e)
        {
            listViewPJuridica.Items.Clear();
            listViewPJuridica.Items.AddRange(_pjuridicas.Where(i => i.PFisicaPresidente != null && (string.IsNullOrEmpty(txtIdPFisicaPresidente.Text) || i.PFisicaPresidente.IdPFisica.ToString().StartsWith(txtIdPFisicaPresidente.Text)))
                .Select(c => new ListViewItem(new[] { c.IdPJuridica.ToString(), c.Nome, c.PFisicaPresidente.IdPFisica.ToString(), c.PFisicaPresidente.Nome, c.Endereco?.Bairro, c.Endereco?.Cidade })).ToArray());
        }

        private void txtNomePrPresidente_TextChanged(object sender, EventArgs e)
        {
            listViewPJuridica.Items.Clear();
            listViewPJuridica.Items.AddRange(_pjuridicas.Where(i => i.PFisicaPresidente != null && (string.IsNullOrEmpty(txtNomePrPresidente.Text) || i.PFisicaPresidente.Nome.ToString().Contains(txtNomePrPresidente.Text)))
                .Select(c => new ListViewItem(new[] { c.IdPJuridica.ToString(), c.Nome, c.PFisicaPresidente?.IdPFisica.ToString(), c.PFisicaPresidente?.Nome, c.Endereco?.Bairro, c.Endereco?.Cidade })).ToArray());
        }

        private void listViewPJuridica_DoubleClick(object sender, EventArgs e)
        {
            if (pai == 0)
            {
                lblIdPJuridica.Text = "Rol: ";
                lblNomePJuridica.Text = "Nome: ";
                lblIdPJuridica.Text += listViewPJuridica.SelectedItems[0].SubItems[0].Text;
                lblNomePJuridica.Text += listViewPJuridica.SelectedItems[0].SubItems[1].Text;
            } else
            {
                PJuridicaEscolhida = _pjuridicas.First(x => x.IdPJuridica == Convert.ToInt32(listViewPJuridica.SelectedItems[0].SubItems[0].Text));
            }

            this.Close();
        }
    }
}