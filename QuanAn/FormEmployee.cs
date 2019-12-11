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
    public partial class FormEmployee : Form
    {
        bool Them;
        string imagepath;
        Employee emp = new Employee();
        public FormEmployee()
        {
            InitializeComponent();
        }

        void resettext()
        {
            txtMaNV.ResetText();
            txtHoTen.ResetText();
            txtDiaChi.ResetText();
            txtSoDT.ResetText();
            dtpDOB.ResetText();
            dtpHireDate.ResetText();
        }
        
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            Them = true;
            resettext();
            picEmployee.Image = null;
            groupBox1.Enabled = true;
            txtMaNV.Enabled = false;
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            btnThem.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            txtHoTen.Focus();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
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
            txtMaNV.Enabled = false;
            txtHoTen.Focus();
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (Them)
            {
                //Dùng phương thức trong Employee
                emp.Name = txtHoTen.Text;
                emp.DOB = dtpDOB.Value.Date;
                emp.Address = txtDiaChi.Text;
                emp.Phone = txtSoDT.Text;
                emp.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                emp.HireDate = dtpHireDate.Value.Date;
                emp.Image = imagepath;
                emp.AddData();
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
                    int r = dgvNV.CurrentCell.RowIndex;
                    // MaKH hiện hành 
                    int idEm = Convert.ToInt32(dgvNV.Rows[r].Cells[0].Value.ToString());

                    //Dùng Phương thức trong Employee
                    emp.ID = idEm;
                    emp.Name = txtHoTen.Text;
                    emp.DOB = dtpDOB.Value.Date;
                    emp.Address = txtDiaChi.Text;
                    emp.Phone = txtSoDT.Text;
                    emp.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                    emp.HireDate = dtpHireDate.Value.Date;
                    emp.Image = imagepath;
                    emp.Update();

                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
                    resettext();
                    groupBox1.Enabled = false;
                    picEmployee.Image = null;
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

        private void btnHuy_Click_1(object sender, EventArgs e)
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

        private void btnDel_Click_1(object sender, EventArgs e)
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
                        //Dùng phương thức trong Employee
                        int idEm = Convert.ToInt32(txtMaNV.Text);
                        emp.ID = idEm;
                        emp.DeleteData();


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

        private void btnLayAnh_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picEmployee.Image = System.Drawing.Image.FromFile(ofd.FileName);

                    imagepath = ofd.FileName;
                }
            }
        }

        private void dgvNV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvNV.CurrentCell.RowIndex;
                this.txtMaNV.Text = dgvNV.Rows[r].Cells["ID"].Value.ToString();
                this.txtHoTen.Text = dgvNV.Rows[r].Cells["Name"].Value.ToString();
                this.dtpDOB.Text = dgvNV.Rows[r].Cells["DOB"].Value.ToString();
                this.txtDiaChi.Text = dgvNV.Rows[r].Cells["Address"].Value.ToString();
                this.txtSoDT.Text = dgvNV.Rows[r].Cells["Phone"].Value.ToString();
                this.dtpHireDate.Text = dgvNV.Rows[r].Cells["HireDate"].Value.ToString();
                if (dgvNV.Rows[r].Cells["Sex"].Value.ToString() == "Nam") rdbNam.Checked = true; else rdbNam.Checked = false;
                if (dgvNV.Rows[r].Cells["Sex"].Value.ToString() == "Nữ") rdbNu.Checked = true; else rdbNu.Checked = false;
                if (dgvNV.Rows[r].Cells["Image"].Value != null && dgvNV.Rows[r].Cells["Image"].Value != "")
                {
                    this.picEmployee.Image = System.Drawing.Image.FromFile(dgvNV.Rows[r].Cells["Image"].Value.ToString());
                }
                else this.picEmployee.Image = null;
            }
            catch
            { }
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            dgvNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNV.AllowUserToAddRows = false;
            dgvNV.ReadOnly = true;
            LoadData();
            //// Không cho thao tác trên các nút Lưu / Hủy
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
            //// Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_2(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            FormManage f = new FormManage();
            this.Hide();
            f.ShowDialog();
        }

        void LoadData()
        {
            using (StoreContext db = new StoreContext())
            {
                var result = from c in db.Employees
                             select new
                             {
                                 ID = c.ID,
                                 Name = c.Name,
                                 Address = c.Address,
                                 DOB = c.DOB,
                                 Phone = c.Phone,
                                 Sex = c.Sex,
                                 HireDate = c.HireDate,
                                 Image = c.Image
                             };
                dgvNV.DataSource = result.ToList();
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbSDT.Checked) //tìm theo mã SV
            {
                using (StoreContext db = new StoreContext())
                {

                    var result = from c in db.Employees
                                 where c.Phone.Contains(txtSearch.Text)
                                 select new
                                 {
                                     ID = c.ID,
                                     Name = c.Name,
                                     Address = c.Address,
                                     DOB = c.DOB,
                                     Phone = c.Phone,
                                     Sex = c.Sex,
                                     HireDate = c.HireDate,
                                     Image = c.Image
                                 };
                    dgvNV.DataSource = result.ToList();

                }
            }
            else  //tìm theo Họ Tên SV
            {
                using (StoreContext db = new StoreContext())
                {
                    var result = from c in db.Employees
                                 where c.Name.Contains(txtSearch.Text)
                                 select new
                                 {
                                     ID = c.ID,
                                     Name = c.Name,
                                     Address = c.Address,
                                     DOB = c.DOB,
                                     Phone = c.Phone,
                                     Sex = c.Sex,
                                     HireDate = c.HireDate,
                                     Image = c.Image
                                 };
                    dgvNV.DataSource = result.ToList();
                }
            }
        }
    }
}
