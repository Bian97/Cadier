
namespace CadierDesktop
{
    partial class FormOrdemServico
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdOrdem = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioPJuridica = new System.Windows.Forms.RadioButton();
            this.radioPFisica = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.txtServico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeposito = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblResta = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimeFeito = new System.Windows.Forms.DateTimePicker();
            this.lblFeito = new System.Windows.Forms.Label();
            this.dateTimePedido = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkFeito = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkEntregue = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimeEntregue = new System.Windows.Forms.DateTimePicker();
            this.lblEntregue = new System.Windows.Forms.Label();
            this.txtLevou = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbAtendente = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbTipoServico = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMensalidades = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnListaServico = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.dateTimeMensalidade = new System.Windows.Forms.DateTimePicker();
            this.lblMensalidade = new System.Windows.Forms.Label();
            this.dateTimeInicio = new System.Windows.Forms.DateTimePicker();
            this.lblMensalidadeInicio = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ordem de Serviço";
            // 
            // lblIdOrdem
            // 
            this.lblIdOrdem.AutoSize = true;
            this.lblIdOrdem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdOrdem.Location = new System.Drawing.Point(17, 84);
            this.lblIdOrdem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdOrdem.Name = "lblIdOrdem";
            this.lblIdOrdem.Size = new System.Drawing.Size(115, 13);
            this.lblIdOrdem.TabIndex = 5;
            this.lblIdOrdem.Text = "Número do Pedido:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(21, 138);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rol";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.radioPJuridica);
            this.panel4.Controls.Add(this.radioPFisica);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Location = new System.Drawing.Point(600, 34);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(242, 65);
            this.panel4.TabIndex = 36;
            // 
            // radioPJuridica
            // 
            this.radioPJuridica.AutoSize = true;
            this.radioPJuridica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPJuridica.Location = new System.Drawing.Point(129, 30);
            this.radioPJuridica.Margin = new System.Windows.Forms.Padding(4);
            this.radioPJuridica.Name = "radioPJuridica";
            this.radioPJuridica.Size = new System.Drawing.Size(71, 17);
            this.radioPJuridica.TabIndex = 15;
            this.radioPJuridica.TabStop = true;
            this.radioPJuridica.Text = "Jurídica";
            this.radioPJuridica.UseVisualStyleBackColor = true;
            // 
            // radioPFisica
            // 
            this.radioPFisica.AutoSize = true;
            this.radioPFisica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPFisica.Location = new System.Drawing.Point(12, 30);
            this.radioPFisica.Margin = new System.Windows.Forms.Padding(4);
            this.radioPFisica.Name = "radioPFisica";
            this.radioPFisica.Size = new System.Drawing.Size(60, 17);
            this.radioPFisica.TabIndex = 14;
            this.radioPFisica.TabStop = true;
            this.radioPFisica.Text = "Física";
            this.radioPFisica.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 2);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(162, 13);
            this.label23.TabIndex = 13;
            this.label23.Text = "Pessoa Física ou Jurídica?";
            // 
            // txtServico
            // 
            this.txtServico.Location = new System.Drawing.Point(21, 201);
            this.txtServico.Margin = new System.Windows.Forms.Padding(4);
            this.txtServico.Name = "txtServico";
            this.txtServico.Size = new System.Drawing.Size(509, 22);
            this.txtServico.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Serviço";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(20, 270);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(132, 22);
            this.txtValor.TabIndex = 40;
            this.txtValor.Text = "0";
            this.txtValor.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 249);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Valor";
            // 
            // txtPago
            // 
            this.txtPago.Location = new System.Drawing.Point(197, 270);
            this.txtPago.Margin = new System.Windows.Forms.Padding(4);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(132, 22);
            this.txtPago.TabIndex = 42;
            this.txtPago.Text = "0";
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(193, 249);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Pago";
            // 
            // txtCredito
            // 
            this.txtCredito.Location = new System.Drawing.Point(367, 270);
            this.txtCredito.Margin = new System.Windows.Forms.Padding(4);
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.Size = new System.Drawing.Size(132, 22);
            this.txtCredito.TabIndex = 44;
            this.txtCredito.Text = "0";
            this.txtCredito.TextChanged += new System.EventHandler(this.txtCredito_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(363, 249);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Crédito Anterior";
            // 
            // txtDeposito
            // 
            this.txtDeposito.Location = new System.Drawing.Point(539, 270);
            this.txtDeposito.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeposito.Name = "txtDeposito";
            this.txtDeposito.Size = new System.Drawing.Size(132, 22);
            this.txtDeposito.TabIndex = 46;
            this.txtDeposito.Text = "0";
            this.txtDeposito.TextChanged += new System.EventHandler(this.txtDeposito_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(535, 249);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Depósito";
            // 
            // lblResta
            // 
            this.lblResta.AutoSize = true;
            this.lblResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResta.Location = new System.Drawing.Point(723, 270);
            this.lblResta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResta.Name = "lblResta";
            this.lblResta.Size = new System.Drawing.Size(44, 13);
            this.lblResta.TabIndex = 47;
            this.lblResta.Text = "Resta:";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(20, 354);
            this.txtObs.Margin = new System.Windows.Forms.Padding(4);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(1143, 207);
            this.txtObs.TabIndex = 49;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 334);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Observações";
            // 
            // dateTimeFeito
            // 
            this.dateTimeFeito.CustomFormat = "dd/MM/yyyy";
            this.dateTimeFeito.Enabled = false;
            this.dateTimeFeito.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFeito.Location = new System.Drawing.Point(141, 63);
            this.dateTimeFeito.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeFeito.Name = "dateTimeFeito";
            this.dateTimeFeito.Size = new System.Drawing.Size(157, 22);
            this.dateTimeFeito.TabIndex = 53;
            // 
            // lblFeito
            // 
            this.lblFeito.AutoSize = true;
            this.lblFeito.Enabled = false;
            this.lblFeito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeito.Location = new System.Drawing.Point(137, 43);
            this.lblFeito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFeito.Name = "lblFeito";
            this.lblFeito.Size = new System.Drawing.Size(106, 13);
            this.lblFeito.TabIndex = 52;
            this.lblFeito.Text = "Data que foi feito";
            // 
            // dateTimePedido
            // 
            this.dateTimePedido.CustomFormat = "dd/MM/yyyy";
            this.dateTimePedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePedido.Location = new System.Drawing.Point(21, 618);
            this.dateTimePedido.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePedido.Name = "dateTimePedido";
            this.dateTimePedido.Size = new System.Drawing.Size(157, 22);
            this.dateTimePedido.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 598);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Data do Pedido";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkFeito);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dateTimeFeito);
            this.panel1.Controls.Add(this.lblFeito);
            this.panel1.Location = new System.Drawing.Point(247, 577);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 93);
            this.panel1.TabIndex = 56;
            // 
            // checkFeito
            // 
            this.checkFeito.AutoSize = true;
            this.checkFeito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFeito.Location = new System.Drawing.Point(21, 46);
            this.checkFeito.Margin = new System.Windows.Forms.Padding(4);
            this.checkFeito.Name = "checkFeito";
            this.checkFeito.Size = new System.Drawing.Size(46, 17);
            this.checkFeito.TabIndex = 65;
            this.checkFeito.Text = "Sim";
            this.checkFeito.UseVisualStyleBackColor = true;
            this.checkFeito.CheckedChanged += new System.EventHandler(this.checkFeito_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 2);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "O produto foi confeccionado?";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkEntregue);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dateTimeEntregue);
            this.panel2.Controls.Add(this.lblEntregue);
            this.panel2.Location = new System.Drawing.Point(684, 577);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 93);
            this.panel2.TabIndex = 57;
            // 
            // checkEntregue
            // 
            this.checkEntregue.AutoSize = true;
            this.checkEntregue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEntregue.Location = new System.Drawing.Point(12, 46);
            this.checkEntregue.Margin = new System.Windows.Forms.Padding(4);
            this.checkEntregue.Name = "checkEntregue";
            this.checkEntregue.Size = new System.Drawing.Size(46, 17);
            this.checkEntregue.TabIndex = 66;
            this.checkEntregue.Text = "Sim";
            this.checkEntregue.UseVisualStyleBackColor = true;
            this.checkEntregue.CheckedChanged += new System.EventHandler(this.checkEntregue_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 2);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "O produto foi entregue?";
            // 
            // dateTimeEntregue
            // 
            this.dateTimeEntregue.CustomFormat = "dd/MM/yyyy";
            this.dateTimeEntregue.Enabled = false;
            this.dateTimeEntregue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeEntregue.Location = new System.Drawing.Point(141, 63);
            this.dateTimeEntregue.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeEntregue.Name = "dateTimeEntregue";
            this.dateTimeEntregue.Size = new System.Drawing.Size(157, 22);
            this.dateTimeEntregue.TabIndex = 53;
            // 
            // lblEntregue
            // 
            this.lblEntregue.AutoSize = true;
            this.lblEntregue.Enabled = false;
            this.lblEntregue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntregue.Location = new System.Drawing.Point(137, 43);
            this.lblEntregue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntregue.Name = "lblEntregue";
            this.lblEntregue.Size = new System.Drawing.Size(131, 13);
            this.lblEntregue.TabIndex = 52;
            this.lblEntregue.Text = "Data que foi entregue";
            // 
            // txtLevou
            // 
            this.txtLevou.Location = new System.Drawing.Point(20, 687);
            this.txtLevou.Margin = new System.Windows.Forms.Padding(4);
            this.txtLevou.Name = "txtLevou";
            this.txtLevou.Size = new System.Drawing.Size(509, 22);
            this.txtLevou.TabIndex = 59;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 666);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Quem levou";
            // 
            // cmbAtendente
            // 
            this.cmbAtendente.FormattingEnabled = true;
            this.cmbAtendente.Location = new System.Drawing.Point(260, 137);
            this.cmbAtendente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAtendente.Name = "cmbAtendente";
            this.cmbAtendente.Size = new System.Drawing.Size(160, 24);
            this.cmbAtendente.TabIndex = 61;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(260, 118);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(65, 13);
            this.label24.TabIndex = 60;
            this.label24.Text = "Atendente";
            // 
            // cmbTipoServico
            // 
            this.cmbTipoServico.FormattingEnabled = true;
            this.cmbTipoServico.Location = new System.Drawing.Point(596, 199);
            this.cmbTipoServico.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoServico.Name = "cmbTipoServico";
            this.cmbTipoServico.Size = new System.Drawing.Size(160, 24);
            this.cmbTipoServico.TabIndex = 63;
            this.cmbTipoServico.SelectedIndexChanged += new System.EventHandler(this.cmbTipoServico_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(596, 181);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "Tipo de Serviço";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnMensalidades);
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Controls.Add(this.btnListaServico);
            this.panel3.Controls.Add(this.btnAlterar);
            this.panel3.Controls.Add(this.btnInserir);
            this.panel3.Location = new System.Drawing.Point(997, 15);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 173);
            this.panel3.TabIndex = 64;
            // 
            // btnMensalidades
            // 
            this.btnMensalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMensalidades.Location = new System.Drawing.Point(32, 102);
            this.btnMensalidades.Margin = new System.Windows.Forms.Padding(4);
            this.btnMensalidades.Name = "btnMensalidades";
            this.btnMensalidades.Size = new System.Drawing.Size(151, 28);
            this.btnMensalidades.TabIndex = 14;
            this.btnMensalidades.Text = "Mensalidades";
            this.btnMensalidades.UseVisualStyleBackColor = true;
            this.btnMensalidades.Click += new System.EventHandler(this.btnMensalidades_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(32, 132);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(151, 28);
            this.btnLimpar.TabIndex = 13;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnListaServico
            // 
            this.btnListaServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaServico.Location = new System.Drawing.Point(32, 73);
            this.btnListaServico.Margin = new System.Windows.Forms.Padding(4);
            this.btnListaServico.Name = "btnListaServico";
            this.btnListaServico.Size = new System.Drawing.Size(151, 28);
            this.btnListaServico.TabIndex = 12;
            this.btnListaServico.Text = "Listar Serviços";
            this.btnListaServico.UseVisualStyleBackColor = true;
            this.btnListaServico.Click += new System.EventHandler(this.btnListaServico_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(32, 41);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(151, 28);
            this.btnAlterar.TabIndex = 11;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.Location = new System.Drawing.Point(32, 9);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(4);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(151, 28);
            this.btnInserir.TabIndex = 10;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // dateTimeMensalidade
            // 
            this.dateTimeMensalidade.CustomFormat = "MM/yyyy";
            this.dateTimeMensalidade.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeMensalidade.Location = new System.Drawing.Point(789, 201);
            this.dateTimeMensalidade.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeMensalidade.Name = "dateTimeMensalidade";
            this.dateTimeMensalidade.ShowUpDown = true;
            this.dateTimeMensalidade.Size = new System.Drawing.Size(157, 22);
            this.dateTimeMensalidade.TabIndex = 66;
            this.dateTimeMensalidade.ValueChanged += new System.EventHandler(this.dateTimeMensalidade_ValueChanged);
            // 
            // lblMensalidade
            // 
            this.lblMensalidade.AutoSize = true;
            this.lblMensalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensalidade.Location = new System.Drawing.Point(785, 181);
            this.lblMensalidade.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensalidade.Name = "lblMensalidade";
            this.lblMensalidade.Size = new System.Drawing.Size(104, 13);
            this.lblMensalidade.TabIndex = 65;
            this.lblMensalidade.Text = "Mensalidade até:";
            // 
            // dateTimeInicio
            // 
            this.dateTimeInicio.CustomFormat = "MM/yyyy";
            this.dateTimeInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeInicio.Location = new System.Drawing.Point(789, 138);
            this.dateTimeInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimeInicio.Name = "dateTimeInicio";
            this.dateTimeInicio.ShowUpDown = true;
            this.dateTimeInicio.Size = new System.Drawing.Size(157, 22);
            this.dateTimeInicio.TabIndex = 68;
            // 
            // lblMensalidadeInicio
            // 
            this.lblMensalidadeInicio.AutoSize = true;
            this.lblMensalidadeInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensalidadeInicio.Location = new System.Drawing.Point(785, 118);
            this.lblMensalidadeInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensalidadeInicio.Name = "lblMensalidadeInicio";
            this.lblMensalidadeInicio.Size = new System.Drawing.Size(100, 13);
            this.lblMensalidadeInicio.TabIndex = 67;
            this.lblMensalidadeInicio.Text = "Mensalidade de:";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(785, 239);
            this.lblValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(127, 13);
            this.lblValor.TabIndex = 69;
            this.lblValor.Text = "Valor à Acrescentar: ";
            // 
            // FormOrdemServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 752);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.dateTimeInicio);
            this.Controls.Add(this.lblMensalidadeInicio);
            this.Controls.Add(this.dateTimeMensalidade);
            this.Controls.Add(this.lblMensalidade);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cmbTipoServico);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbAtendente);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtLevou);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateTimePedido);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblResta);
            this.Controls.Add(this.txtDeposito);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCredito);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIdOrdem);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormOrdemServico";
            this.Text = "FormOrdemServico";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIdOrdem;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioPJuridica;
        private System.Windows.Forms.RadioButton radioPFisica;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtServico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCredito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeposito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblResta;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimeFeito;
        private System.Windows.Forms.Label lblFeito;
        private System.Windows.Forms.DateTimePicker dateTimePedido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimeEntregue;
        private System.Windows.Forms.Label lblEntregue;
        private System.Windows.Forms.TextBox txtLevou;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbAtendente;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cmbTipoServico;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnListaServico;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.CheckBox checkFeito;
        private System.Windows.Forms.CheckBox checkEntregue;
        private System.Windows.Forms.Button btnMensalidades;
        private System.Windows.Forms.DateTimePicker dateTimeMensalidade;
        private System.Windows.Forms.Label lblMensalidade;
        private System.Windows.Forms.DateTimePicker dateTimeInicio;
        private System.Windows.Forms.Label lblMensalidadeInicio;
        private System.Windows.Forms.Label lblValor;
    }
}