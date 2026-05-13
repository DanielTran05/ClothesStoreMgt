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

        // ================= FORM STYLE =================
        private void InitForm()
        {
            this.Text = "Xử Lý Khiếu Nại";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.Size = new Size(500, 300);
        }

        // ================= UI STYLE =================
        private void SetupUI()
        {
            // Label title (nếu có label1)
            if (Controls["lblTitle"] != null)
            {
                Controls["lblTitle"].Font = new Font("Segoe UI", 14, FontStyle.Bold);
                Controls["lblTitle"].ForeColor = Color.FromArgb(52, 152, 219);
            }

            // Textbox phản hồi
            txtResponse.Font = new Font("Segoe UI", 11);
            txtResponse.BorderStyle = BorderStyle.FixedSingle;

            // Button Confirm
            btnConfirm.BackColor = Color.FromArgb(52, 152, 219); // xanh
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Button Cancel
            btnCancel.BackColor = Color.FromArgb(231, 76, 60); // đỏ
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        // ================= CONFIRM =================
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

        // ================= CANCEL =================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}