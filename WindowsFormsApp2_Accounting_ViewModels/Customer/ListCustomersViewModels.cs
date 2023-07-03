using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2_Accounting_ViewModels
{
    public class ListCustomersViewModels //دقت کن پابلیک باشه این کلاس
    {
        //اینجا هرچیزی رو که میخوایم رو بگیریم و نشون بدیم رو مثل انتیتی که اومده کلاس با
        //پراپرتی ساخته برامون خودمون دستی میسازیم
        //بعد میایم این ویو مدل رو رفرنس میدیم توی دیتا لیر و یوزینگ میکنیم

        public int CustomerID { get; set; }
        public string FullName { get; set; }

    }
}
