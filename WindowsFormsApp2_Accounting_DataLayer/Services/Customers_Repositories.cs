using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2_Accounting_ViewModels;

namespace WindowsFormsApp2_Accounting_DataLayer
{
    public class Customers_Repositories : ICustomers_Repositories
    {

        //Accounting_DBEntities DBConnectionEntity = new Accounting_DBEntities();
        Accounting_DBEntities DBConnectionEntity;
        public Customers_Repositories(Accounting_DBEntities Context)
        {
            DBConnectionEntity = Context;//این دیپندنسی اینجکشن هستش
            //چرا که اگر سه بار ریپوزیتوری ما فراخانی بشه و سه بار بیاد و این کانکشن کانتکتس مارو نمونه سازی کنه
            //منابع زیادی مصرف میشه و از اونجایی که وابسته هست ریپوزیتوری ما با این کانتکتس
            //نمیشه هم حذفش کرد پس میایم و فقط اون بالا تعریف میکنیم دی بی کانکشن استرینگ رو و یک کانستراکتور برای این کلاس
            //میسازیم که در ورودی کانستراکتورش بیاد و یک کانتکتس بگیره که نمونه سازی شده از قبل واون برابر با 
            //دی بی کانکشن انتیتی ما هست
            //ادامش در اون کنسول اپلیکیشن ما
        }

        public List<Customers_info> GetAllCustomers()
        {
            return DBConnectionEntity.Customers_info.ToList();
        }

        public Customers_info GetCustomerByID(int customerID)
        {
            return DBConnectionEntity.Customers_info.Find(customerID);
            //find entity framework
            //The Find method on DbSet uses the primary key value to attempt to find an entity tracked by the context.
            //If the entity is not found in the context then a query will be sent to the database to find the entity there.
            //Null is returned if the entity is not found in the context or in the database
            //از پرایمری کی استفاده میکنه پس انگار شرط رو داره از قبل
            //و اگه نبود نال برمیگردونه
            //و چون پرایمری کی یکی هست و همیشه هست و تکراری نیست 
            //پس دقیقا خصوصیات سینگل اور دیفالت رو داره ولی فقط برای انتیتی است نه لینک و لامبدا

            //DbSet
            //A DbSet represents the collection of all entities in the context, or that can be
            //queried from the database, of a given type. DbSet objects are created from a
            //DbContext using the DbContext.
            //What is the difference between DbContext and DbSet?
            //Intuitively, a DbContext corresponds to your database (or a collection of tables and
            //views in your database) whereas a DbSet corresponds to a table or view in your database.
        }

        public bool InsertCustomer(Customers_info customers)
        {
            try
            {
                //DBConnectionEntity.Customers_info.Add(customers);//استیت این انتیتی اد هستش
                DBConnectionEntity.Entry(customers).State = EntityState.Added;//استیت این انتیتی اد هستش
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(Customers_info customers)
        {
            try
            {
                DBConnectionEntity.Entry(customers).State = EntityState.Modified;
                //از چپ به راست اولی که خب انتیتیکاتکست ما هست که کانکشن به دیتا بیسمان را فراهم میکند.
                //بعدی انتری هست که مال انتیتی هست و شاریط تعغیرات را در انتیتی برایمان فراهم میکند و در پرانتزش یک کلاس از نوع انتیتی انتری میگیرد
                //EntityEntry Provides access to change tracking information and operations for a given entity.
                //Entry(Object) Gets an EntityEntry for the given entity. The entry provides access to change tracking information and operations for the entity.
                //کاستومرز اینفو کلاسش که در واقع از روی تیبل ما ساخته شده یک انتیتی است که چون میشتونه مقادیر رو بگیره و مقادریش رو تعغیر بده یا حتی حذف کنه از کلاسش یک انتیتی انتری هست

                //https://learn.microsoft.com/en-us/ef/ef6/saving/change-tracking/entity-state#entity-states-and-savechanges

                //بعدی استیت هستش
                //وقتی انتیتی فریم ورک در معماری لایه ای یا حالت دیسکاکتد باشد
                // خود کانتکست که با دیتا بیس ارتباط دارد تعغیرات رو رصد نمیکند
                // ما باید دستی بهش تعغیرات رو نشان دهیم با استفااده از استیت
                //البته از معنی دقیق دیسکانتکت و کانکتد اطلاعی ندارم
                //با این وجود در معماری لایه ای و جایی که کانتکست ها چند تان و یا موقع ساخت شئ جدید از کلاس تتیبلمان 
                //از دیسکانکتد و استیت استفاده میکنیم
                //انتیتی با استیت چه در حالت کانکتد چه دیسکانکتد با استیت حالت انتیتی ها را متوجه میشود
                //حالا جاهایی چه دیسکانکتد چه کانکتد ما دستی از استیت استفاده میکنیم
                //ولی استیت به معنای حالت ان انتیتی هست و ربطی به دستی استفاده
                //کردن ،کانکتد یا دیسکاکتد ندارد و تمام انتیتی ها استیت را دارن


                //حالا اطلاعات استیت
                //Entity Framework takes care of tracking the state of entities while they are
                //connected to a context, but in disconnected or N-Tier scenarios you can let EF
                //know what state your entities should be in.
                //Entity states and SaveChanges
                //An entity can be in one of five states as defined by the EntityState enumeration
                //Added: the entity is being tracked by the context but does not yet exist in the database
                //Unchanged: the entity is being tracked by the context and exists in the database,
                //and its property values have not changed from the values in the database
                //Modified: the entity is being tracked by the context and exists in the database,
                //and some or all of its property values have been modified
                //Deleted: the entity is being tracked by the context and exists in the database,
                //but has been marked for deletion from the database the next time SaveChanges is called
                //Detached: the entity is not being tracked by the context

                //SaveChanges does different things for entities in different states:
                //Unchanged entities are not touched by SaveChanges.
                //Updates are not sent to the database for entities in the Unchanged state.
                //Added entities are inserted into the database and then become Unchanged when SaveChanges returns.
                //Modified entities are updated in the database and then become Unchanged when SaveChanges returns.
                //Deleted entities are deleted from the database and are then detached from the context.
                //

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customers_info customers)
        {
            try
            {
                DBConnectionEntity.Entry(customers).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int customersID)
        {
            try
            {
                Customers_info customers = GetCustomerByID(customersID);
                DeleteCustomer(customers);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Customers_info> SearchCustomers(string searchValues)
        {
            return DBConnectionEntity.Customers_info.Where(c => c.FullName.ToLower().Contains(searchValues.ToLower())
            || c.Email.ToLower().Contains(searchValues.ToLower()) || c.Number.ToLower().Contains(searchValues.ToLower())
            || c.Address.ToLower().Contains(searchValues.ToLower())).ToList();
        }

        public List<string> GetCustomersName(string Search = "")
        {
            //این متد چیزی برنمیگردونه
            if (Search == "")
            {
                return DBConnectionEntity.Customers_info.Select(n => n.FullName).ToList();
            }

            return DBConnectionEntity.Customers_info.Where(n => n.FullName.ToLower().Contains(Search)).Select(n => n.FullName).ToList();
            //Select comes under the Projection Operator, the select operator used to select the properties to
            //display/selection. Select operator is mainly used to retrieve all properties or
            //only a few properties which we need to display. It is used to select one or
            //more items from the list of items or from the collection.
            //https://linqsamples.com/linq-to-objects/projection/Select-indexed-lambda-csharp

        }

        public List<ListCustomersViewModels> SecondGetCustomersName(string Search = "")
        {
            if (Search == "")
            {
                return DBConnectionEntity.Customers_info.Select(n => new ListCustomersViewModels()
                {
                    FullName = n.FullName,
                    CustomerID = n.CustomerID
                }).ToList();
            }

            return DBConnectionEntity.Customers_info.Where(n => n.FullName.ToLower().Contains(Search.ToLower()))
                .Select(n => new ListCustomersViewModels()
                {
                    FullName = n.FullName,
                    CustomerID = n.CustomerID
                }).ToList();
            //این سلکت رو کامل بخون که چجوریه
        }

        public int GetCustomerIDByName(string name)
        {
            //return Convert.ToInt32(DBConnectionEntity.Customers_info.First(n => n.FullName == name));
            return DBConnectionEntity.Customers_info.First(n => n.FullName == name).CustomerID;
            //اینجا ما میخوایم که یک اینت ریترن بشه
            //ولی فیرست دستورش میره و از تیبل کاستومر اون ردیفی رو میاره که 
            //شرط پرانتزش یعنی فول نیم برابر با نیم برپا باشه
            //پس یک ردیف کامل میاره و یک ردیف کامل هم برابر یک کلاس هست
            //کلاسی که انتیتی برای این تیبل ساخته
            //مقادیر اون ردیف رو همش رو میریزه داخل اون کلاس
            //حالا ما فقط یکی از پراپرتی های این جدول رو میخوایم اون هم کاستومر ای دی هست
            //پس کلاس ما دات پراپرتی مورد نظرمان از ان کلاس 
            //مقدار مورد نظرمان را برمیگرداند
            //چرا خط بالا قابل استفاده نیست چون ما اومدیم یک کلاس رو کانورت کردیم به یک اینت
            //انگار که اسگولیم
        }

        public string GetCustomerNameByID(int customerID)
        {
            return DBConnectionEntity.Customers_info.Find(customerID).FullName;
        }

        public void MethodOutOfContextOfInterface()
        {
            Console.WriteLine("It Was A Test");
            //ما میتونیم در کلاسی که از اینتر فیس ارث بری میکنه متد هایی رو بنویسیم که در اینترفیس وجود ندارند
            /*
              Initialization gives a variable an initial value at the point when it is created. 
              Assignment gives a variable a value at some point after the variable is created

              To declare a constant or a variable is to create a data object and give a name, 
              so that you can reference it later in your code. To assign a constant or variable, 
              on the other hand, is to give it a value

              Implementation means “definition and making it work”. 
              “implementation” means it should be defined and put all the code it requires to make it work.

              A function declaration introduces an identifier that designates a function and,
              optionally, specifies the types of the function parameters 
            */
        }
    }
}
