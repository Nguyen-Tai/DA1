using QuanAn.BL;
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
        public ChoseCustomer(int BillID)
        {
            InitializeComponent();
            this.BillID = BillID;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
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

        }
    }
}
