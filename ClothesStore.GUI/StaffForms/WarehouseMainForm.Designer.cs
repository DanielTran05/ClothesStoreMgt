namespace ClothesStore.GUI.StaffForms
{
    partial class WarehouseMainForm
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
            btnImport = new Button();
            btnStatistic = new Button();
            btnInventory = new Button();
            btnSupplier = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(1, 3);
            label1.Name = "label1";
            label1.Size = new Size(638, 46);
            label1.TabIndex = 0;
            label1.Text = "WELCOME TO WAREHOUSE STAFF FORM";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(718, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(65, 27);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnImport
            // 
            btnImport.Location = new Point(403, 385);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(94, 53);
            btnImport.TabIndex = 2;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnStatistic
            // 
            btnStatistic.Location = new Point(703, 385);
            btnStatistic.Name = "btnStatistic";
            btnStatistic.Size = new Size(94, 53);
            btnStatistic.TabIndex = 2;
            btnStatistic.Text = "Statistic";
            btnStatistic.UseVisualStyleBackColor = true;
            btnStatistic.Click += btnStatistic_Click;
            // 
            // btnInventory
            // 
            btnInventory.Location = new Point(603, 385);
            btnInventory.Name = "btnInventory";
            btnInventory.Size = new Size(94, 53);
            btnInventory.TabIndex = 2;
            btnInventory.Text = "Inventory";
            btnInventory.UseVisualStyleBackColor = true;
            btnInventory.Click += btnInventory_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.Location = new Point(503, 385);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(94, 53);
            btnSupplier.TabIndex = 2;
            btnSupplier.Text = "Supplier";
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // WarehouseMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSupplier);
            Controls.Add(btnInventory);
            Controls.Add(btnStatistic);
            Controls.Add(btnImport);
            Controls.Add(btnLogout);
            Controls.Add(label1);
            Name = "WarehouseMainForm";
            Text = "WarehouseMainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLogout;
        private Button btnImport;
        private Button btnStatistic;
        private Button btnInventory;
        private Button btnSupplier;
    }
}