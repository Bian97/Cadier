using CadierBiblioteca.Enums;
using CadierBiblioteca.ModelosAtuais;
using CadierDesktop.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadierDesktop
{
    public partial class FormMultiplosDocumentos : Form
    {
        FormListaPFisica _formListaPFisica;
        PFisica _pFisica1;
        PFisica _pFisica2;
        PFisica _pFisica3;
        PFisica _pFisica4;

        public FormMultiplosDocumentos()
        {
            InitializeComponent();
            cmbCondicao.SelectedIndex = 0;
        }

        private void btnPVC_Click(object sender, EventArgs e)
        {
            if (MessageBoxes.InputBox("Escolha o PVC", "Qual PVC será gerado? 1-Verde | 2-Cinza", out var opcao) == DialogResult.OK)
            {
                List<PFisica> pfisicas = new List<PFisica>() { _pFisica1, _pFisica2 };

                if (_pFisica3 != null && _pFisica4 != null)
                {
                    pfisicas.Add(_pFisica3);
                    pfisicas.Add(_pFisica4);
                }

                WordUtil wordUtil = new WordUtil();

                if (Convert.ToInt32(opcao) == 1)
                {
                    wordUtil.GerarPVC(pfisicas, TipoPVCEnum.Verde);
                }
                else
                {
                    wordUtil.GerarPVC(pfisicas, TipoPVCEnum.Cinza);
                }
                MessageBoxes.MostraMensagens("PVCs gerados com sucesso", "Sucesso!");
            }
        }

        private void cmbCondicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(cmbCondicao.SelectedItem) == 2)
            {
                lblIdPFisica3.Enabled = false;
                btnProcurar3.Enabled = false;
                lblIdPFisica4.Enabled = false;
                btnProcurar4.Enabled = false;
            } else
            {
                lblIdPFisica3.Enabled = true;
                btnProcurar3.Enabled = true;
                lblIdPFisica4.Enabled = true;
                btnProcurar4.Enabled = true;
            }
        }

        private void btnProcurar1_Click(object sender, EventArgs e)
        {
            _pFisica1 = null;
            ListarPFisica();
        }

        void formListaPFisica_FormClosed(object sender, FormClosedEventArgs e)
        {
            var pFisica = _formListaPFisica.PFisicaEscolhida;

            if (pFisica != null)
            {
                if (_pFisica1 == null)
                {
                    _pFisica1 = pFisica;
                    txtIdPFisica1.Text = _pFisica1.IdPFisica.ToString();
                }
                else if (_pFisica2 == null)
                {
                    _pFisica2 = pFisica;
                    txtIdPFisica2.Text = _pFisica2.IdPFisica.ToString();
                }
                else if (_pFisica3 == null)
                {
                    _pFisica3 = pFisica;
                    txtIdPFisica3.Text = _pFisica3.IdPFisica.ToString();
                }
                else if (_pFisica4 == null)
                {
                    _pFisica4 = pFisica;
                    txtIdPFisica4.Text = _pFisica4.IdPFisica.ToString();
                }
            }
            _formListaPFisica = null;
            Show();            
        }

        private void btnProcurar2_Click(object sender, EventArgs e)
        {
            _pFisica2 = null;
            ListarPFisica();
        }

        private void btnProcurar3_Click(object sender, EventArgs e)
        {
            _pFisica3 = null;
            ListarPFisica();
        }

        private void btnProcurar4_Click(object sender, EventArgs e)
        {
            _pFisica4 = null;
            ListarPFisica();
        }

        void ListarPFisica()
        {
            if (_formListaPFisica == null)
            {
                _formListaPFisica = new FormListaPFisica();
                _formListaPFisica.FormClosed += formListaPFisica_FormClosed;
            }

            _formListaPFisica.Show(this);
        }
    }
}
