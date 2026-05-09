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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mainTitle = new Label();
            btnLogout = new Button();
            pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            btnStat = new Guna.UI2.WinForms.Guna2Button();
            gtnPriceManagement = new Guna.UI2.WinForms.Guna2Button();
            btnProManagement = new Guna.UI2.WinForms.Guna2Button();
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
            mainTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            mainTitle.Location = new Point(4, 3);
            mainTitle.Margin = new Padding(4, 0, 4, 0);
            mainTitle.Name = "mainTitle";
            mainTitle.Size = new Size(488, 50);
            mainTitle.TabIndex = 0;
            mainTitle.Text = "WELCOME TO ADMIN PAGE";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LemonChiffon;
            btnLogout.Location = new Point(1334, 8);
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
            pnlHeader.Size = new Size(1478, 60);
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
            pnlMain.Size = new Size(1248, 1084);
            pnlMain.TabIndex = 4;
            // 
            // pnlSidebar
            // 
            pnlSidebar.Controls.Add(btnStat);
            pnlSidebar.Controls.Add(gtnPriceManagement);
            pnlSidebar.Controls.Add(btnProManagement);
            pnlSidebar.Controls.Add(guna2Button2);
            pnlSidebar.Controls.Add(btnManageE);
            pnlSidebar.CustomizableEdges = customizableEdges15;
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 60);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlSidebar.Size = new Size(230, 1084);
            pnlSidebar.TabIndex = 3;
            // 
            // btnStat
            // 
            btnStat.BackColor = Color.Silver;
            btnStat.BorderColor = Color.Ivory;
            btnStat.BorderRadius = 4;
            btnStat.BorderThickness = 4;
            btnStat.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnStat.CheckedState.CustomBorderColor = Color.FromArgb(24, 119, 242);
            btnStat.CheckedState.FillColor = Color.FromArgb(230, 240, 253);
            btnStat.CheckedState.ForeColor = Color.Black;
            btnStat.CustomBorderThickness = new Padding(4, 0, 0, 0);
            btnStat.CustomizableEdges = customizableEdges5;
            btnStat.DisabledState.BorderColor = Color.DarkGray;
            btnStat.DisabledState.CustomBorderColor = Color.DarkGray;
            btnStat.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnStat.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnStat.FillColor = Color.Transparent;
            btnStat.Font = new Font("Segoe UI", 10F);
            btnStat.ForeColor = Color.Black;
            btnStat.Location = new Point(12, 375);
            btnStat.Name = "btnStat";
            btnStat.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnStat.Size = new Size(200, 60);
            btnStat.TabIndex = 0;
            btnStat.Text = "Thống kê";
            btnStat.TextAlign = HorizontalAlignment.Left;
            btnStat.Click += btnQuanLyDanhMuc_Click;
            // 
            // gtnPriceManagement
            // 
            gtnPriceManagement.BackColor = Color.Silver;
            gtnPriceManagement.BorderColor = Color.Ivory;
            gtnPriceManagement.BorderRadius = 4;
            gtnPriceManagement.BorderThickness = 4;
            gtnPriceManagement.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            gtnPriceManagement.CheckedState.CustomBorderColor = Color.FromArgb(24, 119, 242);
            gtnPriceManagement.CheckedState.FillColor = Color.FromArgb(230, 240, 253);
            gtnPriceManagement.CheckedState.ForeColor = Color.Black;
            gtnPriceManagement.CustomBorderThickness = new Padding(4, 0, 0, 0);
            gtnPriceManagement.CustomizableEdges = customizableEdges7;
            gtnPriceManagement.DisabledState.BorderColor = Color.DarkGray;
            gtnPriceManagement.DisabledState.CustomBorderColor = Color.DarkGray;
            gtnPriceManagement.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            gtnPriceManagement.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            gtnPriceManagement.FillColor = Color.Transparent;
            gtnPriceManagement.Font = new Font("Segoe UI", 10F);
            gtnPriceManagement.ForeColor = Color.Black;
            gtnPriceManagement.Location = new Point(12, 285);
            gtnPriceManagement.Name = "gtnPriceManagement";
            gtnPriceManagement.ShadowDecoration.CustomizableEdges = customizableEdges8;
            gtnPriceManagement.Size = new Size(200, 60);
            gtnPriceManagement.TabIndex = 0;
            gtnPriceManagement.Text = "Quản lý Giá cả";
            gtnPriceManagement.TextAlign = HorizontalAlignment.Left;
            gtnPriceManagement.Click += btnQuanLyDanhMuc_Click;
            // 
            // btnProManagement
            // 
            btnProManagement.BackColor = Color.Silver;
            btnProManagement.BorderColor = Color.Ivory;
            btnProManagement.BorderRadius = 4;
            btnProManagement.BorderThickness = 4;
            btnProManagement.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnProManagement.CheckedState.CustomBorderColor = Color.FromArgb(24, 119, 242);
            btnProManagement.CheckedState.FillColor = Color.FromArgb(230, 240, 253);
            btnProManagement.CheckedState.ForeColor = Color.Black;
            btnProManagement.CustomBorderThickness = new Padding(4, 0, 0, 0);
            btnProManagement.CustomizableEdges = customizableEdges9;
            btnProManagement.DisabledState.BorderColor = Color.DarkGray;
            btnProManagement.DisabledState.CustomBorderColor = Color.DarkGray;
            btnProManagement.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnProManagement.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnProManagement.FillColor = Color.Transparent;
            btnProManagement.Font = new Font("Segoe UI", 10F);
            btnProManagement.ForeColor = Color.Black;
            btnProManagement.Location = new Point(12, 194);
            btnProManagement.Name = "btnProManagement";
            btnProManagement.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnProManagement.Size = new Size(200, 60);
            btnProManagement.TabIndex = 0;
            btnProManagement.Text = "Quản lý Sản phẩm";
            btnProManagement.TextAlign = HorizontalAlignment.Left;
            btnProManagement.Click += btnQuanLySanPham_Click;
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
            guna2Button2.CustomizableEdges = customizableEdges11;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.Transparent;
            guna2Button2.Font = new Font("Segoe UI", 10F);
            guna2Button2.ForeColor = Color.Black;
            guna2Button2.Location = new Point(12, 104);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Button2.Size = new Size(200, 60);
            guna2Button2.TabIndex = 0;
            guna2Button2.Text = "Quản lý Danh mục";
            guna2Button2.TextAlign = HorizontalAlignment.Left;
            guna2Button2.Click += btnQuanLyDanhMuc_Click;
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
            btnManageE.CustomizableEdges = customizableEdges13;
            btnManageE.DisabledState.BorderColor = Color.DarkGray;
            btnManageE.DisabledState.CustomBorderColor = Color.DarkGray;
            btnManageE.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnManageE.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnManageE.FillColor = Color.Transparent;
            btnManageE.Font = new Font("Segoe UI", 10F);
            btnManageE.ForeColor = Color.Black;
            btnManageE.Location = new Point(12, 15);
            btnManageE.Name = "btnManageE";
            btnManageE.ShadowDecoration.CustomizableEdges = customizableEdges14;
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
            ClientSize = new Size(1478, 1144);
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
        private Guna.UI2.WinForms.Guna2Button btnStat;
        private Guna.UI2.WinForms.Guna2Button gtnPriceManagement;
        private Guna.UI2.WinForms.Guna2Button btnProManagement;
    }
}