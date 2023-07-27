using Cadier.Model;
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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void menuAtualizaBase_Click(object sender, EventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                form.Close();
            }
            MostrarForm(new FormAtualizaBase());
        }

        private void MostrarForm(Form frm)
        {
            Cursor.Current = Cursors.WaitCursor;
            var open = MdiChildren.Where(f => f.GetType() == frm.GetType()).ToArray();
            if (open.Length < 1)
            {
                frm.MdiParent = this;
                frm.MaximizeBox = true;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
                frm.BringToFront();
            }
            Cursor.Current = Cursors.Default;
        }

        private bool AbrirFormExistente(string nomeForm)
        {
            foreach (var form in this.MdiChildren)
            {
                if (form.Name == nomeForm)
                {
                    form.WindowState = 0;
                    form.Show();
                    form.Activate();
                    return true;
                }
            }
            return false;
        }

        private void pessoaFisicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AbrirFormExistente("FormPFisica"))
            {
                MostrarForm(new FormPFisica());
            }
            //foreach(var form in this.MdiChildren)
            //{
            //    form.Close();
            //}            
        }

        private void pessoaJurídicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AbrirFormExistente("FormPJuridica"))
            {
                MostrarForm(new FormPJuridica());
            }
            //foreach (var form in this.MdiChildren)
            //{
            //    form.Close();
            //}                
        }

        private void gerarMúltiplosDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AbrirFormExistente("FormMultiplosDocumentos"))
            {
                MostrarForm(new FormMultiplosDocumentos());
            }
            //foreach (var form in this.MdiChildren)
            //{
            //    form.Close();
            //}            
        }

        private void resumoReuniãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (var form in this.MdiChildren)
            //{
            //    form.Close();
            //}
            if (!AbrirFormExistente("FormListaOrdem"))
            {
                DateTime dataReuniao = DateTime.Now;

                if (MessageBoxes.TimePicker("Data da Reunião", "Digite a data da reunião!", out dataReuniao) !=
                    DialogResult.OK) return;
                JsonParaClasse jsonParaClasse = new JsonParaClasse();
                var json = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet("http://cadier.com.br/api/OrdemServico?Tipo=R&Data=" + dataReuniao.ToString("dd/MM/yyyy")));
                var ordens = ((List<OrdemServico>)jsonParaClasse.GetOrdens(json));

                if (ordens.Count > 0)
                {
                    json = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet("http://cadier.com.br/api/Atendente"));
                    var atendentes = ((List<Atendente>)jsonParaClasse.GetAtendentes(json));
                    //MostrarForm(new FormOrdemServico());
                    var form = new FormListaOrdem(ordens, atendentes, dataReuniao);
                    MostrarForm(form);
                }
                else
                {
                    MessageBoxes.MostraMensagens("Reunião não encontrada!", "Erro!");
                }
            }
        }

        private void todosOsServicosPendentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!AbrirFormExistente("FormServicosPendentes"))
            {
                MostrarForm(new FormServicosPendentes());
            }
        }

        private static dynamic TransformaJson(WebResponse valor)
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
