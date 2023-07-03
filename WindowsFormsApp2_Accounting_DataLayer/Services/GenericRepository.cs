using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

//نا مرتبط به مبحث این کلاس
//برای زمانی که چنتا تیبل دیگه بعد از اد کردن انتیتی ساختیم در دیتا بیسمان و حالا ان تیبل ها نشون داده نشده اند
//میایم و روی مادل دات ای دی ام ایکس که در واقع سربرگ انتیتی ما هست و شکل یک دیتا بیس به همراه شکل یک کلاس بر روی ان را دارد
//دوبار کلیک میکنیم و وقتی که باز شد میبینیم که یک صفحه خالی وجود دارد که شاید هم یکی یا چند تا
//از جدول های تیبلمان هم در ان وجود داشته باشد
//سپس کلیک راست میکنیم و گزینه اپدیت مدل فرام دیتا بیس را میزنیم بعد
//صفحه ای باز میشود که اجزای مورد نیازمان را از دیتا بیسمان را اضافه کینم
//اجزایی را که میخواهیم را تیک میزنیم و اضافه میشوند
//کلیک راست و گزینه جنریت دیتا بیس فرام مدل هم برعکس همین موضوع است تغریبا
//اگر تیبل ها رابطه ای باشند یعنی رلیشنشیپ داشته باشند بینشان چند خط وصل میشود
//و زیر هر تیبل مینویسد که چه جدولی به چه جدولی وصل است
//و اگر روی خط کلیک کنیم اطلاعات دقیق را میدهد به ما که چه فیلدی از تیبلمان به چه فیلدی از تیبل دیگر متصل شده است
//و در بین این جدول ها و دو طرف خط ها اعداد و ستاره هایی وجود دارند که
//بیانگر این هستند که هر فیلد از ان جدول یا اصلا هر جدول میتواند چند جدول از جدولی که بهش وصل است داشته باشد
//مثلا یک و ستاره یعنی جدولی که یک دارد میتواند چندین جدول از جدول ستاره ها داشته باشد یعنی یک به چند
//مثلا جدولی که یک دارد اسم کاستومرش محمد است . محمد میتواند چندین تراکنش مختلف داشته باشد
//ولی برعکسش ستاره به یک یعنی هر کدام از جدول های ستاره دار فقط متعلق به یک جدول یک دار هستند
//A primary key generally focuses on the uniqueness of the table.
//It assures the value in the specific column is unique. A foreign key is generally used to build a relationship between
//the two tables. Table allows only one primary key.
//خب حالا باید بفهمیم کدام دارای فارن کی هست و کدام پرایمری کی را دارد<< در این رابطه ها>> نه در جدول ها چون
//پرایمری کی جدول ها کمی متفاوت هست ، ولی پرایمری کی جدول ها باعث میشود جدول ، مشخصات
//منحصر به فرد داشته باشد برای همین هم در ایجاد ارتباط و رلیشن شیپ بین جدول ها مهم و الزامی است
//و سپس در مادل دات تی تی انتیتی ما میاد و کلاسی بر اساس جدول های ما با پراپرتی هایی بر اساس فیلد های جدول ما میسازد
//با نام های همان جداولمان
//اگر بر روی خط فقط موس را نگه داریم میگوید که سورس این رابطه کدام جدول و
//تارگت این رابطه کدام جدول است که باز هم میشه از ان فارن کی و پرایمری کی رابطه را تشخیص داد

//Creating a repository class for each entity type could result in a lot of redundant code,
//and it could result in partial updates.For example, suppose you have to update two different
//entity types as part of the same transaction.If each uses a separate database context instance,
//one might succeed and the other might fail.One way to minimize redundant code is to use a generic repository,
//and one way to ensure that all repositories use the same database context(and thus coordinate all updates)
//is to use a unit of work class.
//In this section of the tutorial, you'll create a GenericRepository class
//and a UnitOfWork class, and use them in the Course controller to access both the Department
//and the Course entity sets. As explained earlier, to keep this part of the tutorial simple,
//you aren't creating interfaces for these classes. But if you were going to use them to facilitate TDD,
//you'd typically implement them with interfaces the same way you did the Student repository.
//https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application

namespace WindowsFormsApp2_Accounting_DataLayer
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private Accounting_DBEntities _dBContext;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(Accounting_DBEntities DBContext)
        {
            _dBContext = DBContext;
            _dbSet = _dBContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> Query = _dbSet;
            if (where != null)
            {
                Query = Query.Where(where);
            }
            return Query.ToList();
        }
        //این گت بالا چجوری استفاده میشه؟
        //Accounting_DBEntities DB = new Accounting_DBEntities();      
        //GenericRepository<Customers_info> Customers = new GenericRepository<Customers_info>(DB);
        //var result1 = Customers.Get(c => c.FullName.ToLower().Contains("M".ToLower()));
        //نمیتونیم کلمه کلیدی کلیدی لامبدا مثل ور رو وارد این پرانتز ورودی متد کنیم
        //نمونه های دیگه :
        //var result2 = Customers.Get();
        //خب با توجه به تعریف این متد و نحوه استفادش
        //نوشتیم که ای اینامریبل از نوع انتیتی برمیگردونه خب پس کالکشن هایی مثل
        //لیست رو که هاوی کلاس هایی هستند که از تیبل هامون نمونه سازی شدن یا
        //حالا کلن انتیتی هامون برمیگردونن و بعد اسمش هست و بعد هم ورودی این متد هست.
        //ورودیش میگه من یک جنریک اکسپرشن میگیرم یعنی چی خب ؟
        //یعنی یک نوع کوئری لامبدا از انواع مختلف کوئری های لامبدا میگیره .
        //حالا این لامبدایی که میگیره از جنس دلیگیت هستش یعنی یک متد یا همان فانکشن رو میگیره
        //و اجراش میکنه و در عوض یک چیزی را برمیگرداند. بعدیش جنریک فانک هستش که یک چیزی
        //رو میگیره و یک چیزی رو پس میده و در اینجا یک تی ان تیتی میگیرد که
        //خب تی ان تیتی رو موقع تعریف جنریک ریپوزیتوری گرفته. و شرط برمیگردونه یا
        //همان نتیجه شرط را برمیگردونه . حالا ما اسم این جنریک اکسپرشنی رو که تعریف کردیم
        //رو میزاریم وِر و مساوی با نال قرارش میدیم. پایین تر ای کوئریایبل داریم از نوع تی انتیتی .
        //ایکوئری ایبل  میاد و شرایط ذخیره کوئری دیتا بیس رو که قراره روی ساختاری از دیتا بیس ، در
        //اینجا تی انتیتی، اجرا بشه رو ذخیره میکند و ما در اینجا موقع تعریف مساوی با
        //دی بی ستمان که اسمش هم دیبیست است قرارش دادیم . با توجه به شکل کوئری این کوئری لیزی لود هست
        //یعنی تا زمانی که اسمش صدا زده نشود اجرا نمیشود و اجازه میدهد عملیات ها
        //روی دیتا بیس تا جایی که قبل از فراخوانی اش است انجام شود چه بر روی کوئری اش چه بر روی دیتا بیس .
        //اینجا که برابر با کل دی بی ست است به دلیل این است که شاید کسی نمیخواست شرطی را به
        //متد گت بدهد و پرانتزش را که باید اکسپرشن شرطی را بگیرد را خالی بزارد. اگر شرط اکسپرشن خالی نبود
        //میاییم و روی کوئریمان که تا الان برابر با تنها دی بی ست بوده را به ان شرت اضافه میکنیم
        //از نوع لامبدا با کلمه کلیدی ور که در پرانتزش هاوی شرط ورودی متد است. و بعد ریترن کوئری دات تو لیست .
        //در هنگام استفادش خب لامبدا رو مینویسیم و لامبدایی باید باشد که نتیجه شرط برگرداند پس
        //در لامبدا ها میشود کلمه کلیدی ور خب پس انگار که داریم
        //در پرانتز ور کد میزنیم (چون که خروجی این پرانتز برابر با خروجی شرط یا همان ور است )
        //برای تی انتیتی ورودیش هم خب کاستومرز خودش نمونه ساخته شده از جنریک ریپوزیتوری است
        //که تیانتیتی میگیرد و در اینجا تی انتیتی اس برابر با کاستومرز اینفو است ، هست.
        //پس با توجه به ساختار لامبدا کاستومرز خودش تی انتی تی است و گت همان کلمه کلیدی ور هست
        //پس سی => سی دات پراپرتی های کلاس کاستومرز اینفو خودش تی انتیتی ورودی است 
        //جوری که مایکروسافت متد گت رو نوشته : 
        //public virtual IEnumerable<TEntity> Get(
        //       Expression<Func<TEntity, bool>> filter = null,
        //       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //       string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        public virtual TEntity GetByID(object ID)
        {
            return _dbSet.Find(ID);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            //_dBContext.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(TEntity entity)
        {
            if (_dBContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            ////بالایی کار میکند

            //_dBContext.Entry(entity).State = EntityState.Detached;
            //_dbSet.Attach(entity);
            ////این بالایی هم کار میکند

            //_dBContext.Entry(entity).State = EntityState.Unchanged;
            //این بالایی هم جوابه 
            //البته این بالایی "انچینجد" دیتابیس رو اتچ نمیکرد و در لاگین که
            //رمز عوض میشد متوجه نمیشد که کانتکست چیست چون اتچ نشده بود
            //باقی ویرایش هارو چک نکرده بودم ولی از این به بعد اتچ کنیم جای ادا بازی های دیگه

            //البته که بدون این ها هم جواب میده
            //ولی خود مایکروسافت و اموزش از این حرکات بالا استفاده کردن که خطا نده

            _dBContext.Entry(entity).State = EntityState.Modified;

        }

        public virtual void Delete(TEntity entity)
        {
            if (_dBContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(object ID)
        {
            TEntity entity = GetByID(ID);
            Delete(entity);
            //شاید بگیم که خب پس چجوری خطا رو هندل کنیم اینجا چرای ترای کش نداریم یا چرا که بولین برنمیگردونه
            //خب طرف از جدول انتخاب میکنه 
            // و چون از جدول انتخاب میکنه اتفاقی نمیفته چون همیشه موجودی جدولمون رو مبینه
            // پس امکان نداره چیزی انتخاب کنه که موجود نیست
        }
    }
}
