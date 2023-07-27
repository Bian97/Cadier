using Cadier.Model.Enums;
using Cadier.Model.Models;
using Cadier.Model.Utilitarios;
using Cadier.Desktop.Utilitarios;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class FormListaPFisica : Form
    {
        private readonly JsonParaClasse _jsonParaClasse;
        private List<PFisica> _pfisicas;
        public PFisica PFisicaEscolhida { get; set; }

        public FormListaPFisica()
        {
            InitializeComponent();
            DesabilitarCampos();
            _jsonParaClasse = new JsonParaClasse();
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
                using (var response = new StreamReader(valor.GetResponseStream()))
                {
                    string json = response.ReadToEnd();
                    return JsonConvert.DeserializeObject(json);
                }
            }
        }

        private void CarregaLista(List<PFisica> pfisicas)
        {
            HabilitarCampos();
            listViewPFisica.Items.Clear();
            listViewPFisica.View = View.Details;
            listViewPFisica.FullRowSelect = true;
            listViewPFisica.MultiSelect = false;
            foreach (var pfisica in pfisicas)
            {
                ListViewItem item = new ListViewItem(new[] { pfisica.IdPFisica.ToString(), pfisica.Nome, pfisica.Cargo.ToString(), pfisica.Endereco?.Bairro, 
                pfisica.Endereco?.Cidade,  pfisica.Endereco?.Estado, pfisica.IdPJuridica?.Nome, pfisica.Telefone1, pfisica.SituacaoCadastral.EFiliado ? "Sim" : "Não"});
                listViewPFisica.Items.Add(item);
            }
            listViewPFisica.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewPFisica.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewPFisica.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            listViewPFisica.ItemActivate += new System.EventHandler(this.listViewPFisica_DoubleClick);
        }

        private void listViewPFisica_DoubleClick(object sender, EventArgs e)
        {
            PFisicaEscolhida = _pfisicas.First(x => x.IdPFisica == Convert.ToInt32(listViewPFisica.SelectedItems[0].SubItems[0].Text));
            this.Close();
        }
        
        private void txtIdPFisica_TextChanged(object sender, EventArgs e)
        {
            listViewPFisica.Items.Clear();
            if (radioEFiliado.Checked)
            {                
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado && i.IdPFisica.ToString().StartsWith(txtIdPFisica.Text)))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            } else
            {
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado && i.IdPFisica.ToString().StartsWith(txtIdPFisica.Text)))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            listViewPFisica.Items.Clear();
            if (radioEFiliado.Checked)
            {
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado && i.Nome.Contains(txtNome.Text)))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            } else
            {
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado) && i.Nome.Contains(txtNome.Text))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            }
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            listViewPFisica.Items.Clear();
            if (radioEFiliado.Checked)
            {                
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Cidade?.Contains(txtCidade.Text) ?? false))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            } else
            {
                if (!string.IsNullOrEmpty(txtCidade.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!string.IsNullOrEmpty(txtCidade.Text) && !i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Cidade?.Contains(txtCidade.Text) ?? false))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                } else
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Cidade == null))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                }
            }
        }

        private void txtNomeIgreja_TextChanged(object sender, EventArgs e)
        {
            listViewPFisica.Items.Clear();
            if (radioEFiliado.Checked)
            {                
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => i.SituacaoCadastral.EFiliado && (i.IdPJuridica != null && (i.IdPJuridica.Nome?.Contains(txtNomeIgreja.Text) ?? false)))
                        .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            } else
            {
                if (!string.IsNullOrEmpty(txtNomeIgreja.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => !string.IsNullOrEmpty(txtNomeIgreja.Text) && !i.SituacaoCadastral.EFiliado && (i.IdPJuridica != null && (i.IdPJuridica.Nome?.Contains(txtNomeIgreja.Text) ?? false)))
                            .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                } else
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => !i.SituacaoCadastral.EFiliado && (i.IdPJuridica == null))
                            .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                }
            }
        }

        private void radioEFiliado_CheckedChanged(object sender, EventArgs e)
        {            
            if (radioEFiliado.Checked)
            {
                listViewPFisica.Items.Clear();
                if (!string.IsNullOrEmpty(txtIdPFisica.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado && i.IdPFisica.ToString().StartsWith(txtIdPFisica.Text)))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado && i.Nome.Contains(txtNome.Text)))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                if (!string.IsNullOrEmpty(txtCidade.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Cidade?.Contains(txtCidade.Text) ?? false))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                if (!string.IsNullOrEmpty(txtNomeIgreja.Text))
                {
                    listViewPFisica.Items.Clear();
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => i.SituacaoCadastral.EFiliado && (i.IdPJuridica != null && (i.IdPJuridica.Nome?.Contains(txtNomeIgreja.Text) ?? false)))
                        .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            }
        }

        private void radioNaoFiliado_CheckedChanged(object sender, EventArgs e)
        {            
            if (radioNaoFiliado.Checked)
            {
                listViewPFisica.Items.Clear();
                if (!string.IsNullOrEmpty(txtIdPFisica.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado && i.IdPFisica.ToString().StartsWith(txtIdPFisica.Text)))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                if (!string.IsNullOrEmpty(txtNome.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado && i.Nome.Contains(txtNome.Text)))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                if (!string.IsNullOrEmpty(txtCidade.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Cidade?.Contains(txtCidade.Text) ?? false))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                if (!string.IsNullOrEmpty(txtNomeIgreja.Text))
                {
                    listViewPFisica.Items.Clear();
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => !i.SituacaoCadastral.EFiliado && (i.IdPJuridica != null && (i.IdPJuridica.Nome?.Contains(txtNomeIgreja.Text) ?? false)))
                        .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                    return;
                }
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            }
        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            listViewPFisica.Items.Clear();
            if (radioEFiliado.Checked)
            {
                listViewPFisica.Items.AddRange(_pfisicas.Where(i => (i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Estado?.Contains(txtEstado.Text) ?? false))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
            }
            else
            {
                if (!string.IsNullOrEmpty(txtEstado.Text))
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!string.IsNullOrEmpty(txtEstado.Text) && !i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Estado?.Contains(txtEstado.Text) ?? false))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                }
                else
                {
                    listViewPFisica.Items.AddRange(_pfisicas.Where(i => (!i.SituacaoCadastral.EFiliado && (i.Endereco != null && (i.Endereco.Estado == null))))
                    .Select(c => new ListViewItem(new[] { c.IdPFisica.ToString(), c.Nome, c.Cargo.ToString(), c.Endereco?.Bairro, c.Endereco?.Cidade, c.Endereco?.Estado, c.IdPJuridica?.Nome, c.Telefone1, c.SituacaoCadastral.EFiliado ? "Sim" : "Não" })).ToArray());
                }
            }
        }

        private void btnGerarListaFiliadosAtivos_Click(object sender, EventArgs e)
        {
            var nomesAtivos = new Queue<string>(_pfisicas
                .Where(x => x.SituacaoCadastral.EFiliado && x.SituacaoCadastral.Condicao == CondicaoEnum.Ativo).OrderBy(x => x.Nome)
                .Select(x => x.IdPFisica + " - " + x.Nome));
            ArquivoUtil.GerarArquivoTexto(nomesAtivos);
        }

        private void btnFiliadosAtivos_Click(object sender, EventArgs e)
        {
            MessageBoxes.MostraMensagens("Carregando, clique em OK e aguarde!", "Aviso!");
            var jsonPFisicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PFisica?tipo=1&status=0"));
            _pfisicas = ((List<PFisica>)_jsonParaClasse.GetPFisicas(jsonPFisicas)).AsParallel().ToList();
            radioEFiliado.Checked = true;
            CarregaLista(_pfisicas);
            if (_pfisicas != null)
            {
                MessageBoxes.MostraMensagens("Carregado com sucesso!", "Aviso!");
            }
        }

        private void btnFiliadosOutros_Click(object sender, EventArgs e)
        {
            MessageBoxes.MostraMensagens("Carregando, clique em OK e aguarde!", "Aviso!");
            var jsonPFisicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PFisica?tipo=1&status=1"));
            _pfisicas = ((List<PFisica>)_jsonParaClasse.GetPFisicas(jsonPFisicas)).AsParallel().ToList();
            radioEFiliado.Checked = true;
            CarregaLista(_pfisicas);
            if (_pfisicas != null)
            {
                MessageBoxes.MostraMensagens("Carregado com sucesso!", "Aviso!");
            }
        }

        private void btnFiliadosTodos_Click(object sender, EventArgs e)
        {
            MessageBoxes.MostraMensagens("Carregando, clique em OK e aguarde!", "Aviso!");
            var jsonPFisicas = TransformaJson(RequisicaoMediador.RealizaRequisicaoGet(@"http://cadier.com.br/api/PFisica?tipo=0&status=0"));
            _pfisicas = ((List<PFisica>)_jsonParaClasse.GetPFisicas(jsonPFisicas)).AsParallel().ToList();
            radioEFiliado.Checked = true;
            CarregaLista(_pfisicas);
            if(_pfisicas != null)
            {
                MessageBoxes.MostraMensagens("Carregado com sucesso!", "Aviso!");
            }
        }

        private void DesabilitarCampos()
        {
            txtIdPFisica.Enabled = false;
            txtNome.Enabled = false;
            txtCidade.Enabled = false;
            txtEstado.Enabled = false;
            txtNomeIgreja.Enabled = false;
            radioEFiliado.Enabled = false;
            radioNaoFiliado.Enabled = false;
        }

        private void HabilitarCampos()
        {
            txtIdPFisica.Enabled = true;
            txtNome.Enabled = true;
            txtCidade.Enabled = true;
            txtEstado.Enabled = true;
            txtNomeIgreja.Enabled = true;
            radioEFiliado.Enabled = true;
            radioNaoFiliado.Enabled = true;
        }
    }
}