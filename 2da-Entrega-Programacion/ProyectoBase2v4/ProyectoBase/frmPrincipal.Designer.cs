using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoBase
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.barra = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlInvitado = new System.Windows.Forms.Panel();
            this.btnIS = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPost = new Guna.UI2.WinForms.Guna2Button();
            this.btnEnevtos = new Guna.UI2.WinForms.Guna2Button();
            this.btnChats = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnComunidades = new Guna.UI2.WinForms.Guna2Button();
            this.btnNotificaciones = new Guna.UI2.WinForms.Guna2Button();
            this.btnInicio = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.LogoApp = new System.Windows.Forms.PictureBox();
            this.pnlFeed = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2ResizeForm1 = new Guna.UI2.WinForms.Guna2ResizeForm(this.components);
            this.barra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlInvitado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoApp)).BeginInit();
            this.pnlFeed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.barra;
            this.guna2DragControl1.TransparentWhileDrag = false;
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Controls.Add(this.guna2ControlBox3);
            this.barra.Controls.Add(this.guna2ControlBox2);
            this.barra.Controls.Add(this.guna2ControlBox1);
            this.barra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(880, 25);
            this.barra.TabIndex = 2;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox3.Location = new System.Drawing.Point(775, 0);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(35, 25);
            this.guna2ControlBox3.TabIndex = 28;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.Location = new System.Drawing.Point(810, 0);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(35, 25);
            this.guna2ControlBox2.TabIndex = 27;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2ControlBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(845, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(35, 25);
            this.guna2ControlBox1.TabIndex = 26;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.ForeColor = System.Drawing.Color.Black;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.pnlInvitado);
            this.splitContainer1.Panel1.Controls.Add(this.btnPost);
            this.splitContainer1.Panel1.Controls.Add(this.btnEnevtos);
            this.splitContainer1.Panel1.Controls.Add(this.btnChats);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnComunidades);
            this.splitContainer1.Panel1.Controls.Add(this.btnNotificaciones);
            this.splitContainer1.Panel1.Controls.Add(this.btnInicio);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblUsuario);
            this.splitContainer1.Panel1.Controls.Add(this.LogoApp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.pnlFeed);
            this.splitContainer1.Size = new System.Drawing.Size(880, 478);
            this.splitContainer1.SplitterDistance = 192;
            this.splitContainer1.TabIndex = 1;
            // 
            // pnlInvitado
            // 
            this.pnlInvitado.Controls.Add(this.btnIS);
            this.pnlInvitado.Controls.Add(this.label3);
            this.pnlInvitado.Controls.Add(this.label1);
            this.pnlInvitado.Controls.Add(this.pictureBox3);
            this.pnlInvitado.Controls.Add(this.pictureBox2);
            this.pnlInvitado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvitado.Enabled = false;
            this.pnlInvitado.Location = new System.Drawing.Point(0, 0);
            this.pnlInvitado.Name = "pnlInvitado";
            this.pnlInvitado.Size = new System.Drawing.Size(192, 478);
            this.pnlInvitado.TabIndex = 60;
            this.pnlInvitado.Visible = false;
            // 
            // btnIS
            // 
            this.btnIS.BackColor = System.Drawing.Color.Transparent;
            this.btnIS.BorderRadius = 18;
            this.btnIS.BorderThickness = 2;
            this.btnIS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIS.FillColor = System.Drawing.Color.White;
            this.btnIS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIS.ForeColor = System.Drawing.Color.Black;
            this.btnIS.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnIS.Location = new System.Drawing.Point(12, 199);
            this.btnIS.Name = "btnIS";
            this.btnIS.Size = new System.Drawing.Size(167, 46);
            this.btnIS.TabIndex = 55;
            this.btnIS.Text = "Iniciar Sesion";
            this.btnIS.Click += new System.EventHandler(this.btnIS_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(74, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Sesion no Iniciada";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(74, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Invitado";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::ProyectoBase.Properties.Resources.perfil;
            this.pictureBox3.Location = new System.Drawing.Point(11, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 56);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 49;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::ProyectoBase.Properties.Resources.pngtree_earth_planet_isolated_on_white_background_png_image_49716164;
            this.pictureBox2.Location = new System.Drawing.Point(-71, 405);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(262, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // btnPost
            // 
            this.btnPost.BackColor = System.Drawing.Color.Transparent;
            this.btnPost.BorderRadius = 18;
            this.btnPost.BorderThickness = 2;
            this.btnPost.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPost.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPost.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPost.FillColor = System.Drawing.Color.White;
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.ForeColor = System.Drawing.Color.Black;
            this.btnPost.Image = global::ProyectoBase.Properties.Resources.postear1;
            this.btnPost.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPost.Location = new System.Drawing.Point(12, 355);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(167, 46);
            this.btnPost.TabIndex = 59;
            this.btnPost.Text = "Post";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnEnevtos
            // 
            this.btnEnevtos.BackColor = System.Drawing.Color.Transparent;
            this.btnEnevtos.BorderRadius = 18;
            this.btnEnevtos.BorderThickness = 2;
            this.btnEnevtos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnevtos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnevtos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnevtos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnevtos.FillColor = System.Drawing.Color.White;
            this.btnEnevtos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnevtos.ForeColor = System.Drawing.Color.Black;
            this.btnEnevtos.Image = global::ProyectoBase.Properties.Resources.evento3;
            this.btnEnevtos.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEnevtos.Location = new System.Drawing.Point(12, 303);
            this.btnEnevtos.Name = "btnEnevtos";
            this.btnEnevtos.Size = new System.Drawing.Size(167, 46);
            this.btnEnevtos.TabIndex = 58;
            this.btnEnevtos.Text = "Eventos";
            this.btnEnevtos.Click += new System.EventHandler(this.btnEnevtos_Click);
            // 
            // btnChats
            // 
            this.btnChats.BackColor = System.Drawing.Color.Transparent;
            this.btnChats.BorderRadius = 18;
            this.btnChats.BorderThickness = 2;
            this.btnChats.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChats.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChats.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChats.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChats.FillColor = System.Drawing.Color.White;
            this.btnChats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChats.ForeColor = System.Drawing.Color.Black;
            this.btnChats.Image = global::ProyectoBase.Properties.Resources.chat3;
            this.btnChats.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnChats.Location = new System.Drawing.Point(12, 251);
            this.btnChats.Name = "btnChats";
            this.btnChats.Size = new System.Drawing.Size(167, 46);
            this.btnChats.TabIndex = 57;
            this.btnChats.Text = "Chats";
            this.btnChats.Click += new System.EventHandler(this.btnChats_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::ProyectoBase.Properties.Resources.pngtree_earth_planet_isolated_on_white_background_png_image_49716164;
            this.pictureBox1.Location = new System.Drawing.Point(-71, 405);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnComunidades
            // 
            this.btnComunidades.BackColor = System.Drawing.Color.Transparent;
            this.btnComunidades.BorderRadius = 18;
            this.btnComunidades.BorderThickness = 2;
            this.btnComunidades.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnComunidades.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnComunidades.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnComunidades.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnComunidades.FillColor = System.Drawing.Color.White;
            this.btnComunidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComunidades.ForeColor = System.Drawing.Color.Black;
            this.btnComunidades.Image = global::ProyectoBase.Properties.Resources.grupos1;
            this.btnComunidades.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnComunidades.Location = new System.Drawing.Point(12, 199);
            this.btnComunidades.Name = "btnComunidades";
            this.btnComunidades.Size = new System.Drawing.Size(167, 46);
            this.btnComunidades.TabIndex = 56;
            this.btnComunidades.Text = "Comunidades";
            this.btnComunidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnComunidades.Click += new System.EventHandler(this.btnComunidades_Click);
            // 
            // btnNotificaciones
            // 
            this.btnNotificaciones.BackColor = System.Drawing.Color.Transparent;
            this.btnNotificaciones.BorderRadius = 18;
            this.btnNotificaciones.BorderThickness = 2;
            this.btnNotificaciones.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNotificaciones.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNotificaciones.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNotificaciones.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNotificaciones.FillColor = System.Drawing.Color.White;
            this.btnNotificaciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotificaciones.ForeColor = System.Drawing.Color.Black;
            this.btnNotificaciones.Image = global::ProyectoBase.Properties.Resources.noti11;
            this.btnNotificaciones.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNotificaciones.Location = new System.Drawing.Point(12, 147);
            this.btnNotificaciones.Name = "btnNotificaciones";
            this.btnNotificaciones.Size = new System.Drawing.Size(167, 46);
            this.btnNotificaciones.TabIndex = 55;
            this.btnNotificaciones.Text = "Notificaciones";
            this.btnNotificaciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNotificaciones.Click += new System.EventHandler(this.btnNotificaciones_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Transparent;
            this.btnInicio.BorderRadius = 18;
            this.btnInicio.BorderThickness = 2;
            this.btnInicio.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInicio.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInicio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInicio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInicio.FillColor = System.Drawing.Color.White;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.Black;
            this.btnInicio.Image = global::ProyectoBase.Properties.Resources.home4;
            this.btnInicio.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnInicio.Location = new System.Drawing.Point(12, 95);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(167, 46);
            this.btnInicio.TabIndex = 54;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(74, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Nombre Apellido";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(74, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(104, 16);
            this.lblUsuario.TabIndex = 49;
            this.lblUsuario.Text = "NombreUsuario";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // LogoApp
            // 
            this.LogoApp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogoApp.BackColor = System.Drawing.Color.Transparent;
            this.LogoApp.Image = global::ProyectoBase.Properties.Resources.perfil;
            this.LogoApp.Location = new System.Drawing.Point(11, 12);
            this.LogoApp.Name = "LogoApp";
            this.LogoApp.Size = new System.Drawing.Size(57, 56);
            this.LogoApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoApp.TabIndex = 48;
            this.LogoApp.TabStop = false;
            this.LogoApp.Click += new System.EventHandler(this.LogoApp_Click);
            // 
            // pnlFeed
            // 
            this.pnlFeed.AutoScroll = true;
            this.pnlFeed.Controls.Add(this.flowLayoutPanel1);
            this.pnlFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFeed.Location = new System.Drawing.Point(0, 0);
            this.pnlFeed.Name = "pnlFeed";
            this.pnlFeed.Size = new System.Drawing.Size(684, 478);
            this.pnlFeed.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(684, 478);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Black;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.barra);
            this.splitContainer2.Panel1MinSize = 18;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel2MinSize = 18;
            this.splitContainer2.Size = new System.Drawing.Size(880, 504);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 15;
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2ResizeForm1
            // 
            this.guna2ResizeForm1.TargetForm = this;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 504);
            this.Controls.Add(this.splitContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(880, 504);
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.Activated += new System.EventHandler(this.frmPrincipal_Activated);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.SizeChanged += new System.EventHandler(this.frmPrincipal_SizeChanged);
            this.Resize += new System.EventHandler(this.frmPrincipal_Resize);
            this.barra.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlInvitado.ResumeLayout(false);
            this.pnlInvitado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoApp)).EndInit();
            this.pnlFeed.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private SplitContainer splitContainer1;
        private Label label2;
        private Label lblUsuario;
        private PictureBox LogoApp;
        private Guna.UI2.WinForms.Guna2Button btnInicio;
        private Guna.UI2.WinForms.Guna2Button btnNotificaciones;
        private Guna.UI2.WinForms.Guna2Button btnPost;
        private Guna.UI2.WinForms.Guna2Button btnEnevtos;
        private Guna.UI2.WinForms.Guna2Button btnChats;
        private Guna.UI2.WinForms.Guna2Button btnComunidades;
        private Guna.UI2.WinForms.Guna2Panel barra;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private PictureBox pictureBox1;
        private Panel pnlInvitado;
        private Label label3;
        private Label label1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnIS;
        private SplitContainer splitContainer2;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ResizeForm guna2ResizeForm1;
        public Panel pnlFeed;
        public FlowLayoutPanel flowLayoutPanel1;
    }
}
