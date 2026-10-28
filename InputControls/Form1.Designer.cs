
namespace RegistrationForm42
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitle = new Label();
            lblFullName = new Label();
            lblPhone = new Label();
            lblBirthDate = new Label();
            lblCourse = new Label();

            txtFullName = new TextBox();
            mtxtPhone = new MaskedTextBox();
            dtpBirthDate = new DateTimePicker();
            cboCourse = new ComboBox();

            grpGender = new GroupBox();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();

            grpHobbies = new GroupBox();
            chkProgramming = new CheckBox();
            chkGaming = new CheckBox();
            chkSports = new CheckBox();
            chkMusic = new CheckBox();

            btnRegister = new Button();
            btnReset = new Button();
            btnExit = new Button();

            errorProvider1 = new ErrorProvider(components);

            grpGender.SuspendLayout();
            grpHobbies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 590);
            MinimumSize = new Size(636, 629);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài tập 4.2 - Đăng ký học viên";
            Font = new Font("Segoe UI", 10F);

            // Title
            lblTitle.AutoSize = false;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Size = new Size(560, 42);
            lblTitle.Text = "FORM ĐĂNG KÝ HỌC VIÊN";
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Full name
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(35, 88);
            lblFullName.Text = "Họ và tên:";

            txtFullName.Location = new Point(190, 84);
            txtFullName.Size = new Size(365, 27);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Nhập họ tên học viên";

            // Phone
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(35, 133);
            lblPhone.Text = "Số điện thoại:";

            mtxtPhone.Location = new Point(190, 129);
            mtxtPhone.Size = new Size(365, 27);
            mtxtPhone.Name = "mtxtPhone";
            mtxtPhone.Mask = "(000) 000-0000";

            // Birth date
            lblBirthDate.AutoSize = true;
            lblBirthDate.Location = new Point(35, 178);
            lblBirthDate.Text = "Ngày sinh:";

            dtpBirthDate.Location = new Point(190, 174);
            dtpBirthDate.Size = new Size(365, 27);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.Value = new DateTime(2005, 1, 1);

            // Course
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(35, 223);
            lblCourse.Text = "Khóa học:";

            cboCourse.Location = new Point(190, 219);
            cboCourse.Size = new Size(365, 28);
            cboCourse.Name = "cboCourse";
            cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;

            // Gender
            grpGender.Location = new Point(35, 265);
            grpGender.Size = new Size(520, 75);
            grpGender.Name = "grpGender";
            grpGender.Text = "Giới tính";

            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(25, 32);
            rdoMale.Name = "rdoMale";
            rdoMale.Text = "Nam";

            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(160, 32);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Text = "Nữ";

            grpGender.Controls.Add(rdoMale);
            grpGender.Controls.Add(rdoFemale);

            // Hobbies
            grpHobbies.Location = new Point(35, 355);
            grpHobbies.Size = new Size(520, 105);
            grpHobbies.Name = "grpHobbies";
            grpHobbies.Text = "Sở thích";

            chkProgramming.AutoSize = true;
            chkProgramming.Location = new Point(25, 30);
            chkProgramming.Name = "chkProgramming";
            chkProgramming.Text = "Lập trình";

            chkGaming.AutoSize = true;
            chkGaming.Location = new Point(250, 30);
            chkGaming.Name = "chkGaming";
            chkGaming.Text = "Trò chơi";

            chkSports.AutoSize = true;
            chkSports.Location = new Point(25, 65);
            chkSports.Name = "chkSports";
            chkSports.Text = "Thể thao";

            chkMusic.AutoSize = true;
            chkMusic.Location = new Point(250, 65);
            chkMusic.Name = "chkMusic";
            chkMusic.Text = "Âm nhạc";

            grpHobbies.Controls.Add(chkProgramming);
            grpHobbies.Controls.Add(chkGaming);
            grpHobbies.Controls.Add(chkSports);
            grpHobbies.Controls.Add(chkMusic);

            // Register button
            btnRegister.Location = new Point(65, 490);
            btnRegister.Size = new Size(140, 42);
            btnRegister.Name = "btnRegister";
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;

            // Reset button
            btnReset.Location = new Point(240, 490);
            btnReset.Size = new Size(140, 42);
            btnReset.Name = "btnReset";
            btnReset.Text = "Làm mới";
            btnReset.UseVisualStyleBackColor = true;

            // Exit button
            btnExit.Location = new Point(415, 490);
            btnExit.Size = new Size(120, 42);
            btnExit.Name = "btnExit";
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;

            // ErrorProvider
            errorProvider1.ContainerControl = this;

            // Add controls
            Controls.Add(lblTitle);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblPhone);
            Controls.Add(mtxtPhone);
            Controls.Add(lblBirthDate);
            Controls.Add(dtpBirthDate);
            Controls.Add(lblCourse);
            Controls.Add(cboCourse);
            Controls.Add(grpGender);
            Controls.Add(grpHobbies);
            Controls.Add(btnRegister);
            Controls.Add(btnReset);
            Controls.Add(btnExit);

            grpGender.ResumeLayout(false);
            grpGender.PerformLayout();
            grpHobbies.ResumeLayout(false);
            grpHobbies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle = null!;
        private Label lblFullName = null!;
        private Label lblPhone = null!;
        private Label lblBirthDate = null!;
        private Label lblCourse = null!;

        private TextBox txtFullName = null!;
        private MaskedTextBox mtxtPhone = null!;
        private DateTimePicker dtpBirthDate = null!;
        private ComboBox cboCourse = null!;

        private GroupBox grpGender = null!;
        private RadioButton rdoMale = null!;
        private RadioButton rdoFemale = null!;

        private GroupBox grpHobbies = null!;
        private CheckBox chkProgramming = null!;
        private CheckBox chkGaming = null!;
        private CheckBox chkSports = null!;
        private CheckBox chkMusic = null!;

        private Button btnRegister = null!;
        private Button btnReset = null!;
        private Button btnExit = null!;

        private ErrorProvider errorProvider1 = null!;
    }
}
