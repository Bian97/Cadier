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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadier.Desktop
{
    public partial class FormListaHistoricoConsagracao : Form
    {
        private List<HistoricoConsagracao> _historicos;
        public HistoricoConsagracao HistoricoEscolhido { get; set; }

        public FormListaHistoricoConsagracao(List<HistoricoConsagracao> historicos)
        {
            InitializeComponent();

            this._historicos = historicos;
            CarregaLista(historicos);
        }

        private void CarregaLista(List<HistoricoConsagracao> historicos)
        {
            listViewHistorico.Items.Clear();
            listViewHistorico.View = View.Details;
            listViewHistorico.FullRowSelect = true;
            listViewHistorico.MultiSelect = false;
            foreach (var historico in historicos)
            {
                ListViewItem item = new ListViewItem(new[] { historico.IdConsagracao.ToString(), historico.Cargo.ToString(), historico.Local });
                listViewHistorico.Items.Add(item);
            }
            listViewHistorico.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewHistorico.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewHistorico.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            listViewHistorico.ItemActivate += new System.EventHandler(this.listViewHistorico_DoubleClick);
        }

        private void listViewHistorico_DoubleClick(object sender, EventArgs e)
        {
            HistoricoEscolhido = _historicos.First(x => x.IdConsagracao == Convert.ToInt32(listViewHistorico.SelectedItems[0].SubItems[0].Text));
            this.Close();
        }
    }
}
