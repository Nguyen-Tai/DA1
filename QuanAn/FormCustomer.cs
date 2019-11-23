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
    public partial class FormCustomer : Form
    {
        bool Them;
        string imagepath;
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
        void LoadData()
        {
            using (StoreContext db = new StoreContext())
            {
                var result = from c in db.Customers
                             select new
                             {
                                 ID = c.ID,
                                 Name = c.Name,
                                 Address = c.Address,
                                 DOB = c.DOB,
                                 Phone = c.Phone,
                                 Sex = c.Sex,
                                 Wallet = c.Wallet,
                                 Image = c.Image
                             };
                dgvKH.DataSource = result.ToList();
            }

        }
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            dgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKH.AllowUserToAddRows = false;
            dgvKH.ReadOnly = true;
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
                using (StoreContext db = new StoreContext())
                {
                    var customer = new Customer();
                    customer.Name = txtHoTen.Text;
                    customer.DOB = dtpDOB.Value.Date;
                    customer.Address = txtDiaChi.Text;
                    customer.Phone = txtSoDT.Text;
                    customer.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                    customer.Wallet = Convert.ToInt32(txtWallet.Text);
                    customer.Image = imagepath;
                    db.Customers.Add(customer);
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
                    int r = dgvKH.CurrentCell.RowIndex;
                    // MaKH hiện hành 
                    int idEm = Convert.ToInt32(dgvKH.Rows[r].Cells[0].Value.ToString());
                    // Câu lệnh SQL 
                    StoreContext db = new StoreContext();
                    var khQuery = (from em in db.Customers
                                   where em.ID == idEm
                                   select em).SingleOrDefault();
                    if (khQuery != null)
                    {
                        khQuery.Name = txtHoTen.Text;
                        khQuery.DOB = dtpDOB.Value.Date;
                        khQuery.Address = txtDiaChi.Text;
                        khQuery.Phone = txtSoDT.Text;
                        khQuery.Sex = (rdbNam.Checked) ? "Nam" : "Nữ";
                        khQuery.Wallet = Convert.ToInt32(txtWallet.Text);
                        khQuery.Image = imagepath;
                        db.SaveChanges();
                        LoadData();
                    }
                    // Load lại dữ liệu trên DataGridView 
                    LoadData();
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
                        StoreContext db = new StoreContext();
                        int idEm = Convert.ToInt32(txtMaKH.Text);
                        var nvQuery = from em in db.Customers
                                      where em.ID == idEm
                                      select em;
                        db.Customers.RemoveRange(nvQuery);
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
    }
}
