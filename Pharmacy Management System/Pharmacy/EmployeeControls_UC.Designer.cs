
namespace Pharmacy
{
    partial class EmployeeControls_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeControls_UC));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Profile = new Guna.UI2.WinForms.Guna2Button();
            this.btn_sale = new Guna.UI2.WinForms.Guna2Button();
            this.panel_ucContainer = new System.Windows.Forms.Panel();
            //this.sale1 = new Pharmacy.Sale();
            //this.profile1 = new Pharmacy.Profile();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_ucContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_ucContainer, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1336, 534);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 528);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Profile, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_sale, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(302, 524);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btn_Profile
            // 
            this.btn_Profile.Animated = true;
            this.btn_Profile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Profile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Profile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Profile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Profile.FillColor = System.Drawing.Color.Transparent;
            this.btn_Profile.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Profile.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_Profile.Location = new System.Drawing.Point(3, 3);
            this.btn_Profile.Name = "btn_Profile";
            this.btn_Profile.Size = new System.Drawing.Size(296, 98);
            this.btn_Profile.TabIndex = 1;
            this.btn_Profile.Text = "Profile";
            this.btn_Profile.Click += new System.EventHandler(this.btn_Profile_Click);
            // 
            // btn_sale
            // 
            this.btn_sale.Animated = true;
            this.btn_sale.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_sale.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_sale.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_sale.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_sale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_sale.FillColor = System.Drawing.Color.Transparent;
            this.btn_sale.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_sale.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_sale.Location = new System.Drawing.Point(3, 107);
            this.btn_sale.Name = "btn_sale";
            this.btn_sale.Size = new System.Drawing.Size(296, 98);
            this.btn_sale.TabIndex = 5;
            this.btn_sale.Text = "Sale";
            this.btn_sale.Click += new System.EventHandler(this.btn_sale_Click);
            // 
            // panel_ucContainer
            // 
            this.panel_ucContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
//            this.panel_ucContainer.Controls.Add(this.sale1);
           // this.panel_ucContainer.Controls.Add(this.profile1);
            this.panel_ucContainer.Controls.Add(this.pictureBox1);
            this.panel_ucContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ucContainer.Location = new System.Drawing.Point(315, 3);
            this.panel_ucContainer.Name = "panel_ucContainer";
            this.panel_ucContainer.Size = new System.Drawing.Size(1018, 528);
            this.panel_ucContainer.TabIndex = 1;
            // 
            // sale1
            // 
            //this.sale1.BackColor = System.Drawing.Color.LightSlateGray;
//            this.sale1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.sale1.Location = new System.Drawing.Point(0, 0);
  //.          this.sale1.Name = "sale1";
//            this.sale1.Size = new System.Drawing.Size(1014, 524);
//            this.sale1.TabIndex = 2;
            // 
            // profile1
            // 
           // this.profile1.BackColor = System.Drawing.Color.LightSlateGray;
//            this.profile1.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.profile1.Location = new System.Drawing.Point(0, 0);
//            this.profile1.Name = "profile1";
  //          this.profile1.Size = new System.Drawing.Size(1014, 524);
   //         this.profile1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1014, 524);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // EmployeeControls_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EmployeeControls_UC";
            this.Size = new System.Drawing.Size(1336, 534);
            this.Load += new System.EventHandler(this.EmployeeControls_UC_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel_ucContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button btn_Profile;
        private Guna.UI2.WinForms.Guna2Button btn_sale;
        private System.Windows.Forms.Panel panel_ucContainer;
        private Profile profile1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Sale sale1;
    }
}
