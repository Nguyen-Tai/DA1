using QuanAn.BL;
using QuanAn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanAn
{
    public partial class ChoseCustomer : Form
    {
        private int BillID;
        bool Them;
        string imagepath;
        public ChoseCustomer(int BillID)
        {
            InitializeComponent();
            this.BillID = BillID;
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
        
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (BLBill.TotalByBill(BillID) > BLBill.GetWallet(Convert.ToInt32(txtMaKH.Text)))
            {
                MessageBox.Show("Ví không đủ tiền");
            }
            else
            {
                BLBill.AddCustomerToBill(Convert.ToInt32(txtMaKH.Text), BillID);
                BLBill.ThanhToan(BLBill.TotalByBill(BillID), Convert.ToInt32(txtMaKH.Text));
                MessageBox.Show("Thanh toán thành công");
                Report rp = new Report(BillID);
                rp.ShowDialog();
            }
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

        private void ChoseCustomer_Load(object sender, EventArgs e)
        {
            dgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKH.AllowUserToAddRows = false;
            dgvKH.ReadOnly = true;
            LoadData();           
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
                if (dgvKH.Rows[r].Cells["Image"].Value != "")
                {
                    this.picCustomer.Image = System.Drawing.Image.FromFile(dgvKH.Rows[r].Cells["Image"].Value.ToString());
                }
                else this.picCustomer.Image = null;
            }
            catch
            { }
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
            txtHoTen.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            resettext();
            groupBox1.Enabled = false;
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            btnThem.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
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
                // Thông báo         
                MessageBox.Show("Đã thêm xong!");
            }
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (rdbTen.Checked) //tìm theo mã SV
            {
                using (StoreContext db = new StoreContext())
                {

                    var result = from c in db.Customers
                                 where c.Name.Contains(txtSearch.Text)
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
            else  //tìm theo Họ Tên SV
            {
                using (StoreContext db = new StoreContext())
                {
                    var result = from c in db.Customers
                                 where c.Phone.Contains(txtSearch.Text)
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
        }
    }
}
