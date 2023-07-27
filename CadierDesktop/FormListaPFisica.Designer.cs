
namespace CadierDesktop
{
    partial class FormListaPFisica
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
            this.txtNomeIgreja = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdPFisica = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewPFisica = new System.Windows.Forms.ListView();
            this.colIdPFisica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCargo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBairro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIgreja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFiliado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.radioNaoFiliado = new System.Windows.Forms.RadioButton();
            this.radioEFiliado = new System.Windows.Forms.RadioButton();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGerarListaFiliadosAtivos = new System.Windows.Forms.Button();
            this.btnFiliadosAtivos = new System.Windows.Forms.Button();
            this.btnFiliadosOutros = new System.Windows.Forms.Button();
            this.btnFiliadosTodos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNomeIgreja
            // 
            this.txtNomeIgreja.Location = new System.Drawing.Point(672, 42);
            this.txtNomeIgreja.Name = "txtNomeIgreja";
            this.txtNomeIgreja.Size = new System.Drawing.Size(221, 20);
            this.txtNomeIgreja.TabIndex = 21;
            this.txtNomeIgreja.TextChanged += new System.EventHandler(this.txtNomeIgreja_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(669, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Igreja";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(407, 42);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(100, 20);
            this.txtCidade.TabIndex = 19;
            this.txtCidade.TextChanged += new System.EventHandler(this.txtCidade_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(404, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cidade";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(163, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(213, 20);
            this.txtNome.TabIndex = 17;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nome";
            // 
            // txtIdPFisica
            // 
            this.txtIdPFisica.Location = new System.Drawing.Point(20, 42);
            this.txtIdPFisica.Name = "txtIdPFisica";
            this.txtIdPFisica.Size = new System.Drawing.Size(100, 20);
            this.txtIdPFisica.TabIndex = 15;
            this.txtIdPFisica.TextChanged += new System.EventHandler(this.txtIdPFisica_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Rol";
            // 
            // listViewPFisica
            // 
            this.listViewPFisica.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewPFisica.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdPFisica,
            this.colNome,
            this.colCargo,
            this.colBairro,
            this.colCidade,
            this.colEstado,
            this.colIgreja,
            this.colTelefone,
            this.colFiliado});
            this.listViewPFisica.HideSelection = false;
            this.listViewPFisica.Location = new System.Drawing.Point(20, 106);
            this.listViewPFisica.Name = "listViewPFisica";
            this.listViewPFisica.Size = new System.Drawing.Size(888, 480);
            this.listViewPFisica.TabIndex = 13;
            this.listViewPFisica.UseCompatibleStateImageBehavior = false;
            // 
            // colIdPFisica
            // 
            this.colIdPFisica.Text = "Rol";
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            // 
            // colCargo
            // 
            this.colCargo.Text = "Cargo";
            // 
            // colBairro
            // 
            this.colBairro.Text = "Bairro";
            // 
            // colCidade
            // 
            this.colCidade.Text = "Cidade";
            // 
            // colEstado
            // 
            this.colEstado.Text = "Estado";
            // 
            // colIgreja
            // 
            this.colIgreja.Text = "Igreja";
            // 
            // colTelefone
            // 
            this.colTelefone.Text = "Telefone";
            // 
            // colFiliado
            // 
            this.colFiliado.Text = "Filiado?";
            // 
            // radioNaoFiliado
            // 
            this.radioNaoFiliado.AutoSize = true;
            this.radioNaoFiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNaoFiliado.Location = new System.Drawing.Point(816, 83);
            this.radioNaoFiliado.Name = "radioNaoFiliado";
            this.radioNaoFiliado.Size = new System.Drawing.Size(89, 17);
            this.radioNaoFiliado.TabIndex = 23;
            this.radioNaoFiliado.TabStop = true;
            this.radioNaoFiliado.Text = "Não Filiado";
            this.radioNaoFiliado.UseVisualStyleBackColor = true;
            this.radioNaoFiliado.CheckedChanged += new System.EventHandler(this.radioNaoFiliado_CheckedChanged);
            // 
            // radioEFiliado
            // 
            this.radioEFiliado.AutoSize = true;
            this.radioEFiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEFiliado.Location = new System.Drawing.Point(728, 84);
            this.radioEFiliado.Name = "radioEFiliado";
            this.radioEFiliado.Size = new System.Drawing.Size(62, 17);
            this.radioEFiliado.TabIndex = 22;
            this.radioEFiliado.TabStop = true;
            this.radioEFiliado.Text = "Filiado";
            this.radioEFiliado.UseVisualStyleBackColor = true;
            this.radioEFiliado.CheckedChanged += new System.EventHandler(this.radioEFiliado_CheckedChanged);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(541, 42);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(100, 20);
            this.txtEstado.TabIndex = 25;
            this.txtEstado.TextChanged += new System.EventHandler(this.txtEstado_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(538, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Estado";
            // 
            // btnGerarListaFiliadosAtivos
            // 
            this.btnGerarListaFiliadosAtivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarListaFiliadosAtivos.Location = new System.Drawing.Point(358, 587);
            this.btnGerarListaFiliadosAtivos.Name = "btnGerarListaFiliadosAtivos";
            this.btnGerarListaFiliadosAtivos.Size = new System.Drawing.Size(206, 23);
            this.btnGerarListaFiliadosAtivos.TabIndex = 28;
            this.btnGerarListaFiliadosAtivos.Text = "Gerar Lista de Filiados Ativos";
            this.btnGerarListaFiliadosAtivos.UseVisualStyleBackColor = true;
            this.btnGerarListaFiliadosAtivos.Click += new System.EventHandler(this.btnGerarListaFiliadosAtivos_Click);
            // 
            // btnFiliadosAtivos
            // 
            this.btnFiliadosAtivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiliadosAtivos.Location = new System.Drawing.Point(20, 77);
            this.btnFiliadosAtivos.Name = "btnFiliadosAtivos";
            this.btnFiliadosAtivos.Size = new System.Drawing.Size(164, 23);
            this.btnFiliadosAtivos.TabIndex = 29;
            this.btnFiliadosAtivos.Text = "Listar Filiados Ativos";
            this.btnFiliadosAtivos.UseVisualStyleBackColor = true;
            this.btnFiliadosAtivos.Click += new System.EventHandler(this.btnFiliadosAtivos_Click);
            // 
            // btnFiliadosOutros
            // 
            this.btnFiliadosOutros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiliadosOutros.Location = new System.Drawing.Point(190, 77);
            this.btnFiliadosOutros.Name = "btnFiliadosOutros";
            this.btnFiliadosOutros.Size = new System.Drawing.Size(168, 23);
            this.btnFiliadosOutros.TabIndex = 30;
            this.btnFiliadosOutros.Text = "Listar Filiados Não Ativos";
            this.btnFiliadosOutros.UseVisualStyleBackColor = true;
            this.btnFiliadosOutros.Click += new System.EventHandler(this.btnFiliadosOutros_Click);
            // 
            // btnFiliadosTodos
            // 
            this.btnFiliadosTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiliadosTodos.Location = new System.Drawing.Point(364, 77);
            this.btnFiliadosTodos.Name = "btnFiliadosTodos";
            this.btnFiliadosTodos.Size = new System.Drawing.Size(164, 23);
            this.btnFiliadosTodos.TabIndex = 31;
            this.btnFiliadosTodos.Text = "Listar Todos os Filiados";
            this.btnFiliadosTodos.UseVisualStyleBackColor = true;
            this.btnFiliadosTodos.Click += new System.EventHandler(this.btnFiliadosTodos_Click);
            // 
            // FormListaPFisica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 611);
            this.Controls.Add(this.btnFiliadosTodos);
            this.Controls.Add(this.btnFiliadosOutros);
            this.Controls.Add(this.btnFiliadosAtivos);
            this.Controls.Add(this.btnGerarListaFiliadosAtivos);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioNaoFiliado);
            this.Controls.Add(this.radioEFiliado);
            this.Controls.Add(this.txtNomeIgreja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdPFisica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewPFisica);
            this.Name = "FormListaPFisica";
            this.Text = "FormListaPFisica";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeIgreja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdPFisica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewPFisica;
        private System.Windows.Forms.ColumnHeader colIdPFisica;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.ColumnHeader colBairro;
        private System.Windows.Forms.ColumnHeader colCidade;
        private System.Windows.Forms.ColumnHeader colEstado;
        private System.Windows.Forms.ColumnHeader colCargo;
        private System.Windows.Forms.ColumnHeader colIgreja;
        private System.Windows.Forms.ColumnHeader colTelefone;
        private System.Windows.Forms.ColumnHeader colFiliado;
        private System.Windows.Forms.RadioButton radioNaoFiliado;
        private System.Windows.Forms.RadioButton radioEFiliado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGerarListaFiliadosAtivos;
        private System.Windows.Forms.Button btnFiliadosAtivos;
        private System.Windows.Forms.Button btnFiliadosOutros;
        private System.Windows.Forms.Button btnFiliadosTodos;
    }
}