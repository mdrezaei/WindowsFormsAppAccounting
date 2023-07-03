using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2_Accounting_DataLayer;

namespace WindowsFormsApp2_Accounting_App
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        void BindGrid()
        {
            using (UnitOfWork Context = new UnitOfWork())
            {
                dgvCustomersList.AutoGenerateColumns = false;
                dgvCustomersList.Columns[0].Visible = false;//اینجا ما اولین سطون رو از دیتا بیس خودمون اوردیم و گفتیم نامرعی باشه
                                                            //اگه سطون کاستومر ای دی رو نمیگفتیم  کلا نشونش نمیداد
                                                            //البته که گت ال کاستومر متدش همه رکورد ها رو میاره
                                                            //ولی اون سطون رو چون ما اینجا مشخص نکردیم نشون نمیده
                                                            //البته که ما اینجا مشخصش کردیم چون
                                                            //نیاز داریم به مقادیرش ولی نمیخوایم نشون داده بشه
                dgvCustomersList.DataSource = Context.Customer_ripositories.GetAllCustomers();
                Context.Dispose();
            }
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnRefreshCustomer_Click(object sender, EventArgs e)
        {
            txtBoxSearchCustomers.Text = null;
            BindGrid();
        }

        private void txtBoxSearchCustomers_TextChanged(object sender, EventArgs e)
        {
            using (UnitOfWork Context = new UnitOfWork())
            {
                dgvCustomersList.AutoGenerateColumns = false;
                dgvCustomersList.Columns[0].Visible = false;
                //dgvCustomersList.Columns[5].Visible = false;
                dgvCustomersList.DataSource = Context.Customer_ripositories.SearchCustomers(txtBoxSearchCustomers.Text);
                Context.Dispose();
            }
        }

        private void btnDeleteCustomers_Click(object sender, EventArgs e)
        {
            if (dgvCustomersList.CurrentRow != null)
            {
                string Name = dgvCustomersList.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show($" حذف شود؟ {Name} آیا", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int ID = Convert.ToInt32(dgvCustomersList.CurrentRow.Cells[0].Value);
                    using (UnitOfWork Context = new UnitOfWork())
                    {
                        Context.Customer_ripositories.DeleteCustomer(ID);
                        Context.SaveChanges();
                        Context.Dispose();
                        BindGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفا یک ردیف را انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frmAdd = new frmAddOrEdit();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnEditCustomers_Click(object sender, EventArgs e)
        {
            if (dgvCustomersList.CurrentRow != null)
            {
                string Name = dgvCustomersList.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show($" ویرایش شود؟ {Name} آیا", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmAddOrEdit frmEdit = new frmAddOrEdit();
                    int CustomerID = (int)dgvCustomersList.CurrentRow.Cells[0].Value;
                    frmEdit.CustomerID = CustomerID;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        BindGrid();
                    }
                }

            }
            else
            {
                MessageBox.Show("لطفا یک ردیف را انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
