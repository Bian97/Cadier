
namespace CadierDesktop
{
    partial class FormListaHistoricoCursos
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
            this.listViewHistorico = new System.Windows.Forms.ListView();
            this.colIdHistorico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCurso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewHistorico
            // 
            this.listViewHistorico.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewHistorico.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdHistorico,
            this.colCurso,
            this.colResta});
            this.listViewHistorico.HideSelection = false;
            this.listViewHistorico.Location = new System.Drawing.Point(12, 36);
            this.listViewHistorico.Name = "listViewHistorico";
            this.listViewHistorico.Size = new System.Drawing.Size(900, 589);
            this.listViewHistorico.TabIndex = 3;
            this.listViewHistorico.UseCompatibleStateImageBehavior = false;
            // 
            // colIdHistorico
            // 
            this.colIdHistorico.Text = "Registro";
            // 
            // colCurso
            // 
            this.colCurso.Text = "Curso";
            // 
            // colResta
            // 
            this.colResta.Text = "Resta Pagar";
            // 
            // FormListaHistoricoCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.listViewHistorico);
            this.Name = "FormListaHistoricoCursos";
            this.Text = "FormListaHistoricoCursos";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewHistorico;
        private System.Windows.Forms.ColumnHeader colIdHistorico;
        private System.Windows.Forms.ColumnHeader colCurso;
        private System.Windows.Forms.ColumnHeader colResta;
    }
}