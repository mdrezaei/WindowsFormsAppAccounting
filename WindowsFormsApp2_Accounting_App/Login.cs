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
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace WindowsFormsApp2_Accounting_App
{
    public partial class Login : Form
    {
        public bool isEdit = false;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                this.Text = "تنظیمات";
                btnEnter.Text = "ذخیره";
                //using (UnitOfWork Context = new UnitOfWork())
                //{
                //    var login = Context.LoginRepository.Get().First();
                //    txtUsername.Text = login.User_name;
                //    txtPassword.Text = login.Password;
                //}

            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using (UnitOfWork Context = new UnitOfWork())
                {
                    if (isEdit)
                    {
                        var login = Context.LoginRepository.Get().First();
                        login.User_name = txtUsername.Text;
                        login.Password = txtPassword.Text;
                        Context.LoginRepository.Update(login);
                        Context.SaveChanges();
                        Application.Restart();
                    }
                    else
                    {
                        if (Context.LoginRepository.Get(n => n.User_name == txtUsername.Text && n.Password == txtPassword.Text).Any())
                        //انی رو قبلا گفته بودیم . بولین برمیگردونه و چک میکنه که کالکشن ما عنصری رو داره یا نه
                        //خب قلش باید مشخصات رو هم بهش بدیم
                        //https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=net-8.0
                        //فکر کنم حتی بین کوئری های لینک هم بشه ازش استفاده کرد . بینشون ها بین کوئری ها
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("کاربر یافت نشد", "اخطار", MessageBoxButtons.OK);
                            //DialogResult = DialogResult.Cancel;
                            //this.Close();//دیس دات کلوز و ضربدر قرمز بالای فرم ها ، دیالوگ ریزالت رو ، یا همان
                                         //مدل دیالوگ فرم ما را ، برابر کنسل قرار میدهد
                                         //پس اگر میخواهیم فرم را ببندیم ولی نمیخوایم که
                                         //مدل دیالوگ ما یا همان دیالوگ ریزالت ما کنسل بشود باید دیالوگ ریزالت رو بعد از کلوز مقدار بدیم

                            //DialogResult = DialogResult.OK;//اینو امتحان کن همزمان با فعال کردن کد های بالا
                        }
                    }

                    Context.Dispose();
                }
            }
        }


    }
}
