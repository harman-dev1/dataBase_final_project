
namespace Pharmacy
{
    partial class LoggingIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggingIn));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.btn_min = new Guna.UI2.WinForms.Guna2Button();
            this.btn_max = new Guna.UI2.WinForms.Guna2Button();
            this.panel_ucContainer = new System.Windows.Forms.Panel();
            this.signUp_UC1 = new Pharmacy.SignUp_UC();
            this.btn_back = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_ucContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_ucContainer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.23631F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.76369F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1348, 749);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1342, 197);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Controls.Add(this.btn_back, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_close, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_min, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_max, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1338, 193);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(179, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(980, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pharmacy Managemnt System";
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_close.FillColor = System.Drawing.Color.Transparent;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(1296, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(39, 45);
            this.btn_close.TabIndex = 3;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_min
            // 
            this.btn_min.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_min.BackgroundImage")));
            this.btn_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_min.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_min.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_min.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_min.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_min.FillColor = System.Drawing.Color.Transparent;
            this.btn_min.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_min.ForeColor = System.Drawing.Color.White;
            this.btn_min.Location = new System.Drawing.Point(1251, 3);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(39, 45);
            this.btn_min.TabIndex = 4;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // btn_max
            // 
            this.btn_max.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_max.BackgroundImage")));
            this.btn_max.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_max.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_max.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_max.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_max.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_max.FillColor = System.Drawing.Color.Transparent;
            this.btn_max.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_max.ForeColor = System.Drawing.Color.White;
            this.btn_max.Location = new System.Drawing.Point(1206, 3);
            this.btn_max.Name = "btn_max";
            this.btn_max.Size = new System.Drawing.Size(39, 45);
            this.btn_max.TabIndex = 5;
            this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
            // 
            // panel_ucContainer
            // 
            this.panel_ucContainer.Controls.Add(this.signUp_UC1);
            this.panel_ucContainer.Controls.Add(this.signIn1);
            this.panel_ucContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ucContainer.Location = new System.Drawing.Point(3, 206);
            this.panel_ucContainer.Name = "panel_ucContainer";
            this.panel_ucContainer.Size = new System.Drawing.Size(1342, 540);
            this.panel_ucContainer.TabIndex = 1;
            // 
            // signUp_UC1
            // 
            this.signUp_UC1.BackColor = System.Drawing.Color.LightSlateGray;
            this.signUp_UC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signUp_UC1.Location = new System.Drawing.Point(0, 0);
            this.signUp_UC1.Name = "signUp_UC1";
            this.signUp_UC1.Size = new System.Drawing.Size(1342, 540);
            this.signUp_UC1.TabIndex = 1;
            // 
            // signIn1
            // 
            //this.signIn1.BackColor = System.Drawing.Color.LightSlateGray;
            //this.signIn1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.signIn1.Location = new System.Drawing.Point(0, 0);
            //this.signIn1.Name = "signIn1";
            //this.signIn1.Size = new System.Drawing.Size(1342, 540);
            //this.signIn1.TabIndex = 0;
            // 
            // btn_back
            // 
            this.btn_back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_back.BackgroundImage")));
            this.btn_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_back.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_back.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_back.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_back.FillColor = System.Drawing.Color.Transparent;
            this.btn_back.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_back.ForeColor = System.Drawing.Color.White;
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(39, 45);
            this.btn_back.TabIndex = 6;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // LoggingIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1348, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoggingIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoggingIn";
            this.Load += new System.EventHandler(this.LoggingIn_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel_ucContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private Guna.UI2.WinForms.Guna2Button btn_min;
        private Guna.UI2.WinForms.Guna2Button btn_max;
        private System.Windows.Forms.Panel panel_ucContainer;
        private SignUp_UC signUp_UC1;
        private SignIn signIn1;
        private Guna.UI2.WinForms.Guna2Button btn_back;
    }
}