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
    public partial class FormLogin : Form
    {
        int EmployeeID;
        Account acc = new Account();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            acc.Username = txtUsername.Text;
            acc.Password = txtPassword.Text;
            acc.IsAdmin = rbAdmin.Checked;

            if (acc.IsUser(ref EmployeeID))
            {
                if (rbAdmin.Checked)
                {
                    FormManage f1 = new FormManage();
                    this.Hide();
                    f1.ShowDialog();
                }
                if (rbEmployee.Checked)
                {
                    FormFoodChoices f1 = new FormFoodChoices(EmployeeID);
                    this.Hide();
                    f1.ShowDialog();
                }
            }
        }
        //public static bool IsUser(string username, string password, bool quyen, ref int EmployeeID)
        //{
        //    StoreContext db = new StoreContext();
        //    var q = (from p in db.Accounts
        //             where p.Username == username
        //             && p.Password == password && p.IsAdmin == quyen
        //             select p).SingleOrDefault();
        //    if (q != null)
        //    {
        //        EmployeeID = q.Employee_ID;
        //        return true;
        //    }
        //    else return false;
        //}

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
