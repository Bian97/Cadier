
namespace CadierDesktop
{
    partial class FormListaPJuridica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewPJuridica = new System.Windows.Forms.ListView();
            this.colIdPJuridica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdPresidente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNomePresidente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBairro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtIdPJuridica = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeIgreja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdPFisicaPresidente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomePrPresidente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGerarListaIgrejasFiliadasAtivas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewPJuridica
            // 
            this.listViewPJuridica.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewPJuridica.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdPJuridica,
            this.colNome,
            this.colIdPresidente,
            this.colNomePresidente,
            this.colBairro,
            this.colCidade});
            this.listViewPJuridica.HideSelection = false;
            this.listViewPJuridica.Location = new System.Drawing.Point(15, 106);
            this.listViewPJuridica.Name = "listViewPJuridica";
            this.listViewPJuridica.Size = new System.Drawing.Size(888, 480);
            this.listViewPJuridica.TabIndex = 0;
            this.listViewPJuridica.UseCompatibleStateImageBehavior = false;
            // 
            // colIdPJuridica
            // 
            this.colIdPJuridica.Text = "Rol";
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            // 
            // colIdPresidente
            // 
            this.colIdPresidente.Text = "Rol Presidente";
            // 
            // colNomePresidente
            // 
            this.colNomePresidente.Text = "Nome do Presidente";
            // 
            // colBairro
            // 
            this.colBairro.Text = "Bairro";
            // 
            // colCidade
            // 
            this.colCidade.Text = "Cidade";
            // 
            // txtIdPJuridica
            // 
            this.txtIdPJuridica.Location = new System.Drawing.Point(15, 42);
            this.txtIdPJuridica.Name = "txtIdPJuridica";
            this.txtIdPJuridica.Size = new System.Drawing.Size(100, 20);
            this.txtIdPJuridica.TabIndex = 6;
            this.txtIdPJuridica.TextChanged += new System.EventHandler(this.txtIdPJuridica_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rol";
            // 
            // txtNomeIgreja
            // 
            this.txtNomeIgreja.Location = new System.Drawing.Point(158, 42);
            this.txtNomeIgreja.Name = "txtNomeIgreja";
            this.txtNomeIgreja.Size = new System.Drawing.Size(213, 20);
            this.txtNomeIgreja.TabIndex = 8;
            this.txtNomeIgreja.TextChanged += new System.EventHandler(this.txtNomeIgreja_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome da Igreja";
            // 
            // txtIdPFisicaPresidente
            // 
            this.txtIdPFisicaPresidente.Location = new System.Drawing.Point(437, 42);
            this.txtIdPFisicaPresidente.Name = "txtIdPFisicaPresidente";
            this.txtIdPFisicaPresidente.Size = new System.Drawing.Size(100, 20);
            this.txtIdPFisicaPresidente.TabIndex = 10;
            this.txtIdPFisicaPresidente.TextChanged += new System.EventHandler(this.txtIdPFisicaPresidente_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(434, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rol do Pr Presidente";
            // 
            // txtNomePrPresidente
            // 
            this.txtNomePrPresidente.Location = new System.Drawing.Point(593, 42);
            this.txtNomePrPresidente.Name = "txtNomePrPresidente";
            this.txtNomePrPresidente.Size = new System.Drawing.Size(221, 20);
            this.txtNomePrPresidente.TabIndex = 12;
            this.txtNomePrPresidente.TextChanged += new System.EventHandler(this.txtNomePrPresidente_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(590, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nome do Pr Presidente";
            // 
            // btnGerarListaIgrejasFiliadasAtivas
            // 
            this.btnGerarListaIgrejasFiliadasAtivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarListaIgrejasFiliadasAtivas.Location = new System.Drawing.Point(358, 587);
            this.btnGerarListaIgrejasFiliadasAtivas.Name = "btnGerarListaIgrejasFiliadasAtivas";
            this.btnGerarListaIgrejasFiliadasAtivas.Size = new System.Drawing.Size(206, 23);
            this.btnGerarListaIgrejasFiliadasAtivas.TabIndex = 29;
            this.btnGerarListaIgrejasFiliadasAtivas.Text = "Gerar Lista de Igrejas Filiadas Ativas";
            this.btnGerarListaIgrejasFiliadasAtivas.UseVisualStyleBackColor = true;
            this.btnGerarListaIgrejasFiliadasAtivas.Click += new System.EventHandler(this.btnGerarListaIgrejasFiliadasAtivas_Click);
            // 
            // FormListaPJuridica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 611);
            this.Controls.Add(this.btnGerarListaIgrejasFiliadasAtivas);
            this.Controls.Add(this.txtNomePrPresidente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdPFisicaPresidente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeIgreja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdPJuridica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewPJuridica);
            this.Name = "FormListaPJuridica";
            this.Text = "FormListaPJuridica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewPJuridica;
        private System.Windows.Forms.ColumnHeader colIdPJuridica;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colIdPresidente;
        private System.Windows.Forms.ColumnHeader colNomePresidente;
        private System.Windows.Forms.ColumnHeader colBairro;
        private System.Windows.Forms.ColumnHeader colCidade;
        private System.Windows.Forms.TextBox txtIdPJuridica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeIgreja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdPFisicaPresidente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomePrPresidente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGerarListaIgrejasFiliadasAtivas;
    }
}