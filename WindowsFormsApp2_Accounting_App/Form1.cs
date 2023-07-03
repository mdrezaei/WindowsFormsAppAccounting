using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2_Accounting_ViewModels;
using WindowsFormsApp2_Accounting_Logic;

namespace WindowsFormsApp2_Accounting_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dddd yyyy/MM/dd");
            lblTime.Text = DateTime.Now.ToString("t");

            BalanceReportBinder();

            //this.Hide();
            //Login login = new Login();
            //if (login.ShowDialog()==DialogResult.OK)
            //{
            //    this.Show();
            //}
            //else
            //{
            //    //this.Close();//این فقط این فرم رو میبنده . اگه فرم دیگه ای باز باشه باز میمونه
            //    Application.Exit();//این همه فرم هارو میبنده
            //    //چون فرم لاگین بازه اگه دیس دات کلوز بزنیم امکان داره اون لاگین باز بمونه
            //}
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            frmCustomers frmCustomers = new frmCustomers();
            frmCustomers.ShowDialog();
        }

        private void Accounting_Click(object sender, EventArgs e)
        {
            frmAccounting AccountingForm = new frmAccounting();
            AccountingForm.ShowDialog();
            if (AccountingForm.DialogResult == DialogResult.Cancel || AccountingForm.DialogResult == DialogResult.OK)
            {
                BalanceReportBinder();
            }
        }

        private void btnPaymentReport_Click(object sender, EventArgs e)
        {
            frmReport PaymentReportForm = new frmReport();
            PaymentReportForm.ReportType = 2;
            PaymentReportForm.ShowDialog();
            if (PaymentReportForm.DialogResult==DialogResult.Cancel|| PaymentReportForm.DialogResult == DialogResult.OK)
            {
                BalanceReportBinder();
            }
        }

        private void btnIncomeReport_Click(object sender, EventArgs e)
        {
            frmReport IncomeReportForm = new frmReport();
            IncomeReportForm.ReportType = 1;
            IncomeReportForm.ShowDialog();
            if (IncomeReportForm.DialogResult == DialogResult.Cancel || IncomeReportForm.DialogResult == DialogResult.OK)
            {
                BalanceReportBinder();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("t");
        }

        private void dateTimer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dddd yyyy/MM/dd");
        }

        void BalanceReportBinder()
        {
            ReportViewModel report = BalanceReport.Report();
            lblRecive.Text = report.Recive.ToString("#,0");
            lblPayment.Text = report.Payment.ToString("#,0");
            lblBalance.Text = report.Balance.ToString("#,0");
        }

        //private void btmLogin_Click(object sender, EventArgs e)
        //{
        //    Login login = new Login();
        //    login.isEdit = true;
        //    login.ShowDialog();
        //}
    }
}
