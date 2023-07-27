
namespace Cadier.Desktop
{
    partial class FormListaOrdem
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
            this.listViewOrdem = new System.Windows.Forms.ListView();
            this.colIdOrdem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdPFísica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPago = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataPedido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataFeito = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataEntregue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.dateTimeReuniao = new System.Windows.Forms.DateTimePicker();
            this.lblReuniao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewOrdem
            // 
            this.listViewOrdem.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewOrdem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdOrdem,
            this.colIdPFísica,
            this.colServico,
            this.colValor,
            this.colPago,
            this.colResta,
            this.colDataPedido,
            this.colDataFeito,
            this.colDataEntregue});
            this.listViewOrdem.HideSelection = false;
            this.listViewOrdem.Location = new System.Drawing.Point(12, 71);
            this.listViewOrdem.Name = "listViewOrdem";
            this.listViewOrdem.Size = new System.Drawing.Size(900, 506);
            this.listViewOrdem.TabIndex = 1;
            this.listViewOrdem.UseCompatibleStateImageBehavior = false;
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
            // btnAtualizar
            // 
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.Location = new System.Drawing.Point(397, 12);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(113, 23);
            this.btnAtualizar.TabIndex = 11;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Visible = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // dateTimeReuniao
            // 
            this.dateTimeReuniao.CustomFormat = "dd/MM/yyyy";
            this.dateTimeReuniao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeReuniao.Location = new System.Drawing.Point(12, 32);
            this.dateTimeReuniao.Name = "dateTimeReuniao";
            this.dateTimeReuniao.Size = new System.Drawing.Size(119, 20);
            this.dateTimeReuniao.TabIndex = 18;
            this.dateTimeReuniao.Visible = false;
            // 
            // lblReuniao
            // 
            this.lblReuniao.AutoSize = true;
            this.lblReuniao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReuniao.Location = new System.Drawing.Point(9, 16);
            this.lblReuniao.Name = "lblReuniao";
            this.lblReuniao.Size = new System.Drawing.Size(103, 13);
            this.lblReuniao.TabIndex = 17;
            this.lblReuniao.Text = "Data de Reunião";
            this.lblReuniao.Visible = false;
            // 
            // FormListaOrdem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 611);
            this.Controls.Add(this.dateTimeReuniao);
            this.Controls.Add(this.lblReuniao);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.listViewOrdem);
            this.Name = "FormListaOrdem";
            this.Text = "FormListaOrdem";
            this.Activated += new System.EventHandler(this.FormListaOrdem_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewOrdem;
        private System.Windows.Forms.ColumnHeader colIdOrdem;
        private System.Windows.Forms.ColumnHeader colIdPFísica;
        private System.Windows.Forms.ColumnHeader colServico;
        private System.Windows.Forms.ColumnHeader colValor;
        private System.Windows.Forms.ColumnHeader colPago;
        private System.Windows.Forms.ColumnHeader colResta;
        private System.Windows.Forms.ColumnHeader colDataPedido;
        private System.Windows.Forms.ColumnHeader colDataFeito;
        private System.Windows.Forms.ColumnHeader colDataEntregue;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DateTimePicker dateTimeReuniao;
        private System.Windows.Forms.Label lblReuniao;
    }
}