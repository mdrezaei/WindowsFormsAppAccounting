using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2_Accounting_DataLayer;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {          
            //Accounting_DBEntities DBContext = new Accounting_DBEntities();//یک نمونه از کانتکتس میسازیم در اینجا
            //ICustomers_Repositories Customers = new Customers_Repositories(DBContext);//کانستراکتور رو پر میکنیم
            ////به این روش میگن دیپندنسی اینجکشن
            ////ولی خب ما به این شکل به دیتا لیر دسترسی داریم که قرار بود این اتفاق نیفته
            ////پس میریم در روش الگوی یونیت آو ورک که باعث میشه به صورت مستقیم به کانتکتس دسترسی نداشته باشیم
            ////حالا همه کد هارو کامنت میکنم که بریم یونیت او ورک در پوشه کانتکس یونیت او ورک

            //Customers_info C1 = new Customers_info()
            //{
            //    FullName = "Ali",
            //    Number = "09367436248",
            //    CustomerImage = "123",
            //};
            //Customers.InsertCustomer(C1);

            ////Customers.SaveChanges();

            //var No2 = Customers.GetCustomerByID(2);
            //No2.Address = "Address";
            //Customers.UpdateCustomer(No2);

            ////Customers.DeleteCustomer(17);

            //Customers.SaveChanges();

            //var ListCustomers = Customers.GetAllCustomers();
            //foreach ( var Print in ListCustomers)
            //{
            //    Console.WriteLine(Print.CustomerID+" "+Print.FullName+" "+Print.Number+" "+Print.Address);
            //}

            //var No1= Customers.GetCustomerByID(2);
            //Console.WriteLine(No1.FullName);

            //-------------------------------------------------------------------------------

            UnitOfWork SUnitOfWork = new UnitOfWork();
            var No5 = SUnitOfWork.Customer_ripositories.GetAllCustomers();
            //خب یه نمونه میسازیم از کلاس یونیت اف ورکمون
            //بعد میایم با نمونش به متد ها پراپرتی هاش دسترسی پبدا میکنیم
            //اینجا ما به کاستومر ریپوزیتوریش
            //دسترسی پیدا میکنیم که اون میاد
            //و اینترفیس پرایویت رو نمونه سازی میکنه پلیمورفیسم
            //از کلاس کاستومر ریپوزیتوری که کوئری های انتیتی برای بانک اونجاست
            //اگه هم از قبل نمونه سازی شده که هیچی خب فقط ریترنش میکنه
            //بعد حالا ما به کلاس کاستومر ریپوزیتوری دسترسی داریم ولی درواقع اون پرایویت هستش
            //و ما با پراپرتی کاستومر ریپوزیتوری فقط میتونیم بهش دسترسی داشته باشیم
            //حالا ما از این متد های درون کلاس کاستومر ریپوزیتاوری استفاده میکنیم
            SUnitOfWork.Dispose();
            //متد دیسپوز رو فراخوانی میکنیم تا کارش رو انجام بده
            
            Console.ReadKey();
        }
    }
}
