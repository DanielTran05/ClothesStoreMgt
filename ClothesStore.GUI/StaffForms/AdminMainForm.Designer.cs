namespace ClothesStore.GUI
{
    partial class AdminMainForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainTitle = new Label();
            btnLogout = new Button();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            btnManageE = new Guna.UI2.WinForms.Guna2Button();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // mainTitle
            // 
            mainTitle.AutoSize = true;
            mainTitle.BorderStyle = BorderStyle.Fixed3D;
            mainTitle.Font = new Font("Segoe UI", 18F);
            mainTitle.Location = new Point(22, 3);
            mainTitle.Margin = new Padding(4, 0, 4, 0);
            mainTitle.Name = "mainTitle";
            mainTitle.Size = new Size(462, 50);
            mainTitle.TabIndex = 0;
            mainTitle.Text = "WELCOME TO ADMIN PAGE";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(1047, 8);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 45);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(mainTitle);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new Size(1200, 60);
            pnlHeader.TabIndex = 2;
            // 
            // pnlMain
            // 
            pnlMain.AutoScroll = true;
            pnlMain.BackColor = Color.Transparent;
            pnlMain.BorderColor = Color.RosyBrown;
            pnlMain.BorderRadius = 10;
            pnlMain.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pnlMain.BorderThickness = 3;
            pnlMain.CustomizableEdges = customizableEdges3;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.FillColor = Color.White;
            pnlMain.Location = new Point(230, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.ShadowDecoration.Color = Color.LightGray;
            pnlMain.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlMain.ShadowDecoration.Enabled = true;
            pnlMain.Size = new Size(970, 640);
            pnlMain.TabIndex = 4;
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(guna2Button4);
            pnlSidebar.Controls.Add(guna2Button3);
            pnlSidebar.Controls.Add(guna2Button2);
            pnlSidebar.Controls.Add(btnManageE);
            pnlSidebar.CustomizableEdges = customizableEdges13;
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 60);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlSidebar.Size = new Size(230, 640);
            pnlSidebar.TabIndex = 3;
            // 
            // guna2Button4
            // 
            guna2Button4.BackColor = Color.Silver;
            guna2Button4.BorderColor = Color.Ivory;
            guna2Button4.BorderRadius = 4;
            guna2Button4.BorderThickness = 4;
            guna2Button4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button4.CheckedState.CustomBorderColor = Color.FromArgb(24, 119, 242);
            guna2Button4.CheckedState.FillColor = Color.FromArgb(230, 240, 253);
            guna2Button4.CheckedState.ForeColor = Color.Black;
            guna2Button4.CustomBorderThickness = new Padding(4, 0, 0, 0);
            guna2Button4.CustomizableEdges = customizableEdges5;
            guna2Button4.DisabledState.BorderColor = Color.DarkGray;
            guna2Button4.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button4.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button4.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button4.FillColor = Color.Transparent;
            guna2Button4.Font = new Font("Segoe UI", 10F);
            guna2Button4.ForeColor = Color.Black;
            guna2Button4.Location = new Point(12, 283);
            guna2Button4.Name = "guna2Button4";
            guna2Button4.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Button4.Size = new Size(200, 60);
            guna2Button4.TabIndex = 0;
            guna2Button4.Text = "Thống kê";
            guna2Button4.TextAlign = HorizontalAlignment.Left;
            // 
            // guna2Button3
            // 
            guna2Button3.BackColor = Color.Silver;
            guna2Button3.BorderColor = Color.Ivory;
            guna2Button3.BorderRadius = 4;
            guna2Button3.BorderThickness = 4;
            guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button3.CheckedState.CustomBorderColor = Color.FromArgb(24, 119, 242);
            guna2Button3.CheckedState.FillColor = Color.FromArgb(230, 240, 253);
            guna2Button3.CheckedState.ForeColor = Color.Black;
            guna2Button3.CustomBorderThickness = new Padding(4, 0, 0, 0);
            guna2Button3.CustomizableEdges = customizableEdges7;
            guna2Button3.DisabledState.BorderColor = Color.DarkGray;
            guna2Button3.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button3.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button3.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button3.FillColor = Color.Transparent;
            guna2Button3.Font = new Font("Segoe UI", 10F);
            guna2Button3.ForeColor = Color.Black;
            guna2Button3.Location = new Point(12, 192);
            guna2Button3.Name = "guna2Button3";
            guna2Button3.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Button3.Size = new Size(200, 60);
            guna2Button3.TabIndex = 0;
            guna2Button3.Text = "Quản lý Giá cả";
            guna2Button3.TextAlign = HorizontalAlignment.Left;
            // 
            // guna2Button2
            // 
            guna2Button2.BackColor = Color.Silver;
            guna2Button2.BorderColor = Color.Ivory;
            guna2Button2.BorderRadius = 4;
            guna2Button2.BorderThickness = 4;
            guna2Button2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            guna2Button2.CheckedState.CustomBorderColor = Color.FromArgb(24, 119, 242);
            guna2Button2.CheckedState.FillColor = Color.FromArgb(230, 240, 253);
            guna2Button2.CheckedState.ForeColor = Color.Black;
            guna2Button2.CustomBorderThickness = new Padding(4, 0, 0, 0);
            guna2Button2.CustomizableEdges = customizableEdges9;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.Transparent;
            guna2Button2.Font = new Font("Segoe UI", 10F);
            guna2Button2.ForeColor = Color.Black;
            guna2Button2.Location = new Point(12, 104);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Button2.Size = new Size(200, 60);
            guna2Button2.TabIndex = 0;
            guna2Button2.Text = "Quản lý Danh mục";
            guna2Button2.TextAlign = HorizontalAlignment.Left;
            // 
            // btnManageE
            // 
            btnManageE.BackColor = Color.Silver;
            btnManageE.BorderColor = Color.Ivory;
            btnManageE.BorderRadius = 4;
            btnManageE.BorderThickness = 4;
            btnManageE.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnManageE.CheckedState.CustomBorderColor = Color.FromArgb(24, 119, 242);
            btnManageE.CheckedState.FillColor = Color.FromArgb(230, 240, 253);
            btnManageE.CheckedState.ForeColor = Color.Black;
            btnManageE.CustomBorderThickness = new Padding(4, 0, 0, 0);
            btnManageE.CustomizableEdges = customizableEdges11;
            btnManageE.DisabledState.BorderColor = Color.DarkGray;
            btnManageE.DisabledState.CustomBorderColor = Color.DarkGray;
            btnManageE.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnManageE.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnManageE.FillColor = Color.Transparent;
            btnManageE.Font = new Font("Segoe UI", 10F);
            btnManageE.ForeColor = Color.Black;
            btnManageE.Location = new Point(12, 15);
            btnManageE.Name = "btnManageE";
            btnManageE.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnManageE.Size = new Size(200, 60);
            btnManageE.TabIndex = 0;
            btnManageE.Text = "Quản lý Nhân viên";
            btnManageE.TextAlign = HorizontalAlignment.Left;
            btnManageE.Click += btnQuanLyNhanVien_Click;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(238, 240, 246);
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "AdminMainForm";
            Text = "AdminMainForm";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label mainTitle;
        private Button btnLogout;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private Guna.UI2.WinForms.Guna2Button btnManageE;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}