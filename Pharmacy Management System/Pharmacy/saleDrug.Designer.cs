
namespace Pharmacy
{
    partial class saleDrug
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_manufecturer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_unitQuantity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_Unit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.comboBox_manufecturer);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBox_unitQuantity);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.comboBox_Unit);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.btn_add);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(390, 482);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Elephant", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search";
            // 
            // comboBox_manufecturer
            // 
            this.comboBox_manufecturer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_manufecturer.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_manufecturer.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.comboBox_manufecturer.FormattingEnabled = true;
            this.comboBox_manufecturer.Location = new System.Drawing.Point(3, 52);
            this.comboBox_manufecturer.Name = "comboBox_manufecturer";
            this.comboBox_manufecturer.Size = new System.Drawing.Size(353, 40);
            this.comboBox_manufecturer.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(3, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 49);
            this.label1.TabIndex = 78;
            this.label1.Text = "Quantity";
            // 
            // textBox_unitQuantity
            // 
            this.textBox_unitQuantity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_unitQuantity.Font = new System.Drawing.Font("Noto Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_unitQuantity.Location = new System.Drawing.Point(3, 147);
            this.textBox_unitQuantity.Name = "textBox_unitQuantity";
            this.textBox_unitQuantity.Size = new System.Drawing.Size(353, 44);
            this.textBox_unitQuantity.TabIndex = 79;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Elephant", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Info;
            this.label9.Location = new System.Drawing.Point(3, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 49);
            this.label9.TabIndex = 82;
            this.label9.Text = "Unit";
            // 
            // comboBox_Unit
            // 
            this.comboBox_Unit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Unit.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Unit.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.comboBox_Unit.FormattingEnabled = true;
            this.comboBox_Unit.Items.AddRange(new object[] {
            "mg",
            "ml"});
            this.comboBox_Unit.Location = new System.Drawing.Point(3, 246);
            this.comboBox_Unit.Name = "comboBox_Unit";
            this.comboBox_Unit.Size = new System.Drawing.Size(353, 40);
            this.comboBox_Unit.TabIndex = 83;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Elephant", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Info;
            this.label10.Location = new System.Drawing.Point(3, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(271, 49);
            this.label10.TabIndex = 84;
            this.label10.Text = "Unit Quatity";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Font = new System.Drawing.Font("Noto Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 341);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 44);
            this.textBox1.TabIndex = 85;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_add.Animated = true;
            this.btn_add.BorderRadius = 25;
            this.btn_add.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.btn_add.BorderThickness = 3;
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.FillColor = System.Drawing.Color.DarkKhaki;
            this.btn_add.Font = new System.Drawing.Font("Cambria", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.SystemColors.Info;
            this.btn_add.Location = new System.Drawing.Point(3, 391);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(353, 72);
            this.btn_add.TabIndex = 86;
            this.btn_add.Text = "Add Sale";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // saleDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 482);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "saleDrug";
            this.Text = "Sale Page";
            this.Load += new System.EventHandler(this.saleDrug_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_manufecturer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_unitQuantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_Unit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private Guna.UI2.WinForms.Guna2Button btn_add;
    }
}