namespace ClothesStore.GUI.SystemForms
{
    partial class ChangePasswordForm
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
            label2 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            txtUsername = new TextBox();
            label4 = new Label();
            txtNewPassword = new TextBox();
            label5 = new Label();
            txtRewriteNewPassword = new TextBox();
            btn_confirm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(263, 51);
            label1.Name = "label1";
            label1.Size = new Size(285, 46);
            label1.TabIndex = 0;
            label1.Text = "Change password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(296, 181);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 10;
            label2.Text = "Old password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(296, 204);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(227, 27);
            txtPassword.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 128);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 8;
            label3.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(296, 151);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(227, 27);
            txtUsername.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(296, 244);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 12;
            label4.Text = "New password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(296, 267);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(227, 27);
            txtNewPassword.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(296, 304);
            label5.Name = "label5";
            label5.Size = new Size(157, 20);
            label5.TabIndex = 14;
            label5.Text = "Rewrite new password";
            // 
            // txtRewriteNewPassword
            // 
            txtRewriteNewPassword.Location = new Point(296, 327);
            txtRewriteNewPassword.Name = "txtRewriteNewPassword";
            txtRewriteNewPassword.Size = new Size(227, 27);
            txtRewriteNewPassword.TabIndex = 13;
            // 
            // btn_confirm
            // 
            btn_confirm.Location = new Point(296, 376);
            btn_confirm.Name = "btn_confirm";
            btn_confirm.Size = new Size(227, 29);
            btn_confirm.TabIndex = 15;
            btn_confirm.Text = "Confirm";
            btn_confirm.UseVisualStyleBackColor = true;
            btn_confirm.Click += btn_confirm_Click;
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_confirm);
            Controls.Add(label5);
            Controls.Add(txtRewriteNewPassword);
            Controls.Add(label4);
            Controls.Add(txtNewPassword);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Name = "ChangePasswordForm";
            Text = "ChangePasswordForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsername;
        private Label label4;
        private TextBox txtNewPassword;
        private Label label5;
        private TextBox txtRewriteNewPassword;
        private Button btn_confirm;
    }
}