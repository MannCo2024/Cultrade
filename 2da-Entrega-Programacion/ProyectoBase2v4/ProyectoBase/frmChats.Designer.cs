using System.Drawing;
using System.Windows.Forms;

namespace ProyectoBase
{
    partial class frmChats
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.barra = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox6 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox5 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox4 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.barra.SuspendLayout();
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
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(702, 403);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(40, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 28);
            this.label12.TabIndex = 69;
            this.label12.Text = "CHATS";
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
            this.barra.Controls.Add(this.guna2ControlBox4);
            this.barra.Controls.Add(this.guna2ControlBox5);
            this.barra.Controls.Add(this.guna2ControlBox6);
            this.barra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barra.Location = new System.Drawing.Point(0, 0);
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(702, 25);
            this.barra.TabIndex = 3;
            // 
            // guna2ControlBox6
            // 
            this.guna2ControlBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2ControlBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox6.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox6.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox6.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox6.Location = new System.Drawing.Point(667, 0);
            this.guna2ControlBox6.Name = "guna2ControlBox6";
            this.guna2ControlBox6.Size = new System.Drawing.Size(35, 25);
            this.guna2ControlBox6.TabIndex = 26;
            // 
            // guna2ControlBox5
            // 
            this.guna2ControlBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2ControlBox5.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox5.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox5.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox5.Location = new System.Drawing.Point(632, 0);
            this.guna2ControlBox5.Name = "guna2ControlBox5";
            this.guna2ControlBox5.Size = new System.Drawing.Size(35, 25);
            this.guna2ControlBox5.TabIndex = 27;
            // 
            // guna2ControlBox4
            // 
            this.guna2ControlBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2ControlBox4.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2ControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox4.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox4.Location = new System.Drawing.Point(597, 0);
            this.guna2ControlBox4.Name = "guna2ControlBox4";
            this.guna2ControlBox4.Size = new System.Drawing.Size(35, 25);
            this.guna2ControlBox4.TabIndex = 28;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.barra);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(702, 429);
            this.splitContainer2.SplitterDistance = 25;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 1;
            // 
            // frmChats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 429);
            this.Controls.Add(this.splitContainer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(702, 429);
            this.Name = "frmChats";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.barra.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private SplitContainer splitContainer1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Label label12;
        private SplitContainer splitContainer2;
        private Guna.UI2.WinForms.Guna2Panel barra;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox5;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox6;
    }
}