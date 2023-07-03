using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2_Accounting_DataLayer
{
    public class UnitOfWork:IDisposable
    {
        //باید پابلیک باشد این کلاس
        Accounting_DBEntities DBConnectionEntity = new Accounting_DBEntities();
        private ICustomers_Repositories _customers_repositories;
        //پرایویت هست که کسی بهش دست رسی نداشته باشه و همینطور نمونه سازی کانتکس بالا هم پرایویت هست به همین منظور
        public ICustomers_Repositories Customer_ripositories
        {//یک پراپرتی میسازیم که رید انلی هست چون دلیلی نداره کسی بهش مقدار بده
            get
            {//اگر اینترفیس پرایویت ما قبلا توسط ریپوزیتوری دیگه ای نمونه سازی نشده بود یعنی نال بود بره و یک نمونه ازش بسازه
                if (_customers_repositories == null)
                {//میاد و در نمونه سازیش از پلی مورفیسم استفاده میکنه به این شکل که از کلاس کاستومر ریپوزیتوری یه دونه میسازیم
                    _customers_repositories = new Customers_Repositories(DBConnectionEntity);
                }//بعد هم چه ایف اجرا بشه چه نه ریترنش میکنیم
                return _customers_repositories;
            }
            //قبلا میومدیم در پرگرام کانستراکتور کلاس کاستومر ریپوزیتوری رو پرمیکردیم که بعد خب دسترسی پیدا میکردیم به دیتا لایر
            //ولی اینجا یونیت اف ورک کانستراکتور رو پرمیکنه و پرگرام توسط یونیت اف ورک و غیر مستقیم دسترسی داره
        }

        private GenericRepository<Accounting> _accountingRepository;
        
        public GenericRepository<Accounting> AccountingRepository
        {
            get
            {
                if (_accountingRepository==null)
                {
                    _accountingRepository = new GenericRepository<Accounting>(DBConnectionEntity);
                }
                return _accountingRepository;
            }
        }

        private GenericRepository<Login> _loginRepository;

        public GenericRepository<Login> LoginRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    _loginRepository = new GenericRepository<Login>(DBConnectionEntity);
                }
                return _loginRepository;
            }
        }

        public void SaveChanges()
        {
            DBConnectionEntity.SaveChanges();
        }

        public void Dispose()//متد ایمپلیمنت شده از ای دیسپوزیبل هستش که
        {//باعث میشه چیزی رو که بهش میدیم رو از روی حافظه خارج کنه
            DBConnectionEntity.Dispose();
        }
    }
}
