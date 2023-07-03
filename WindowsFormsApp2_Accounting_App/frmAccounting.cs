using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using WindowsFormsApp2_Accounting_DataLayer;

namespace WindowsFormsApp2_Accounting_App
{
    public partial class frmAccounting : Form
    {
        public int EditOrAdd = 0;
        public frmAccounting()
        {
            InitializeComponent();
        }

        private void frmAccounting_Load(object sender, EventArgs e)
        {
            using (UnitOfWork Context = new UnitOfWork())
            {
                dgvAccountingCustomers.AutoGenerateColumns = false;
                //dgvAccountingCustomers.DataSource = Context.Customer_ripositories.GetAllCustomers();
                //اینجا ما فقط اسم اشخاص رو میخوایم نه شمارشون رو نه عکسشون رو نه ادرسشون رو و نه حتی
                //مشخصات تراکنش های قبلشون رو ما فقط و فقط فعلا در اینجا نیاز داریم که اسمشون رو داشته باشیم نه بیشتر پس
                //این کار بهینه نیست ، پس به جای استفاده از متد گت ال کاستومر میایم از یک متد دیگر استفاده میکنیم
                //dgvAccountingCustomers.DataSource = Context.Customer_ripositories.GetCustomersName(txtAccountingSearch.Text);
                //اینجا چون گفتیم که این متد لیستی از جنس استرینگ برگردونه میاد یه لیست از جنس استرینگ میده دست ما
                //ما یک لیست از جنس استرینگ رو که مدلش ساخته نشده رو نمیتونیم استفاده کنیم
                //درحالت گت ال کاستومرز یا گت کاستومرز بای ای دی یک کلاس به ما میدهد که مدلش ساخته شده 
                //برای همین الان میریم سراغ ویو مدل
                //ویو مدل جاییه که میخوایم کلاسی یا متدی یک چیزی رو نمایش بده
                //در ویو مدل یک کلاس اد کنیم و یادمان باشد که ته اسمش ویومادل هم بنویسیم که قاطی نشن
                //و بعد هم فراموش نکنیم که اون پروژه را در اینجا هم یوزینگ کنیم
                dgvAccountingCustomers.DataSource = Context.Customer_ripositories.SecondGetCustomersName(txtAccountingSearch.Text);
                //میتونه پرانتزش خالی باشه چون بهش مقدار اولیه دادیم
                //حتما باید اد بشه به عنوان رفرنس هاش وگرنه کار نمیکنه اگه رفرنس ویو مدل اد نشه    
                Context.Dispose();
            }//سازنده دیتا گرید ویو اشخاص فرم تراکنش

            if (EditOrAdd != 0)
            {
                using (UnitOfWork Context = new UnitOfWork())
                {
                    var Edit = Context.AccountingRepository.GetByID(EditOrAdd);
                    txtNOAmount.Value = Convert.ToInt32(Edit.Amount);
                    dtpAccountingTransactoinTime.Value = Edit.DateTime;
                    txtDescription.Text = Edit.Description.ToString();
                    txtAccountingName.Text = Context.Customer_ripositories.GetCustomerNameByID(Edit.CustomerID);
                    if (Edit.TypeID == 1)
                    {
                        rbIncome.Checked = true;
                    }
                    else
                    {
                        rbPayment.Checked = true;
                    }
                    Context.Dispose();
                }
                this.Text = "ویرایش";
            }//برای ساختن فرم ادیت
        }

        private void txtAccountingSearch_TextChanged(object sender, EventArgs e)//برای سرچ کردن در لیست اشخاص  
                                                                                //هربار که متن تعغیر کنه این
                                                                                //تابع از اول اجرا میشه روی
                                                                                //تابع قبلی که خودش باشه
        {
            using (UnitOfWork Context = new UnitOfWork())
            {
                dgvAccountingCustomers.AutoGenerateColumns = false;
                dgvAccountingCustomers.DataSource = Context.Customer_ripositories.SecondGetCustomersName(txtAccountingSearch.Text);
                //نمیتونه پرانتزش خالی باشه چون همش باید مقدار دهی بشه و
                //مقدار اولیه ای که ما دادیم درست نیست براش
                Context.Dispose();
            }
        }

        private void dgvAccountingCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAccountingName.Text = dgvAccountingCustomers.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (UnitOfWork Context = new UnitOfWork())
            {
                if (BaseValidator.IsFormValid(this.components))
                {
                    if (rbIncome.Checked || rbPayment.Checked)//چکد بولین برمیگردونه
                                                              // و چکد یعنی انتخاب شده بود یا نه پس
                                                              // یعنی انتخاب شدن را بررسی میکند و ترو فالس برمیگرداند
                    {
                        Accounting accounting = new Accounting()
                        {
                            Amount = Convert.ToDouble(txtNOAmount.Value),
                            Description = txtDescription.Text,
                            DateTime = dtpAccountingTransactoinTime.Value,//ولیو داره چون درون تیبل ما که
                            //در دیتا بیس هست این فیلد مقدار دیت تایم میگیره نه استرینگ پس
                            //نیازی به تکست یا کانورت به هر گونه دیتاتایپ دیگر نیست
                            //دیت را با تاریخ سیستم ثبت میکند که اینجا هجری شمسی هست ولی بعد 
                            //در دیتا بیس که فرمت میلادی یا همان گئورگین هست . میلادی سیو میکند و بعد
                            //موقع نشان دادن مانند تاریخ سیستم که اینجا هجری شمسی است نشان میدهد و نیازی به 
                            //کانورت کردنشان با اکسپرشن متد نیست ولی خوبه که یاد بگیریم ولی اینجا خود دستگاه
                            //بر اساس چیزی که باید ثبت یا نشان دهد اتومات کانورت میکند
                            SubmitDateTime = DateTime.Now,
                            TypeID = (rbIncome.Checked) ? 1 : 2, // شرط یک خطی یا کاندیشن ایف
                                                                 //درون پرانتز شرطی هست که اگر ترو بود یک را برگرداند و اگر فالس بود دو را برگرداند
                                                                 //علامت سوال همان ایف هست و بعد ان بلاک ایف و دو نقطه هم همان الس است و بعد ان بلاک الس
                            CustomerID = Context.Customer_ripositories.GetCustomerIDByName(txtAccountingName.Text)
                        };
                        if (EditOrAdd==0)
                        {
                            Context.AccountingRepository.Insert(accounting);
                        }
                        else
                        {
                            accounting.AccountingID = EditOrAdd;
                            Context.AccountingRepository.Update(accounting);
                        }
                        Context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("نوع تراکنش را لطفا مشخص کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Context.Dispose();
            }
            DialogResult = DialogResult.OK;
        }
    }
}
