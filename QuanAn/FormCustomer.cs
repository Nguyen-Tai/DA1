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
    public partial class FormCustomer : Form
    {
        bool Them;
        string imagepath;
        Customer cus = new Customer();
        public FormCustomer()
        {
            InitializeComponent();
        }

        void resettext()
        {
            txtMaKH.ResetText();
            txtHoTen.ResetText();
            txtDiaChi.ResetText();
            txtSoDT.ResetText();
            dtpDOB.ResetText();
            txtWallet.ResetText();
        }
       
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            dgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKH.AllowUserToAddRows = false;
            dgvKH.ReadOnly = true;
            dgvKH.DataSource = Customer.LoadData();
            //// Không cho thao tác trên các nút Lưu / Hủy
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
            //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            groupBox1.Enabled = false;

            //this.reportViewer1.RefreshReport();
        }

        private void btnLayAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picCustomer.Image = System.Drawing.Image.FromFile(ofd.FileName);

                    imagepath = ofd.FileName;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            resettext();
            picCustomer.Image = null;
            groupBox1.Enabled = true;
            txtMaKH.Enabled = false;
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            txtHoTen.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            groupBox1.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            // Đưa con trỏ đến TextField 
            txtMaKH.Enabled = false;
            txtHoTen.Focus();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                cus.Name = txtHoTen.Text;
                cus.DOB = dtpDOB.Value.Date;
                cus.Address = txtDiaChi.Text;
                cus.Phone = txtSoDT.Text;
                cus.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                cus.Wallet = Convert.ToInt32(txtWallet.Text);
                cus.Image = imagepath;
                cus.AddData();
                dgvKH.DataSource = Customer.LoadData();
                resettext();
                //// Không cho thao tác trên các nút Lưu / Hủy
                btnCapNhat.Enabled = false;
                btnHuy.Enabled = false;
                //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                btnThem.Enabled = true;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
                // Thông báo         
                MessageBox.Show("Đã thêm xong!");
            }
            else
            {
                try
                {
                    // Thứ tự dòng hiện hành 
                    int r = dgvKH.CurrentCell.RowIndex;
                    // MaKH hiện hành 
                    int idEm = Convert.ToInt32(dgvKH.Rows[r].Cells[0].Value.ToString());
                    // Câu lệnh SQL 
                    cus.ID = idEm;
                    cus.Name = txtHoTen.Text;
                    cus.DOB = dtpDOB.Value.Date;
                    cus.Address = txtDiaChi.Text;
                    cus.Phone = txtSoDT.Text;
                    cus.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                    cus.Wallet = Convert.ToInt32(txtWallet.Text);
                    cus.Image = imagepath;
                    cus.Update();
                    // Load lại dữ liệu trên DataGridView 
                    dgvKH.DataSource = Customer.LoadData();
                    resettext();
                    groupBox1.Enabled = false;
                    picCustomer.Image = null;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            resettext();
            groupBox1.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
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
                        int idEm = Convert.ToInt32(txtMaKH.Text);
                        cus.ID = idEm;
                        cus.DeleteData();
                        // Cập nhật lại DataGridView 
                        dgvKH.DataSource = Customer.LoadData();
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

        private void txtWallet_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormManage f = new FormManage();
            this.Hide();
            f.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbTen.Checked) //tìm Name
            {
               
                cus.Name = txtSearch.Text;
                dgvKH.DataSource = cus.FindName();
            }
            else  //tìm theo Phone
            {
       
                cus.Phone = txtSearch.Text;
                dgvKH.DataSource = cus.FindSDT();
            }
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvKH.CurrentCell.RowIndex;
                this.txtMaKH.Text = dgvKH.Rows[r].Cells["ID"].Value.ToString();
                this.txtHoTen.Text = dgvKH.Rows[r].Cells["Name"].Value.ToString();
                this.dtpDOB.Text = dgvKH.Rows[r].Cells["DOB"].Value.ToString();
                this.txtDiaChi.Text = dgvKH.Rows[r].Cells["Address"].Value.ToString();
                this.txtSoDT.Text = dgvKH.Rows[r].Cells["Phone"].Value.ToString();
                this.txtWallet.Text = dgvKH.Rows[r].Cells["Wallet"].Value.ToString();
                if (dgvKH.Rows[r].Cells["Sex"].Value.ToString() == "Nam") rdbNam.Checked = true; else rdbNam.Checked = false;
                if (dgvKH.Rows[r].Cells["Sex"].Value.ToString() == "Nữ") rdbNu.Checked = true; else rdbNu.Checked = false;
                if (dgvKH.Rows[r].Cells["Image"].Value != "" && dgvKH.Rows[r].Cells["Image"].Value != null)
                {
                    this.picCustomer.Image = System.Drawing.Image.FromFile(dgvKH.Rows[r].Cells["Image"].Value.ToString());
                }
                else this.picCustomer.Image = null;
            }
            catch
            { }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
