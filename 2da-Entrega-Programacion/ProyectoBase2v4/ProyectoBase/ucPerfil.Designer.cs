namespace ProyectoBase
{
    partial class ucPerfil
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
            this.btnAAmigo = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardados = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.rtbDesc = new System.Windows.Forms.RichTextBox();
            this.btnBlock = new Guna.UI2.WinForms.Guna2Button();
            this.btnEMsg = new Guna.UI2.WinForms.Guna2Button();
            this.lblNomApeEdad = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.LogoApp = new System.Windows.Forms.PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoApp)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btnAAmigo);
            this.guna2Panel1.Controls.Add(this.btnGuardados);
            this.guna2Panel1.Controls.Add(this.guna2ImageButton1);
            this.guna2Panel1.Controls.Add(this.rtbDesc);
            this.guna2Panel1.Controls.Add(this.btnBlock);
            this.guna2Panel1.Controls.Add(this.btnEMsg);
            this.guna2Panel1.Controls.Add(this.lblNomApeEdad);
            this.guna2Panel1.Controls.Add(this.lblUsuario);
            this.guna2Panel1.Controls.Add(this.lblMail);
            this.guna2Panel1.Controls.Add(this.LogoApp);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(702, 133);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnAAmigo
            // 
            this.btnAAmigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAAmigo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAAmigo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAAmigo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAAmigo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAAmigo.FillColor = System.Drawing.Color.Transparent;
            this.btnAAmigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAAmigo.ForeColor = System.Drawing.Color.Black;
            this.btnAAmigo.Image = global::ProyectoBase.Properties.Resources.amigo;
            this.btnAAmigo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAAmigo.Location = new System.Drawing.Point(569, 6);
            this.btnAAmigo.Name = "btnAAmigo";
            this.btnAAmigo.Size = new System.Drawing.Size(130, 24);
            this.btnAAmigo.TabIndex = 75;
            this.btnAAmigo.Text = "Añadir amigo";
            this.btnAAmigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnGuardados
            // 
            this.btnGuardados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardados.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardados.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardados.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardados.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardados.Enabled = false;
            this.btnGuardados.FillColor = System.Drawing.Color.Transparent;
            this.btnGuardados.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardados.ForeColor = System.Drawing.Color.Black;
            this.btnGuardados.Image = global::ProyectoBase.Properties.Resources.guardar;
            this.btnGuardados.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGuardados.Location = new System.Drawing.Point(569, 6);
            this.btnGuardados.Name = "btnGuardados";
            this.btnGuardados.Size = new System.Drawing.Size(130, 24);
            this.btnGuardados.TabIndex = 80;
            this.btnGuardados.Text = "Guardados";
            this.btnGuardados.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGuardados.Visible = false;
            this.btnGuardados.Click += new System.EventHandler(this.btnGuardados_Click);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Enabled = false;
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Image = global::ProyectoBase.Properties.Resources.option;
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.guna2ImageButton1.Location = new System.Drawing.Point(672, 108);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.Size = new System.Drawing.Size(20, 20);
            this.guna2ImageButton1.TabIndex = 79;
            this.guna2ImageButton1.Visible = false;
            // 
            // rtbDesc
            // 
            this.rtbDesc.BackColor = System.Drawing.Color.White;
            this.rtbDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDesc.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbDesc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDesc.Location = new System.Drawing.Point(87, 64);
            this.rtbDesc.MaxLength = 190;
            this.rtbDesc.Name = "rtbDesc";
            this.rtbDesc.ReadOnly = true;
            this.rtbDesc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDesc.Size = new System.Drawing.Size(384, 66);
            this.rtbDesc.TabIndex = 78;
            this.rtbDesc.Text = "";
            // 
            // btnBlock
            // 
            this.btnBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBlock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBlock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBlock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBlock.FillColor = System.Drawing.Color.Transparent;
            this.btnBlock.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlock.ForeColor = System.Drawing.Color.Black;
            this.btnBlock.Image = global::ProyectoBase.Properties.Resources.bloquear;
            this.btnBlock.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBlock.Location = new System.Drawing.Point(569, 66);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(130, 24);
            this.btnBlock.TabIndex = 77;
            this.btnBlock.Text = "Bloquear";
            this.btnBlock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnEMsg
            // 
            this.btnEMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEMsg.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEMsg.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEMsg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEMsg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEMsg.FillColor = System.Drawing.Color.Transparent;
            this.btnEMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEMsg.ForeColor = System.Drawing.Color.Black;
            this.btnEMsg.Image = global::ProyectoBase.Properties.Resources.chat1;
            this.btnEMsg.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEMsg.Location = new System.Drawing.Point(569, 36);
            this.btnEMsg.Name = "btnEMsg";
            this.btnEMsg.Size = new System.Drawing.Size(130, 24);
            this.btnEMsg.TabIndex = 76;
            this.btnEMsg.Text = "Enviar mensaje";
            this.btnEMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblNomApeEdad
            // 
            this.lblNomApeEdad.AutoSize = true;
            this.lblNomApeEdad.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNomApeEdad.Location = new System.Drawing.Point(90, 29);
            this.lblNomApeEdad.Name = "lblNomApeEdad";
            this.lblNomApeEdad.Size = new System.Drawing.Size(151, 14);
            this.lblNomApeEdad.TabIndex = 72;
            this.lblNomApeEdad.Text = "Nombre Apellido Edad(17)";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(88, 4);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(159, 23);
            this.lblUsuario.TabIndex = 64;
            this.lblUsuario.Text = "NombreUsuario";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblMail.Location = new System.Drawing.Point(90, 46);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(115, 14);
            this.lblMail.TabIndex = 65;
            this.lblMail.Text = "ejemplo@gmail.com";
            // 
            // LogoApp
            // 
            this.LogoApp.BackColor = System.Drawing.Color.Transparent;
            this.LogoApp.Image = global::ProyectoBase.Properties.Resources.perfil;
            this.LogoApp.Location = new System.Drawing.Point(3, 3);
            this.LogoApp.Name = "LogoApp";
            this.LogoApp.Size = new System.Drawing.Size(78, 78);
            this.LogoApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoApp.TabIndex = 63;
            this.LogoApp.TabStop = false;
            // 
            // ucPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.MaximumSize = new System.Drawing.Size(0, 133);
            this.MinimumSize = new System.Drawing.Size(702, 133);
            this.Name = "ucPerfil";
            this.Size = new System.Drawing.Size(702, 133);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label lblNomApeEdad;
        private Label lblUsuario;
        private Label lblMail;
        private PictureBox LogoApp;
        private Guna.UI2.WinForms.Guna2Button btnAAmigo;
        private Guna.UI2.WinForms.Guna2Button btnBlock;
        private Guna.UI2.WinForms.Guna2Button btnEMsg;
        private RichTextBox rtbDesc;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private Guna.UI2.WinForms.Guna2Button btnGuardados;
    }
}
