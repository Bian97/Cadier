namespace Cadier.Desktop
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuOp = new System.Windows.Forms.MenuStrip();
            this.menuItemFerramentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAtualizaBase = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoaFisicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoaJurídicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarMúltiplosDocumentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumoReuniãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosOsServicosPendentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuOp
            // 
            this.menuOp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuOp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFerramentas,
            this.pessoaFisicaToolStripMenuItem,
            this.pessoaJurídicaToolStripMenuItem,
            this.gerarMúltiplosDocumentosToolStripMenuItem,
            this.resumoReuniãoToolStripMenuItem,
            this.todosOsServicosPendentesToolStripMenuItem});
            this.menuOp.Location = new System.Drawing.Point(0, 0);
            this.menuOp.Name = "menuOp";
            this.menuOp.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuOp.Size = new System.Drawing.Size(924, 24);
            this.menuOp.TabIndex = 0;
            this.menuOp.Text = "Ferramentas";
            // 
            // menuItemFerramentas
            // 
            this.menuItemFerramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAtualizaBase});
            this.menuItemFerramentas.Name = "menuItemFerramentas";
            this.menuItemFerramentas.Size = new System.Drawing.Size(84, 20);
            this.menuItemFerramentas.Text = "Ferramentas";
            // 
            // menuAtualizaBase
            // 
            this.menuAtualizaBase.Name = "menuAtualizaBase";
            this.menuAtualizaBase.Size = new System.Drawing.Size(185, 22);
            this.menuAtualizaBase.Text = "Atualizar a base nova";
            this.menuAtualizaBase.Click += new System.EventHandler(this.menuAtualizaBase_Click);
            // 
            // pessoaFisicaToolStripMenuItem
            // 
            this.pessoaFisicaToolStripMenuItem.Name = "pessoaFisicaToolStripMenuItem";
            this.pessoaFisicaToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.pessoaFisicaToolStripMenuItem.Text = "Pessoa Fisica";
            this.pessoaFisicaToolStripMenuItem.Click += new System.EventHandler(this.pessoaFisicaToolStripMenuItem_Click);
            // 
            // pessoaJurídicaToolStripMenuItem
            // 
            this.pessoaJurídicaToolStripMenuItem.Name = "pessoaJurídicaToolStripMenuItem";
            this.pessoaJurídicaToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.pessoaJurídicaToolStripMenuItem.Text = "Pessoa Jurídica";
            this.pessoaJurídicaToolStripMenuItem.Click += new System.EventHandler(this.pessoaJurídicaToolStripMenuItem_Click);
            // 
            // gerarMúltiplosDocumentosToolStripMenuItem
            // 
            this.gerarMúltiplosDocumentosToolStripMenuItem.Name = "gerarMúltiplosDocumentosToolStripMenuItem";
            this.gerarMúltiplosDocumentosToolStripMenuItem.Size = new System.Drawing.Size(171, 20);
            this.gerarMúltiplosDocumentosToolStripMenuItem.Text = "Gerar Múltiplos Documentos";
            this.gerarMúltiplosDocumentosToolStripMenuItem.Click += new System.EventHandler(this.gerarMúltiplosDocumentosToolStripMenuItem_Click);
            // 
            // resumoReuniãoToolStripMenuItem
            // 
            this.resumoReuniãoToolStripMenuItem.Name = "resumoReuniãoToolStripMenuItem";
            this.resumoReuniãoToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.resumoReuniãoToolStripMenuItem.Text = "Resumo Reunião";
            this.resumoReuniãoToolStripMenuItem.Click += new System.EventHandler(this.resumoReuniãoToolStripMenuItem_Click);
            // 
            // todosOsServicosPendentesToolStripMenuItem
            // 
            this.todosOsServicosPendentesToolStripMenuItem.Name = "todosOsServicosPendentesToolStripMenuItem";
            this.todosOsServicosPendentesToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.todosOsServicosPendentesToolStripMenuItem.Text = "Todos os Serviços Pendentes";
            this.todosOsServicosPendentesToolStripMenuItem.Click += new System.EventHandler(this.todosOsServicosPendentesToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.menuOp);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuOp;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.menuOp.ResumeLayout(false);
            this.menuOp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuOp;
        private System.Windows.Forms.ToolStripMenuItem menuItemFerramentas;
        private System.Windows.Forms.ToolStripMenuItem menuAtualizaBase;
        private System.Windows.Forms.ToolStripMenuItem pessoaFisicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pessoaJurídicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarMúltiplosDocumentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumoReuniãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosOsServicosPendentesToolStripMenuItem;
    }
}

