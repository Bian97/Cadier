
namespace CadierDesktop
{
    partial class FormServicosPendentes
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
            this.listViewServicosPendentes = new System.Windows.Forms.ListView();
            this.colIdOrdem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdPFísica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPago = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataPedido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataFeito = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataEntregue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewServicosPendentes
            // 
            this.listViewServicosPendentes.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewServicosPendentes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdOrdem,
            this.colIdPFísica,
            this.colServico,
            this.colValor,
            this.colPago,
            this.colResta,
            this.colDataPedido,
            this.colDataFeito,
            this.colDataEntregue});
            this.listViewServicosPendentes.HideSelection = false;
            this.listViewServicosPendentes.Location = new System.Drawing.Point(12, 77);
            this.listViewServicosPendentes.Name = "listViewServicosPendentes";
            this.listViewServicosPendentes.Size = new System.Drawing.Size(900, 506);
            this.listViewServicosPendentes.TabIndex = 2;
            this.listViewServicosPendentes.UseCompatibleStateImageBehavior = false;
            // 
            // colIdOrdem
            // 
            this.colIdOrdem.Text = "Número do Pedido";
            // 
            // colIdPFísica
            // 
            this.colIdPFísica.Text = "Número do Rol";
            // 
            // colServico
            // 
            this.colServico.Text = "Serviço";
            // 
            // colValor
            // 
            this.colValor.Text = "Valor";
            // 
            // colPago
            // 
            this.colPago.Text = "Pago";
            // 
            // colResta
            // 
            this.colResta.Text = "Resta";
            // 
            // colDataPedido
            // 
            this.colDataPedido.Text = "Data que Pediu";
            // 
            // colDataFeito
            // 
            this.colDataFeito.Text = "Data que foi feito";
            // 
            // colDataEntregue
            // 
            this.colDataEntregue.Text = "Data de entrega";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Todos os Serviços Pendentes";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(727, 26);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(113, 23);
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // FormServicosPendentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewServicosPendentes);
            this.Name = "FormServicosPendentes";
            this.Text = "FormServicosPendentes";
            this.Load += new System.EventHandler(this.FormServicosPendentes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewServicosPendentes;
        private System.Windows.Forms.ColumnHeader colIdOrdem;
        private System.Windows.Forms.ColumnHeader colIdPFísica;
        private System.Windows.Forms.ColumnHeader colServico;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colPago;
        private System.Windows.Forms.ColumnHeader colResta;
        private System.Windows.Forms.ColumnHeader colDataPedido;
        private System.Windows.Forms.ColumnHeader colDataFeito;
        private System.Windows.Forms.ColumnHeader colDataEntregue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtualizar;
    }
}