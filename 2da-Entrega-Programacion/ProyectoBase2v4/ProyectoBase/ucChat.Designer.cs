namespace ProyectoBase
{
    partial class ucChat
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
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pbPFP = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.rtxtMsg = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPFP)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(66, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(83, 23);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Click += new System.EventHandler(this.rtxtMsg_Click);
            // 
            // pbPFP
            // 
            this.pbPFP.ErrorImage = global::ProyectoBase.Properties.Resources.perfil;
            this.pbPFP.Image = global::ProyectoBase.Properties.Resources.perfil;
            this.pbPFP.ImageRotate = 0F;
            this.pbPFP.Location = new System.Drawing.Point(0, 0);
            this.pbPFP.Name = "pbPFP";
            this.pbPFP.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbPFP.Size = new System.Drawing.Size(60, 60);
            this.pbPFP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPFP.TabIndex = 2;
            this.pbPFP.TabStop = false;
            this.pbPFP.Click += new System.EventHandler(this.rtxtMsg_Click);
            // 
            // rtxtMsg
            // 
            this.rtxtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtMsg.BackColor = System.Drawing.Color.White;
            this.rtxtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtxtMsg.Enabled = false;
            this.rtxtMsg.Location = new System.Drawing.Point(70, 35);
            this.rtxtMsg.Multiline = false;
            this.rtxtMsg.Name = "rtxtMsg";
            this.rtxtMsg.ReadOnly = true;
            this.rtxtMsg.RightMargin = 3;
            this.rtxtMsg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtxtMsg.Size = new System.Drawing.Size(143, 30);
            this.rtxtMsg.TabIndex = 4;
            this.rtxtMsg.Text = "";
            this.rtxtMsg.WordWrap = false;
            this.rtxtMsg.Click += new System.EventHandler(this.rtxtMsg_Click);
            // 
            // ucChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.rtxtMsg);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.pbPFP);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximumSize = new System.Drawing.Size(0, 70);
            this.MinimumSize = new System.Drawing.Size(220, 70);
            this.Name = "ucChat";
            this.Size = new System.Drawing.Size(220, 70);
            this.Click += new System.EventHandler(this.rtxtMsg_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbPFP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUsuario;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbPFP;
        private RichTextBox rtxtMsg;
    }
}
