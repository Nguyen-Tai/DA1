﻿namespace QuanAn
{
    partial class FormEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployee));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLayAnh = new System.Windows.Forms.Button();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.picEmployee = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.txtSoDT = new System.Windows.Forms.MaskedTextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdbTen = new System.Windows.Forms.RadioButton();
            this.rdbSDT = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpHireDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnLayAnh);
            this.groupBox1.Controls.Add(this.dtpDOB);
            this.groupBox1.Controls.Add(this.picEmployee);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.pictureBox11);
            this.groupBox1.Controls.Add(this.pictureBox10);
            this.groupBox1.Controls.Add(this.txtSoDT);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("UTM Bebas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(340, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 292);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 73;
            this.label1.Text = "Ngày Thuê";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.Font = new System.Drawing.Font("UTM Bebas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHireDate.Location = new System.Drawing.Point(310, 250);
            this.dtpHireDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(156, 26);
            this.dtpHireDate.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(229, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 69;
            this.label6.Text = "Ngày Sinh";
            // 
            // btnLayAnh
            // 
            this.btnLayAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLayAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLayAnh.Font = new System.Drawing.Font("Myriad Pro Cond", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayAnh.ForeColor = System.Drawing.Color.White;
            this.btnLayAnh.Location = new System.Drawing.Point(50, 206);
            this.btnLayAnh.Margin = new System.Windows.Forms.Padding(2);
            this.btnLayAnh.Name = "btnLayAnh";
            this.btnLayAnh.Size = new System.Drawing.Size(126, 30);
            this.btnLayAnh.TabIndex = 71;
            this.btnLayAnh.Text = "Cập nhật ảnh ";
            this.btnLayAnh.UseVisualStyleBackColor = false;
            this.btnLayAnh.Click += new System.EventHandler(this.btnLayAnh_Click_1);
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("UTM Bebas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Location = new System.Drawing.Point(310, 100);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(156, 26);
            this.dtpDOB.TabIndex = 68;
            // 
            // picEmployee
            // 
            this.picEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEmployee.ErrorImage = null;
            this.picEmployee.Location = new System.Drawing.Point(32, 47);
            this.picEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.picEmployee.Name = "picEmployee";
            this.picEmployee.Size = new System.Drawing.Size(156, 152);
            this.picEmployee.TabIndex = 70;
            this.picEmployee.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbNu);
            this.groupBox5.Controls.Add(this.rdbNam);
            this.groupBox5.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(222, 201);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(243, 42);
            this.groupBox5.TabIndex = 69;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Giới Tính";
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(184, 15);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Size = new System.Drawing.Size(40, 24);
            this.rdbNu.TabIndex = 1;
            this.rdbNu.TabStop = true;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Location = new System.Drawing.Point(88, 15);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Size = new System.Drawing.Size(50, 24);
            this.rdbNam.TabIndex = 0;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.ErrorImage = null;
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(769, 6);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(33, 35);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 68;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.ErrorImage = null;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(793, -33);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(33, 35);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 67;
            this.pictureBox10.TabStop = false;
            // 
            // txtSoDT
            // 
            this.txtSoDT.Font = new System.Drawing.Font("UTM Bebas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDT.ForeColor = System.Drawing.Color.Black;
            this.txtSoDT.Location = new System.Drawing.Point(310, 170);
            this.txtSoDT.Name = "txtSoDT";
            this.txtSoDT.Size = new System.Drawing.Size(156, 26);
            this.txtSoDT.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("UTM Bebas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.ForeColor = System.Drawing.Color.Black;
            this.txtDiaChi.Location = new System.Drawing.Point(310, 134);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(156, 26);
            this.txtDiaChi.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(229, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(229, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("UTM Bebas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtMaNV.Location = new System.Drawing.Point(310, 27);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(156, 26);
            this.txtMaNV.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(229, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 20);
            this.label8.TabIndex = 50;
            this.label8.Text = "SĐT";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("UTM Bebas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Black;
            this.txtHoTen.Location = new System.Drawing.Point(310, 63);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(156, 26);
            this.txtHoTen.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(229, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Họ và tên";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnCapNhat);
            this.groupBox6.Controls.Add(this.btnHuy);
            this.groupBox6.Controls.Add(this.btnThem);
            this.groupBox6.Controls.Add(this.btnTim);
            this.groupBox6.Controls.Add(this.btnEdit);
            this.groupBox6.Controls.Add(this.btnDel);
            this.groupBox6.Controls.Add(this.txtSearch);
            this.groupBox6.Controls.Add(this.rdbTen);
            this.groupBox6.Controls.Add(this.rdbSDT);
            this.groupBox6.Font = new System.Drawing.Font("UTM Bebas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(27, 76);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(293, 292);
            this.groupBox6.TabIndex = 77;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tìm kiếm";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.Location = new System.Drawing.Point(182, 110);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(92, 39);
            this.btnCapNhat.TabIndex = 54;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click_1);
            // 
            // btnHuy
            // 
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHuy.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(182, 170);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(92, 39);
            this.btnHuy.TabIndex = 58;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(26, 170);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 39);
            this.btnThem.TabIndex = 52;
            this.btnThem.Text = "Nhập";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(217, 47);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(58, 29);
            this.btnTim.TabIndex = 9;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(26, 232);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 39);
            this.btnEdit.TabIndex = 55;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnDel
            // 
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDel.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(182, 233);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(92, 39);
            this.btnDel.TabIndex = 57;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("UTM Bebas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(22, 47);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(163, 26);
            this.txtSearch.TabIndex = 2;
            // 
            // rdbTen
            // 
            this.rdbTen.AutoSize = true;
            this.rdbTen.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTen.Location = new System.Drawing.Point(26, 118);
            this.rdbTen.Name = "rdbTen";
            this.rdbTen.Size = new System.Drawing.Size(127, 24);
            this.rdbTen.TabIndex = 1;
            this.rdbTen.TabStop = true;
            this.rdbTen.Text = "Theo Tên Nhân Viên";
            this.rdbTen.UseVisualStyleBackColor = true;
            // 
            // rdbSDT
            // 
            this.rdbSDT.AutoSize = true;
            this.rdbSDT.Font = new System.Drawing.Font("UTM Bebas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSDT.Location = new System.Drawing.Point(26, 88);
            this.rdbSDT.Name = "rdbSDT";
            this.rdbSDT.Size = new System.Drawing.Size(122, 24);
            this.rdbSDT.TabIndex = 0;
            this.rdbSDT.TabStop = true;
            this.rdbSDT.Text = "Theo số điện thoại";
            this.rdbSDT.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("UTM Bebas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(274, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(316, 40);
            this.label17.TabIndex = 76;
            this.label17.Text = "Quản Lý Thông Tin Nhân viên";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvNV);
            this.groupBox2.Font = new System.Drawing.Font("UTM Bebas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 387);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(810, 206);
            this.groupBox2.TabIndex = 75;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dgvNV
            // 
            this.dgvNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNV.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name,
            this.DOB,
            this.Address,
            this.Phone,
            this.Sex,
            this.HireDate,
            this.Image});
            this.dgvNV.Location = new System.Drawing.Point(14, 27);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.RowHeadersWidth = 51;
            this.dgvNV.Size = new System.Drawing.Size(779, 176);
            this.dgvNV.TabIndex = 0;
            this.dgvNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNV_CellClick_1);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 41.80035F;
            this.ID.HeaderText = "Mã NV";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.FillWeight = 41.80035F;
            this.Name.HeaderText = "Họ Tên";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            // 
            // DOB
            // 
            this.DOB.DataPropertyName = "DOB";
            this.DOB.FillWeight = 41.80035F;
            this.DOB.HeaderText = "Ngày Sinh";
            this.DOB.MinimumWidth = 6;
            this.DOB.Name = "DOB";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.FillWeight = 41.80035F;
            this.Address.HeaderText = "Địa Chỉ";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.FillWeight = 41.80035F;
            this.Phone.HeaderText = "Số ĐT";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "Sex";
            this.Sex.FillWeight = 40F;
            this.Sex.HeaderText = "Giới Tính";
            this.Sex.MinimumWidth = 6;
            this.Sex.Name = "Sex";
            // 
            // HireDate
            // 
            this.HireDate.DataPropertyName = "HireDate";
            this.HireDate.FillWeight = 41.80035F;
            this.HireDate.HeaderText = "Ngày Thuê";
            this.HireDate.MinimumWidth = 6;
            this.HireDate.Name = "HireDate";
            // 
            // Image
            // 
            this.Image.DataPropertyName = "Image";
            this.Image.HeaderText = "Ảnh";
            this.Image.MinimumWidth = 6;
            this.Image.Name = "Image";
            this.Image.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = global::QuanAn.Properties.Resources.door_exit;
            this.pictureBox2.Location = new System.Drawing.Point(772, 25);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 81;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click_2);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = global::QuanAn.Properties.Resources._1_power_off_on_shutdown_512;
            this.pictureBox3.Location = new System.Drawing.Point(806, 25);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 80;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_2);
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanAn.Properties.Resources.DpyRQk5VAAEhhSc;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(866, 609);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEmployee";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLayAnh;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.PictureBox picEmployee;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.MaskedTextBox txtSoDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdbTen;
        private System.Windows.Forms.RadioButton rdbSDT;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn HireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Image;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}