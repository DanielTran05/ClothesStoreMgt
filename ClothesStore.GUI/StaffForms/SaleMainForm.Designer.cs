namespace ClothesStore.GUI.StaffForms
{
    partial class SaleMainForm
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
            label1 = new Label();
            btnLogout = new Button();
            btnSearchProduct = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(1, 3);
            label1.Name = "label1";
            label1.Size = new Size(513, 46);
            label1.TabIndex = 0;
            label1.Text = "WELCOME TO SALE STAFF FORM";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(729, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(67, 28);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnSearchProduct
            // 
            btnSearchProduct.Location = new Point(12, 52);
            btnSearchProduct.Name = "btnSearchProduct";
            btnSearchProduct.Size = new Size(94, 69);
            btnSearchProduct.TabIndex = 2;
            btnSearchProduct.Text = "Search Product";
            btnSearchProduct.UseVisualStyleBackColor = true;
            btnSearchProduct.Click += btnSearchProduct_Click;
            // 
            // SaleMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearchProduct);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Name = "SaleMainForm";
            Text = "SaleMainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLogout;
        private Button btnSearchProduct;
    }
}