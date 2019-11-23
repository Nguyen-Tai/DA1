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
    public partial class FoodManager : Form
    {
        bool Them;
        string imagepath;
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
                using (StoreContext db = new StoreContext())
                {
                    var food = new Food();
                    food.Name = txtTen.Text;
                    food.Unit = txtDonVi.Text;
                    food.Price = Convert.ToInt32(txtDonGia.Text);
                    food.Category_ID = Convert.ToInt32(cmbLoai.SelectedValue.ToString());
                    food.Image = imagepath;
                    db.Foods.Add(food);
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
                    // Câu lệnh SQL 
                    StoreContext db = new StoreContext();
                    var fQuery = (from em in db.Foods
                                  where em.ID == idEm
                                  select em).SingleOrDefault();
                    if (fQuery != null)
                    {
                        fQuery.Name = txtTen.Text;
                        fQuery.Unit = txtDonVi.Text;
                        fQuery.Price = Convert.ToInt32(txtDonGia.Text);
                        fQuery.Category_ID = Convert.ToInt32(cmbLoai.SelectedValue.ToString());
                        fQuery.Image = imagepath;
                        db.SaveChanges();
                        LoadData();
                    }
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
                        StoreContext db = new StoreContext();
                        int idEm = Convert.ToInt32(txtMaMA.Text);
                        var nvQuery = from em in db.Foods
                                      where em.ID == idEm
                                      select em;
                        db.Foods.RemoveRange(nvQuery);
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
                if (dgvMA.Rows[r].Cells["Image"].Value != null)
                {
                    this.pictureBox1.Image = System.Drawing.Image.FromFile(dgvMA.Rows[r].Cells["Image"].Value.ToString());
                }
                else this.pictureBox1.Image = null;
            }
            catch
            { }
        }
    }
}
