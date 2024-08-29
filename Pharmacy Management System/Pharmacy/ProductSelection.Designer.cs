
namespace Pharmacy
{
    partial class ProductSelection
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
            this.comboBox_productSelection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox_productSelection
            // 
            this.comboBox_productSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox_productSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_productSelection.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_productSelection.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.comboBox_productSelection.FormattingEnabled = true;
            this.comboBox_productSelection.Items.AddRange(new object[] {
            "Drug",
            "Vaccine",
            "MedicalDevice",
            "Cosmetic"});
            this.comboBox_productSelection.Location = new System.Drawing.Point(45, 57);
            this.comboBox_productSelection.Name = "comboBox_productSelection";
            this.comboBox_productSelection.Size = new System.Drawing.Size(373, 55);
            this.comboBox_productSelection.TabIndex = 53;
            this.comboBox_productSelection.SelectedIndexChanged += new System.EventHandler(this.comboBox_productSelection_SelectedIndexChanged);
            // 
            // ProductSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(462, 168);
            this.Controls.Add(this.comboBox_productSelection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductSelection";
            this.Text = "Selection Dock";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_productSelection;
    }
}