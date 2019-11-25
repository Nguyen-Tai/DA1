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
        public FormLoginManage()
        {
            InitializeComponent();
        }
        void resettext()
        {
            txtUserName.ResetText();
            txtPassword.ResetText();
            txtTen.ResetText();
            txtSDT.ResetText();
            dtpDOB.ResetText();
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
                                 Name = c.Name,
                                 Phone = c.Phone,
                                 DOB = c.DOB,
                                 Sex = c.Sex,
                                 IsAdmin = c.IsAdmin
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
                using (StoreContext db = new StoreContext())
                {
                    var account = new Account();
                    account.Username = txtUserName.Text;
                    account.Name = txtTen.Text;
                    account.DOB = dtpDOB.Value.Date;
                    account.Password = txtPassword.Text;
                    account.Phone = txtSDT.Text;
                    account.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                    account.IsAdmin = (rdbAdmin.Checked) ? true : false;
                    db.Accounts.Add(account);
                    db.SaveChanges();
                }
                LoadData();
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
                    int r = dgvAcc.CurrentCell.RowIndex;
                    // MaKH hiện hành 
                    String idEm = dgvAcc.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL 
                    StoreContext db = new StoreContext();
                    var khQuery = (from em in db.Accounts
                                   where em.Username == idEm
                                   select em).SingleOrDefault();
                    if (khQuery != null)
                    {
                        khQuery.Name = txtTen.Text;
                        khQuery.DOB = dtpDOB.Value.Date;
                        khQuery.Phone = txtSDT.Text;
                        khQuery.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                        khQuery.IsAdmin = (rdbAdmin.Checked) ? true : false;
                        db.SaveChanges();
                        LoadData();
                    }
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
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
                        StoreContext db = new StoreContext();
                        string idEm = txtUserName.Text;
                        var nvQuery = from em in db.Accounts
                                      where em.Username == idEm
                                      select em;
                        db.Accounts.RemoveRange(nvQuery);
                        db.SaveChanges();
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

        private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvAcc.CurrentCell.RowIndex;
                this.txtUserName.Text = dgvAcc.Rows[r].Cells["Username"].Value.ToString();
                this.txtPassword.Text = dgvAcc.Rows[r].Cells["Password"].Value.ToString();
                this.dtpDOB.Text = dgvAcc.Rows[r].Cells["DOB"].Value.ToString();
                this.txtTen.Text = dgvAcc.Rows[r].Cells["Name"].Value.ToString();
                this.txtSDT.Text = dgvAcc.Rows[r].Cells["Phone"].Value.ToString();
                if (dgvAcc.Rows[r].Cells["Sex"].Value.ToString() == "Nam") rdbNam.Checked = true; else rdbNam.Checked = false;
                if (dgvAcc.Rows[r].Cells["Sex"].Value.ToString() == "Nữ") rdbNu.Checked = true; else rdbNu.Checked = false;
                if (dgvAcc.Rows[r].Cells["IsAdmin"].Value.ToString() == "true") rdbAdmin.Checked = true; else rdbAdmin.Checked = false;
                if (dgvAcc.Rows[r].Cells["IsAdmin"].Value.ToString() == "false") rdbEmployee.Checked = true; else rdbEmployee.Checked = false;

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
    }
}
