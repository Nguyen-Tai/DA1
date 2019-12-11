﻿using QuanAn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn
{
    public partial class FoodManager : Form
    {
        bool Them;
        string imagepath;
        Food fd = new Food();
        public FoodManager()
        {
            InitializeComponent();
        }

        private void FoodManager_Load(object sender, EventArgs e)
        {
            dgvMA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMA.AllowUserToAddRows = false;
            dgvMA.ReadOnly = true;
            LoadData();
            LoadCombobox();
            cmbLoai.ValueMember = "ID";
            cmbLoai.DisplayMember = "Name";
            //// Không cho thao tác trên các nút Lưu / Hủy
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
            //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            groupBox2.Enabled = false;
        }
        void resettext()
        {
            txtMaMA.ResetText();
            txtTen.ResetText();
            txtDonVi.ResetText();
            txtDonGia.ResetText();
            cmbLoai.ResetText();
        }
        void LoadCombobox()
        {
            using (StoreContext db = new StoreContext())
            {
                var result = from c in db.Categories
                             select new
                             {
                                 c.ID,
                                 c.Name
                             };
                cmbLoai.DataSource = result.ToList();
            }
        }
        void LoadData()
        {
            using (StoreContext db = new StoreContext())
            {
                var result = from c in db.Foods
                             select new
                             {
                                 ID = c.ID,
                                 Name = c.Name,
                                 Unit = c.Unit,
                                 Price = c.Price,
                                 Category_ID = c.Category.Name,
                                 Image = c.Image
                             };
                dgvMA.DataSource = result.ToList();
            }

        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                fd.Name = txtTen.Text;
                fd.Unit = txtDonVi.Text;
                fd.Price = Convert.ToInt32(txtDonGia.Text);
                fd.Category_ID = Convert.ToInt32(cmbLoai.SelectedValue.ToString());
                fd.Image = imagepath;
                fd.AddData();
                LoadData();
                resettext();
                //// Không cho thao tác trên các nút Lưu / Hủy
                btnCapNhat.Enabled = false;
                btnHuy.Enabled = false;
                //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                btnThem.Enabled = true;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                //Ghi chú nên xóa chuỗi imagepath !!
                // Thông báo         
                MessageBox.Show("Đã thêm xong!");
            }
            else
            {
                try
                {
                    // Thứ tự dòng hiện hành 
                    int r = dgvMA.CurrentCell.RowIndex;
                    // MaKH hiện hành 
                    int idEm = Convert.ToInt32(dgvMA.Rows[r].Cells[0].Value.ToString());
                    //Dùng phương thức trong Food
                    fd.ID = idEm;
                    fd.Name = txtTen.Text;
                    fd.Unit = txtDonVi.Text;
                    fd.Price = Convert.ToInt32(txtDonGia.Text);
                    fd.Category_ID = Convert.ToInt32(cmbLoai.SelectedValue.ToString());
                    fd.Image = imagepath;
                    fd.Update();

                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    resettext();
                    groupBox2.Enabled = false;
                    pictureBox1.Image = null;
                    //// Không cho thao tác trên các nút Lưu / Hủy
                    btnCapNhat.Enabled = false;
                    btnHuy.Enabled = false;
                    //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                    btnThem.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    // Thông báo 
                    MessageBox.Show("Đã sửa xong!");

                }
                catch
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            resettext();
            pictureBox1.Image = null;
            groupBox2.Enabled = true;
            txtMaMA.Enabled = false;
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            txtTen.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            resettext();
            groupBox2.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            groupBox2.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            // Đưa con trỏ đến TextField 
            txtMaMA.Enabled = false;
            txtTen.Focus();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            try
            {
                // Hiện thông báo xác nhận việc xóa mẫu tin       
                // Khai báo biến traloi            
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp    
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?           
                if (traloi == DialogResult.Yes)
                {
                    try
                    {
                        int idEm = Convert.ToInt32(txtMaMA.Text);
                        fd.ID = idEm;
                        fd.DeleteData();
                        // Cập nhật lại DataGridView 
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    catch
                    {
                        MessageBox.Show("Không xóa được. Lỗi rồi!!!");
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi");
            }
        }

        private void btnLayAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(ofd.FileName);

                    imagepath = ofd.FileName;
                }
            }
        }

        private void dgvMA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvMA.CurrentCell.RowIndex;
                this.txtMaMA.Text = dgvMA.Rows[r].Cells["ID"].Value.ToString();
                this.txtTen.Text = dgvMA.Rows[r].Cells["Name"].Value.ToString();
                this.txtDonVi.Text = dgvMA.Rows[r].Cells["Unit"].Value.ToString();
                this.txtDonGia.Text = dgvMA.Rows[r].Cells["Price"].Value.ToString();
                this.cmbLoai.Text = dgvMA.Rows[r].Cells["Category_ID"].Value.ToString();
                if (dgvMA.Rows[r].Cells["Image"].Value != null && dgvMA.Rows[r].Cells["Image"].Value != "")
                {
                    this.pictureBox1.Image = System.Drawing.Image.FromFile(dgvMA.Rows[r].Cells["Image"].Value.ToString());
                }
                else this.pictureBox1.Image = null;
            }
            catch
            { }
        }

        private void rdbSDT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormManage f = new FormManage();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbLoai.Checked) //tìm theo mã SV
            {
                using (StoreContext db = new StoreContext())
                {

                    var result = from c in db.Foods
                                 where c.Category.Name.Contains(txtSearch.Text)
                                 select new
                                 {
                                     ID = c.ID,
                                     Name = c.Name,
                                     Unit = c.Unit,
                                     Price = c.Price,
                                     Category_ID = c.Category.Name,
                                     Image = c.Image
                                 };
                    dgvMA.DataSource = result.ToList();

                }
            }
            else  //tìm theo Họ Tên SV
            {
                using (StoreContext db = new StoreContext())
                {
                    var result = from c in db.Foods
                                 where c.Name.Contains(txtSearch.Text)
                                 select new
                                 {
                                     ID = c.ID,
                                     Name = c.Name,
                                     Unit = c.Unit,
                                     Price = c.Price,
                                     Category_ID = c.Category.Name,
                                     Image = c.Image
                                 };
                    dgvMA.DataSource = result.ToList();
                }
            }
        }
    }
}
