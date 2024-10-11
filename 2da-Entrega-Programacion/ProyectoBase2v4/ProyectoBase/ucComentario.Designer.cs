
namespace ProyectoBase
{
    partial class ucComentario
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPFP = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPFP)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.splitContainer1);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(255, 132);
            this.guna2Panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pbPFP);
            this.splitContainer1.Panel1MinSize = 64;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtComentario);
            this.splitContainer1.Panel2MinSize = 64;
            this.splitContainer1.Size = new System.Drawing.Size(255, 132);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(74, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // pbPFP
            // 
            this.pbPFP.ErrorImage = global::ProyectoBase.Properties.Resources.perfil;
            this.pbPFP.Image = global::ProyectoBase.Properties.Resources.perfil;
            this.pbPFP.ImageRotate = 0F;
            this.pbPFP.Location = new System.Drawing.Point(4, 0);
            this.pbPFP.Name = "pbPFP";
            this.pbPFP.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbPFP.Size = new System.Drawing.Size(64, 64);
            this.pbPFP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPFP.TabIndex = 0;
            this.pbPFP.TabStop = false;
            // 
            // txtComentario
            // 
            this.txtComentario.BackColor = System.Drawing.SystemColors.Control;
            this.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComentario.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtComentario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComentario.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtComentario.Location = new System.Drawing.Point(0, 0);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.txtComentario.MaxLength = 255;
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.ReadOnly = true;
            this.txtComentario.Size = new System.Drawing.Size(255, 64);
            this.txtComentario.TabIndex = 2;
            // 
            // ucComentario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.MinimumSize = new System.Drawing.Size(255, 132);
            this.Name = "ucComentario";
            this.Size = new System.Drawing.Size(255, 132);
            this.guna2Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPFP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbPFP;
        public System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
