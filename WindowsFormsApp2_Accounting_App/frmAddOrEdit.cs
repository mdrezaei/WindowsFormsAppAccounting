using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using WindowsFormsApp2_Accounting_DataLayer;

namespace WindowsFormsApp2_Accounting_App
{
    public partial class frmAddOrEdit : Form
    {
        public int CustomerID = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
        }

        private void btnSubmitImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenForChoose = new OpenFileDialog();//برای باز کردن اون پنجره انتخاب فایل هستش

            if (OpenForChoose.ShowDialog() == DialogResult.OK)
            {
                pcBoxCustomer.ImageLocation = OpenForChoose.FileName;//ایمیج لوکیشن که ادرس عکس رو در خودش ذخیره میکنه
                // فایل نیم هم که ادرس عکس هستش گرچه میگه اسم عکس ولی اسم عکس رو با ادرسش ذخیره میکنه
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                using (UnitOfWork Context = new UnitOfWork())
                {
                    string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(pcBoxCustomer.ImageLocation);
                    //چون اسم عکس رو ذخیره میکنیم اگه اسم تکراری باشه عکس رو ذخیره نمیکنه و ریپلیس میکنتش
                    //پس خودمون اسم عکس رو میسازیم ب استفاده از جی یو ای دی. که میاد و یه عبارت 32 کارکتری منحصر به فرد میسازی
                    //بعد دات نیو جی یو ای دی بعد دات تو استرینگ. خب بعد پسوند فایل چیه؟
                    //پس به علاوه میذاریم توی استرینگ که بچسبند به هم ومیایم از پَف استفاده میکنیم
                    //پف مال کتاب خانه سیستم دات ای او هستش که باید یوزینگ شه
                    //پف دات گت اکستنشن چی کار میکند؟
                    //میاد و مسیر یا همان پف فایل ما را درون پرانتزش میگیرد پس باید بهش مسیر بدیم و بعد پسوند را پس میدهد
                    //پیسیباکس پیکچر که مشخصه چیه دات ایمیج لکیشن هم مسیر عکسی هست که بهش داده شده است

                    string SavePath = Application.StartupPath.ToString() + "/Images/";
                    //اپلیکیشن که خب خود اپلیکیشن هست و استارتاپ پف هم مسیر اجرای اپلیکیشن هست یعنی مکان اپ 
                    //بعد پوشه ایمیجز 
                    //این میشه مسیر محلی که میخوایم سیو شه فایل ها

                    if (Directory.Exists(SavePath) == false)
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    //اینجا میگیم که اگر این دایرکتوری یا این مسیر وجود نداشت بیاد و این دایرکتوری رو بسازه برای ما
                    //دایرکتوری برای سیستم ای او هستش
                    //تعریف کلاس دایرکتوری :
                    //Exposes static methods for creating, moving, and enumerating through directories and subdirectories.
                    //This class cannot be inherited.
                    //https://learn.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-7.0
                    //به لینک بالا سر بزن تا با کلاسش و متد هاش اشنا شیم
                    //متد اگزیست از کلاس دایرکتوری :
                    //Determines whether the given path refers to an existing directory on disk.
                    //public static bool Exists (string? path);
                    //این متد برای پف یا همان مسیر استرینگ میگیرد و همون طور که در تعریف شدن این متد میبینیم بولین برمیگرداند
                    //true if path refers to an existing directory;
                    //false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.
                    //متد کریت دایرکتوری از کلاس دایرکتوری :
                    //Creates all directories and subdirectories in the specified path unless they already exist.
                    //public static System.IO.DirectoryInfo CreateDirectory (string path);
                    //همون طور که در تعریف شدنش میبینیم استرینگ میگیرد برای دایرکتوری (مسیری) که باید بسازد و
                    //پس مسیر میگیره دقیقا مثل اگزیست که اونم مسیر میگرفت
                    //دایرکتوری اینفو برمیگرداند
                    //String ==> The directory to create.
                    //Returns   DirectoryInfo == > An object that represents the directory at the specified path.
                    //This object is returned regardless of whether a directory at the specified path already exists.
                    //دایرکتوری (رایانه). پوشه یا فولدری است در سیستم که گروهی از پرونده ها و یا پوشه ها را در خود دارد.
                    //پوشه ها در یک پوشه دان یا دایرکتوری نگه داشته می شوند.
                    //هر پوشه دان خود یکی از پوشه های پوشه دانِ زبرینِ خود به شمار می آید.

                    pcBoxCustomer.Image.Save(SavePath + ImageName);
                    //برای ذخیره عکس در کامپیوتر خود شخص
                    //پیسی باکس کاستومر که مشخصه چیه بعد دات ایمیج هم که خب عکسش هست . بعد دات سیو
                    //دات سیو اسم فایل یا مسیر فایل رو درون پرانتزش میگیره
                    //میتونه مسیر فایل رو بگیره جایی که ذخیره شده و یا
                    //میتونه اسم فایل رو بگیره و یا میتونه فرمت فایل رو بگیره و یا میتونه همه رو بگیره
                    //اینجا مسیری که باید توش ذخیره بشه رو میگیره و اسمی که باید باهاش ذخیرش کنه
                    //از پیکچر باکس خواستیم که ایمیجش رو ذخیره کنه در مسیری که دادیم با نامی که دادیم

                    Customers_info Customer = new Customers_info()
                    {
                        FullName = txtBoxName.Text,
                        Number = txtBoxNumber.Text,
                        Email = txtBoxEmail.Text,
                        Address = txtBoxAddress.Text,
                        CustomerImage = ImageName
                    };
                    if (CustomerID == 0)
                    {
                        Context.Customer_ripositories.InsertCustomer(Customer);
                    }
                    else
                    {
                        Customer.CustomerID = CustomerID;//این جا خب چون متد اپدیت باید بره
                        //و مشخص کنه کدوم انتیتی رو اپدیت کنه کدوم ردیف مارو اپدیت کنه نیاز به کلید اصلی داره دیگه
                        //اگه کلید اصلی نباشه ارور میده
                        Context.Customer_ripositories.UpdateCustomer(Customer);
                    }
                    Context.SaveChanges();
                    Context.Dispose();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (CustomerID != 0)
            {
                this.Text = "ویرایش";
                using (UnitOfWork Context = new UnitOfWork())
                {
                    var Custome = Context.Customer_ripositories.GetCustomerByID(CustomerID);
                    txtBoxName.Text = Custome.FullName;
                    txtBoxNumber.Text = Custome.Number;
                    txtBoxAddress.Text = Custome.Address;
                    txtBoxEmail.Text = Custome.Email;
                    pcBoxCustomer.ImageLocation = Application.StartupPath + "/Images/" + Custome.CustomerImage;
                    //چرا ایمیج لکیشن چون که خوب موقع ادیت شدن عکس باز نیاز به لکیشنش داریم دیگه اینجا درجا بگیریم ازش لکیشن رو
                }
            }
        }
    }
}
