namespace ProyectoBase
{
    partial class ucMensaje
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsu = new System.Windows.Forms.Label();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblUsu
            // 
            this.lblUsu.AutoSize = true;
            this.lblUsu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUsu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUsu.Location = new System.Drawing.Point(3, 0);
            this.lblUsu.Name = "lblUsu";
            this.lblUsu.Size = new System.Drawing.Size(104, 16);
            this.lblUsu.TabIndex = 54;
            this.lblUsu.Text = "NombreUsuario";
            // 
            // rtbDesc
            // 
            this.rtbDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbDesc.BackColor = System.Drawing.Color.White;
            this.rtbDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDesc.ForeColor = System.Drawing.Color.Black;
            this.rtbDesc.Location = new System.Drawing.Point(12, 19);
            this.rtbDesc.MaxLength = 300;
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.ReadOnly = true;
            this.rtbDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDesc.Size = new System.Drawing.Size(383, 1);
            this.rtbDesc.TabIndex = 79;
            this.rtbDesc.Text = "";
            this.rtbDesc.TextChanged += new System.EventHandler(this.rtbDesc_TextChanged);
            // 
            // ucMensaje
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.rtbDesc);
            this.Controls.Add(this.lblUsu);
            this.Name = "ucMensaje";
            this.Size = new System.Drawing.Size(398, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUsu;
        private RichTextBox rtbDesc;
    }
}
