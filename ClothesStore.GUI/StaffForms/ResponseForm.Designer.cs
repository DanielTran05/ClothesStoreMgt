namespace ClothesStore.GUI.StaffForms
{
    partial class ResponseForm
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
            lblResponseTitle = new Label();
            txtResponse = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblResponseTitle
            // 
            lblResponseTitle.AutoSize = true;
            lblResponseTitle.Location = new Point(25, 17);
            lblResponseTitle.Name = "lblResponseTitle";
            lblResponseTitle.Size = new Size(113, 20);
            lblResponseTitle.TabIndex = 0;
            lblResponseTitle.Text = "Enter Response:";
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(144, 14);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.ScrollBars = ScrollBars.Vertical;
            txtResponse.Size = new Size(1227, 27);
            txtResponse.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(378, 67);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 58);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(478, 67);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 58);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ResponseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 653);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtResponse);
            Controls.Add(lblResponseTitle);
            Name = "ResponseForm";
            Text = "ResponseForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblResponseTitle;
        private TextBox txtResponse;
        private Button btnConfirm;
        private Button btnCancel;
    }
}