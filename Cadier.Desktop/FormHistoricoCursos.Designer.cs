
namespace Cadier.Desktop
{
    partial class FormHistoricoCursos
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkFormou = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimeFormatura = new System.Windows.Forms.DateTimePicker();
            this.lblFormatura = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkLevou = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimeLevou = new System.Windows.Forms.DateTimePicker();
            this.lblLevou = new System.Windows.Forms.Label();
            this.lblIdCurso = new System.Windows.Forms.Label();
            this.txtIdPFisica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurso = new System.Windows.Forms.TextBox();
            this.txtRestaPagar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePagamento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnListaCursos = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Histórico de Cursos";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkFormou);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dateTimeFormatura);
            this.panel2.Controls.Add(this.lblFormatura);
            this.panel2.Location = new System.Drawing.Point(306, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 76);
            this.panel2.TabIndex = 60;
            // 
            // checkFormou
            // 
            this.checkFormou.AutoSize = true;
            this.checkFormou.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFormou.Location = new System.Drawing.Point(9, 37);
            this.checkFormou.Name = "checkFormou";
            this.checkFormou.Size = new System.Drawing.Size(46, 17);
            this.checkFormou.TabIndex = 66;
            this.checkFormou.Text = "Sim";
            this.checkFormou.UseVisualStyleBackColor = true;
            this.checkFormou.CheckedChanged += new System.EventHandler(this.checkFormou_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Se formou?";
            // 
            // dateTimeFormatura
            // 
            this.dateTimeFormatura.CustomFormat = "dd/MM/yyyy";
            this.dateTimeFormatura.Enabled = false;
            this.dateTimeFormatura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFormatura.Location = new System.Drawing.Point(106, 51);
            this.dateTimeFormatura.Name = "dateTimeFormatura";
            this.dateTimeFormatura.Size = new System.Drawing.Size(119, 20);
            this.dateTimeFormatura.TabIndex = 53;
            // 
            // lblFormatura
            // 
            this.lblFormatura.AutoSize = true;
            this.lblFormatura.Enabled = false;
            this.lblFormatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatura.Location = new System.Drawing.Point(103, 35);
            this.lblFormatura.Name = "lblFormatura";
            this.lblFormatura.Size = new System.Drawing.Size(109, 13);
            this.lblFormatura.TabIndex = 52;
            this.lblFormatura.Text = "Data de formatura";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkLevou);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dateTimeLevou);
            this.panel1.Controls.Add(this.lblLevou);
            this.panel1.Location = new System.Drawing.Point(16, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 76);
            this.panel1.TabIndex = 59;
            // 
            // checkLevou
            // 
            this.checkLevou.AutoSize = true;
            this.checkLevou.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkLevou.Location = new System.Drawing.Point(16, 37);
            this.checkLevou.Name = "checkLevou";
            this.checkLevou.Size = new System.Drawing.Size(46, 17);
            this.checkLevou.TabIndex = 65;
            this.checkLevou.Text = "Sim";
            this.checkLevou.UseVisualStyleBackColor = true;
            this.checkLevou.CheckedChanged += new System.EventHandler(this.checkLevou_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Levou Certificado?";
            // 
            // dateTimeLevou
            // 
            this.dateTimeLevou.CustomFormat = "dd/MM/yyyy";
            this.dateTimeLevou.Enabled = false;
            this.dateTimeLevou.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeLevou.Location = new System.Drawing.Point(106, 51);
            this.dateTimeLevou.Name = "dateTimeLevou";
            this.dateTimeLevou.Size = new System.Drawing.Size(119, 20);
            this.dateTimeLevou.TabIndex = 53;
            // 
            // lblLevou
            // 
            this.lblLevou.AutoSize = true;
            this.lblLevou.Enabled = false;
            this.lblLevou.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevou.Location = new System.Drawing.Point(103, 35);
            this.lblLevou.Name = "lblLevou";
            this.lblLevou.Size = new System.Drawing.Size(94, 13);
            this.lblLevou.TabIndex = 52;
            this.lblLevou.Text = "Data que levou";
            // 
            // lblIdCurso
            // 
            this.lblIdCurso.AutoSize = true;
            this.lblIdCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCurso.Location = new System.Drawing.Point(13, 52);
            this.lblIdCurso.Name = "lblIdCurso";
            this.lblIdCurso.Size = new System.Drawing.Size(58, 13);
            this.lblIdCurso.TabIndex = 58;
            this.lblIdCurso.Text = "Registro:";
            // 
            // txtIdPFisica
            // 
            this.txtIdPFisica.Location = new System.Drawing.Point(469, 93);
            this.txtIdPFisica.Name = "txtIdPFisica";
            this.txtIdPFisica.Size = new System.Drawing.Size(100, 20);
            this.txtIdPFisica.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(466, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Curso";
            // 
            // txtCurso
            // 
            this.txtCurso.Location = new System.Drawing.Point(16, 93);
            this.txtCurso.Name = "txtCurso";
            this.txtCurso.Size = new System.Drawing.Size(383, 20);
            this.txtCurso.TabIndex = 63;
            // 
            // txtRestaPagar
            // 
            this.txtRestaPagar.Location = new System.Drawing.Point(16, 141);
            this.txtRestaPagar.Name = "txtRestaPagar";
            this.txtRestaPagar.Size = new System.Drawing.Size(100, 20);
            this.txtRestaPagar.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Resta pagar";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(163, 141);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(189, 20);
            this.txtPeriodo.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(163, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Período";
            // 
            // dateTimePagamento
            // 
            this.dateTimePagamento.CustomFormat = "dd/MM/yyyy";
            this.dateTimePagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePagamento.Location = new System.Drawing.Point(16, 189);
            this.dateTimePagamento.Name = "dateTimePagamento";
            this.dateTimePagamento.Size = new System.Drawing.Size(119, 20);
            this.dateTimePagamento.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Data do último pagamento";
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(16, 333);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(858, 169);
            this.txtObs.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Observações";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRemover);
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Controls.Add(this.btnListaCursos);
            this.panel3.Controls.Add(this.btnAlterar);
            this.panel3.Controls.Add(this.btnInserir);
            this.panel3.Location = new System.Drawing.Point(656, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 141);
            this.panel3.TabIndex = 73;
            // 
            // btnRemover
            // 
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Location = new System.Drawing.Point(13, 86);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(135, 23);
            this.btnRemover.TabIndex = 14;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(13, 112);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(135, 23);
            this.btnLimpar.TabIndex = 13;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnListaCursos
            // 
            this.btnListaCursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaCursos.Location = new System.Drawing.Point(13, 60);
            this.btnListaCursos.Name = "btnListaCursos";
            this.btnListaCursos.Size = new System.Drawing.Size(135, 23);
            this.btnListaCursos.TabIndex = 12;
            this.btnListaCursos.Text = "Listar Cursos";
            this.btnListaCursos.UseVisualStyleBackColor = true;
            this.btnListaCursos.Click += new System.EventHandler(this.btnListaServico_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(13, 33);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(135, 23);
            this.btnAlterar.TabIndex = 11;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInserir.Location = new System.Drawing.Point(13, 7);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(135, 23);
            this.btnInserir.TabIndex = 10;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // FormHistoricoCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePagamento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRestaPagar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurso);
            this.Controls.Add(this.txtIdPFisica);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblIdCurso);
            this.Controls.Add(this.label1);
            this.Name = "FormHistoricoCursos";
            this.Text = "FormHistoricoCursos";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkFormou;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimeFormatura;
        private System.Windows.Forms.Label lblFormatura;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkLevou;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimeLevou;
        private System.Windows.Forms.Label lblLevou;
        private System.Windows.Forms.Label lblIdCurso;
        private System.Windows.Forms.TextBox txtIdPFisica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurso;
        private System.Windows.Forms.TextBox txtRestaPagar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePagamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnListaCursos;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnInserir;
    }
}