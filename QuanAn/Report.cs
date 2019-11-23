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
    public partial class Report : Form
    {
        private int ID_Bill;
        public Report(int ID_Bill)
        {
            InitializeComponent();
            this.ID_Bill = ID_Bill;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            this.ReportTableAdapter.Fill(this.CafeteriaBillReport.Report,this.ID_Bill);
            this.reportViewer1.RefreshReport();
        }
    }
}
