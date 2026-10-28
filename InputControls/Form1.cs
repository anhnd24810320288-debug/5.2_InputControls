
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RegistrationForm42
{
    public partial class Form1 : Form
    {
        private readonly string chuoiKetNoi =
            "Server=localhost;Port=3306;Database=ql_sinhvien;Uid=root;Pwd=123456;";

        public Form1()
        {
            InitializeComponent();

            cboCourse.DisplayMember = "TenKhoaHoc";
            cboCourse.ValueMember = "MaKhoaHoc";
            cboCourse.DataSource = new List<KhoaHoc>
            {
                new KhoaHoc { MaKhoaHoc = "C01", TenKhoaHoc = "Lập trình C#" },
                new KhoaHoc { MaKhoaHoc = "C02", TenKhoaHoc = "Thiết kế Web" },
                new KhoaHoc { MaKhoaHoc = "C03", TenKhoaHoc = "Cơ sở dữ liệu" },
                new KhoaHoc { MaKhoaHoc = "C04", TenKhoaHoc = "An ninh mạng" }
            };

            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.MaxDate = DateTime.Today;

            mtxtPhone.Mask = "(000) 000-0000";
            dtpBirthDate.Value = new DateTime(2005, 1, 1);

            AcceptButton = btnRegister;
            CancelButton = btnExit;

            btnRegister.Click += btnRegister_Click;
            btnReset.Click += btnReset_Click;
            btnExit.Click += btnExit_Click;

            txtFullName.TextChanged += txtFullName_TextChanged;
            mtxtPhone.TextChanged += mtxtPhone_TextChanged;
            cboCourse.SelectedIndexChanged += cboCourse_SelectedIndexChanged;
            rdoMale.CheckedChanged += rdoMale_CheckedChanged;
            rdoFemale.CheckedChanged += rdoFemale_CheckedChanged;
        }

        private class KhoaHoc
        {
            public string MaKhoaHoc { get; set; } = "";
            public string TenKhoaHoc { get; set; } = "";
        }

        private bool KiemTraDuLieu()
        {
            errorProvider1.Clear();
            bool hopLe = true;

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Vui lòng nhập họ tên.");
                hopLe = false;
            }

            if (!mtxtPhone.MaskCompleted)
            {
                errorProvider1.SetError(mtxtPhone, "Vui lòng nhập đủ số điện thoại.");
                hopLe = false;
            }

            if (cboCourse.SelectedItem == null)
            {
                errorProvider1.SetError(cboCourse, "Vui lòng chọn khóa học.");
                hopLe = false;
            }

            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                errorProvider1.SetError(grpGender, "Vui lòng chọn giới tính.");
                hopLe = false;
            }

            if (dtpBirthDate.Value.Date > DateTime.Today)
            {
                errorProvider1.SetError(dtpBirthDate, "Ngày sinh không được ở tương lai.");
                hopLe = false;
            }

            if (!hopLe)
            {
                MessageBox.Show(
                    "Vui lòng kiểm tra các thông tin còn thiếu.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return hopLe;
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            KhoaHoc khoaHoc = (KhoaHoc)cboCourse.SelectedItem!;
            string gioiTinh = rdoMale.Checked ? "Nam" : "Nữ";

            List<string> soThich = new List<string>();

            if (chkProgramming.Checked)
                soThich.Add("Lập trình");

            if (chkGaming.Checked)
                soThich.Add("Trò chơi");

            if (chkSports.Checked)
                soThich.Add("Thể thao");

            if (chkMusic.Checked)
                soThich.Add("Âm nhạc");

            string danhSachSoThich = soThich.Count > 0
                ? string.Join(", ", soThich)
                : "Chưa chọn";

            try
            {
                using (MySqlConnection ketNoi =
                       new MySqlConnection(chuoiKetNoi))
                {
                    ketNoi.Open();

                    string sql = @"
                        INSERT INTO DangKyHocVien
                        (HoTen, SoDienThoai, NgaySinh, GioiTinh,
                         MaKhoaHoc, TenKhoaHoc, SoThich)
                        VALUES
                        (@HoTen, @SoDienThoai, @NgaySinh, @GioiTinh,
                         @MaKhoaHoc, @TenKhoaHoc, @SoThich);";

                    using (MySqlCommand lenh =
                           new MySqlCommand(sql, ketNoi))
                    {
                        lenh.Parameters.AddWithValue(
                            "@HoTen", txtFullName.Text.Trim());

                        lenh.Parameters.AddWithValue(
                            "@SoDienThoai", mtxtPhone.Text);

                        lenh.Parameters.AddWithValue(
                            "@NgaySinh", dtpBirthDate.Value.Date);

                        lenh.Parameters.AddWithValue(
                            "@GioiTinh", gioiTinh);

                        lenh.Parameters.AddWithValue(
                            "@MaKhoaHoc", khoaHoc.MaKhoaHoc);

                        lenh.Parameters.AddWithValue(
                            "@TenKhoaHoc", khoaHoc.TenKhoaHoc);

                        lenh.Parameters.AddWithValue(
                            "@SoThich", danhSachSoThich);

                        lenh.ExecuteNonQuery();
                    }
                }

                string thongTin =
                    "ĐĂNG KÝ HỌC VIÊN THÀNH CÔNG!\n" +
                    "(Thông tin đã được lưu vào MySQL)\n\n" +
                    "Họ tên: " + txtFullName.Text.Trim() + "\n" +
                    "Số điện thoại: " + mtxtPhone.Text + "\n" +
                    "Ngày sinh: " +
                    dtpBirthDate.Value.ToString("dd/MM/yyyy") + "\n" +
                    "Giới tính: " + gioiTinh + "\n" +
                    "Khóa học: " + khoaHoc.TenKhoaHoc + "\n" +
                    "Mã khóa học: " + khoaHoc.MaKhoaHoc + "\n" +
                    "Sở thích: " + danhSachSoThich;

                MessageBox.Show(
                    thongTin,
                    "Đăng ký thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Không thể lưu thông tin vào MySQL.\n\n" +
                    "Hãy kiểm tra MySQL Server, database, bảng " +
                    "DangKyHocVien và mật khẩu kết nối.\n\n" +
                    "Chi tiết: " + ex.Message,
                    "Lỗi MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Đã xảy ra lỗi: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object? sender, EventArgs e)
        {
            txtFullName.Clear();
            mtxtPhone.Clear();
            dtpBirthDate.Value = new DateTime(2005, 1, 1);

            rdoMale.Checked = false;
            rdoFemale.Checked = false;

            chkProgramming.Checked = false;
            chkGaming.Checked = false;
            chkSports.Checked = false;
            chkMusic.Checked = false;

            if (cboCourse.Items.Count > 0)
                cboCourse.SelectedIndex = 0;

            errorProvider1.Clear();
            txtFullName.Focus();
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void txtFullName_TextChanged(object? sender, EventArgs e)
        {
            errorProvider1.SetError(txtFullName, "");
        }

        private void mtxtPhone_TextChanged(object? sender, EventArgs e)
        {
            errorProvider1.SetError(mtxtPhone, "");
        }

        private void cboCourse_SelectedIndexChanged(object? sender, EventArgs e)
        {
            errorProvider1.SetError(cboCourse, "");
        }

        private void rdoMale_CheckedChanged(object? sender, EventArgs e)
        {
            if (rdoMale.Checked || rdoFemale.Checked)
                errorProvider1.SetError(grpGender, "");
        }

        private void rdoFemale_CheckedChanged(object? sender, EventArgs e)
        {
            if (rdoMale.Checked || rdoFemale.Checked)
                errorProvider1.SetError(grpGender, "");
        }
    }
}
