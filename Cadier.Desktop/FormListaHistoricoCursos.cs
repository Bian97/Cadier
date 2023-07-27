using Cadier.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadier.Desktop
{
    public partial class FormListaHistoricoCursos : Form
    {
        private List<HistoricoCursos> _historicos;
        public HistoricoCursos HistoricoEscolhido { get; set; }

        public FormListaHistoricoCursos(List<HistoricoCursos> historicos)
        {
            InitializeComponent();

            this._historicos = historicos;
            CarregaLista(historicos);
        }

        private void CarregaLista(List<HistoricoCursos> historicos)
        {
            listViewHistorico.Items.Clear();
            listViewHistorico.View = View.Details;
            listViewHistorico.FullRowSelect = true;
            listViewHistorico.MultiSelect = false;
            foreach (var item in historicos.Select(historico => new ListViewItem(new[] { historico.IdCurso.ToString(), historico.Curso, historico.RestaPagar.ToString() })))
            {
                listViewHistorico.Items.Add(item);
            }
            listViewHistorico.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewHistorico.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewHistorico.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            listViewHistorico.ItemActivate += new System.EventHandler(this.listViewHistorico_DoubleClick);
        }

        private void listViewHistorico_DoubleClick(object sender, EventArgs e)
        {
            HistoricoEscolhido = _historicos.First(x => x.IdCurso == Convert.ToInt32(listViewHistorico.SelectedItems[0].SubItems[0].Text));
            this.Close();
        }
    }
}
