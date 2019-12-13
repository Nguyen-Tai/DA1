using QuanAn.Models;
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
    public partial class FormLoginManage : Form
    {
        bool Them;
        Account acc = new Account();
        public FormLoginManage()
        {
            InitializeComponent();
        }
        void resettext()
        {
            txtUserName.ResetText();
            txtPassword.ResetText();
            txtNVID.ResetText();
        }
        void LoadData()
        {
            using (StoreContext db = new StoreContext())
            {
                var result = from c in db.Accounts
                             select new
                             {
                                 Username = c.Username,
                                 Password = c.Password,                               
                                 IsAdmin = c.IsAdmin,
                                 Employee_ID=c.Employee_ID
                             };
                dgvAcc.DataSource = result.ToList();
            }
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            FormManage f = new FormManage();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Them)
            {

                acc.Username = txtUserName.Text.Trim();
                acc.Password = txtPassword.Text.Trim();
                acc.IsAdmin = (rdbAdmin.Checked) ? true : false;
                acc.Employee_ID = Convert.ToInt32(txtNVID.Text);
                acc.AddData();
                dgvAcc.DataSource = acc.LoadData();
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

                    // Dùng phương thức trong Account
                    acc.Username = txtUserName.Text;
                    acc.IsAdmin = (rdbAdmin.Checked) ? true : false;
                    acc.Password = txtPassword.Text;
                    acc.Employee_ID = Convert.ToInt32(txtNVID.Text);
                    acc.Update();


                    // Load lại dữ liệu trên DataGridView 

                    dgvAcc.DataSource = acc.LoadData();
                    resettext();
                    groupBox2.Enabled = false;

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
            groupBox2.Enabled = true;
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            txtUserName.Focus();
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
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
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
                        string user = txtUserName.Text;
                        acc.Username = user;
                        acc.DeleteData();

                        // Cập nhật lại DataGridView 

                        dgvAcc.DataSource = acc.LoadData();
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

        private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvAcc.CurrentCell.RowIndex;
                this.txtUserName.Text = dgvAcc.Rows[r].Cells["Username"].Value.ToString();
                this.txtPassword.Text = dgvAcc.Rows[r].Cells["Password"].Value.ToString();
                this.txtNVID.Text = dgvAcc.Rows[r].Cells["Employee_ID"].Value.ToString();
                if (dgvAcc.Rows[r].Cells["IsAdmin"].Value.ToString() == "True") rdbAdmin.Checked = true; else rdbAdmin.Checked = false;
                if (dgvAcc.Rows[r].Cells["IsAdmin"].Value.ToString() == "False") rdbEmployee.Checked = true; else rdbEmployee.Checked = false;

            }
            catch
            { }
        }

        private void rdbEmployee_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormLoginManage_Load(object sender, EventArgs e)
        {

            dgvAcc.DataSource = acc.LoadData();
            dgvAcc.ReadOnly = true;
            dgvAcc.AllowUserToAddRows = false;
            dgvAcc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAcc.BackgroundColor = Color.White;
            dgvAcc.RowHeadersVisible = false;
            dgvAcc.DefaultCellStyle.Font = new Font("UTM", 8, FontStyle.Regular);
            groupBox2.Enabled = false;
            btnCapNhat.Enabled = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbID.Checked) //tìm theo mã SV
            {

                if(txtSearch.Text =="")
                {
                    dgvAcc.DataSource = acc.LoadData();
                }
                else
                {
                    acc.Employee_ID = Convert.ToInt32(txtSearch.Text);
                    dgvAcc.DataSource = acc.FindID();
                }
                
            }
            else  
            {                
                acc.Username = txtSearch.Text;
                dgvAcc.DataSource = acc.FindUserName();
            }
            
        }

        private void btnChose_Click(object sender, EventArgs e)
        {

        }
    }
}
