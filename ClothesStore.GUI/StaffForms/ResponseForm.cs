using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClothesStore.GUI.StaffForms
{
    public partial class ResponseForm : Form
    {
        public string ResponseText { get; private set; }

        public ResponseForm()
        {
            InitializeComponent();
            InitForm();
            SetupUI();
        }

        private void InitForm()
        {
            Text = "Xử Lý Khiếu Nại";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Size = new Size(650, 420);
            MinimumSize = new Size(650, 420);
        }

        private void SetupUI()
        {
            if (Controls["lblTitle"] != null)
            {
                Label lbl = (Label)Controls["lblTitle"];

                lbl.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(52, 152, 219);
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Width = 600;
                lbl.Height = 40;
                lbl.Location = new Point(20, 20);
            }

            txtResponse.Font = new Font("Segoe UI", 11);
            txtResponse.Multiline = true;
            txtResponse.ScrollBars = ScrollBars.Vertical;
            txtResponse.BorderStyle = BorderStyle.FixedSingle;
            txtResponse.Size = new Size(580, 180);
            txtResponse.Location = new Point(20, 80);

            // Confirm
            btnConfirm.BackColor = Color.FromArgb(52, 152, 219);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnConfirm.Size = new Size(120, 40);
            btnConfirm.Location = new Point(90, 300);

            // Pending

            btnPending.BackColor = Color.FromArgb(241, 196, 15);
            btnPending.ForeColor = Color.White;
            btnPending.FlatStyle = FlatStyle.Flat;
            btnPending.FlatAppearance.BorderSize = 0;
            btnPending.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPending.Size = new Size(140, 40);
            btnPending.Location = new Point(240, 300);


            Controls.Add(btnPending);

            // Cancel
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnCancel.Size = new Size(120, 40);
            btnCancel.Location = new Point(410, 300);
        }

        // SOLVED
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtResponse.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập phản hồi!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            ResponseText = txtResponse.Text.Trim();

            DialogResult = DialogResult.OK;

            Close();
        }

        // GIỮ PROCESSING
        private void btnPending_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;

            Close();
        }

        // QUAY VỀ NEW
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}