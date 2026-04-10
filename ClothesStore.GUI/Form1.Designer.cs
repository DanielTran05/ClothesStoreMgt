namespace ClothesStore.GUI
{
    partial class Form1
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
            txtCategoryName = new TextBox();
            txtCategoryDesc = new TextBox();
            btnAddCategory = new Button();
            SuspendLayout();
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(246, 66);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(125, 27);
            txtCategoryName.TabIndex = 0;
            // 
            // txtCategoryDesc
            // 
            txtCategoryDesc.Location = new Point(246, 114);
            txtCategoryDesc.Name = "txtCategoryDesc";
            txtCategoryDesc.Size = new Size(125, 27);
            txtCategoryDesc.TabIndex = 1;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(248, 172);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(123, 29);
            btnAddCategory.TabIndex = 2;
            btnAddCategory.Text = "Add category";
            btnAddCategory.UseVisualStyleBackColor = true;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1236, 559);
            Controls.Add(btnAddCategory);
            Controls.Add(txtCategoryDesc);
            Controls.Add(txtCategoryName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCategoryName;
        private TextBox txtCategoryDesc;
        private Button btnAddCategory;
    }
}
