using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using WindowsFormsApp2_Accounting_DataLayer;
using WindowsFormsApp2_Accounting_Utilities;
using WindowsFormsApp2_Accounting_ViewModels;

namespace WindowsFormsApp2_Accounting_App
{
    public partial class frmReport : Form
    {
        public int ReportType = 0;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (ReportType == 1)
            {
                this.Text = "گزارش دریافت ها";
            }
            else
            {
                this.Text = "گزارش پرداخت ها";
            }

            using (UnitOfWork Context = new UnitOfWork())
            {
                List<ListCustomersViewModels> cbCustomerDataSource = new List<ListCustomersViewModels>();
                cbCustomerDataSource.Add(new ListCustomersViewModels()
                {
                    CustomerID = -1,//عددی که در دیتا بیس وجود ندارد و بی معناست
                    FullName = "همه"
                });
                cbCustomerDataSource.AddRange(Context.Customer_ripositories.SecondGetCustomersName());
                //اد یک ایتم از جنس لیستمون رو اضافه میکنه
                //ادرینج یک کالکشن از نوع لیست ما اضافه میکنه
                //نوع لیست همون نوعی هست که ما در علامت بزرگتر کوچیکتر <> مینویسیم
                //مثلا اینجا نوع لیست ما<ListCustomersViewModels> 
                cbCustomer.DataSource = cbCustomerDataSource;
                //این کار بالا برای این بود که ما ایتمی رو اضافه کنیم به لیستمون که در دیتا بیس نیست
                //ولی خط پایینی فقط همون چیزای توی دیتا بیس رو برمیگردونه
                //cbCustomer.DataSource = Context.Customer_ripositories.SecondGetCustomersName();
                //دلیل اینم که ما از ویو مدل استفاده کردیم این بود که نمیخواستیم اطلاعاتی رو که
                //بهشون احتیاجی نداریم رو دریافت کنیم و فشار الکی روی سیستم بیاریم
                cbCustomer.DisplayMember = "FullName";//اعضای کمبو باکسی رو که نشون میده
                cbCustomer.ValueMember = "CustomerID";//ولیو و ارزش اصلی هر کدوم از اون اعضای کمبو باکس که ارائه میده و
                                                      //ریترن میکنه برای پروسس 
                Context.Dispose();
            }//برای کمبو باکس

            Filter();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Filter();
        }

        void Filter()
        {
            using (UnitOfWork Context = new UnitOfWork())
            {
                List<Accounting> FilterResult = new List<Accounting>();

                if ((int)cbCustomer.SelectedValue > 0)
                {
                    int ID = (int)cbCustomer.SelectedValue;
                    FilterResult.AddRange(Context.AccountingRepository.Get(n => n.TypeID == ReportType && n.CustomerID == ID));
                }
                else
                {
                    FilterResult.AddRange(Context.AccountingRepository.Get(n => n.TypeID == ReportType));
                }
                //var FilterResult = Context.AccountingRepository.Get(n => n.TypeID == ReportType);
                //این خط بالا بدون فیلتر اسم از کمبوباکس گرید رو پر میکنه

                DateTime? Start;
                DateTime? End = null;//علامت سوال باعث نال پذیری میشه
                //دیت تایم نال ناپزیره

                if (mtxtFromDate.Text != "    /  /")
                {
                    //____/__/__
                    Start = Convert.ToDateTime(mtxtFromDate.Text);
                    //Start = ExDateConvertor.ToMiladi(Start.Value);
                    FilterResult = FilterResult.Where(n => n.DateTime >= Start).ToList();
                }

                if (mtxtToDate.Text != "    /  /")
                {
                    //____/__/__
                    End = Convert.ToDateTime(mtxtToDate.Text);
                    //End = ExDateConvertor.ToMiladi(End.Value);
                    FilterResult = FilterResult.Where(n => n.DateTime >= End).ToList();
                }

                dgvReport.Rows.Clear();
                dgvReport.AutoGenerateColumns = false;
                dgvReport.Columns[0].Visible = false;
                foreach (var FRShow in FilterResult)
                {
                    string CustomerName = Context.Customer_ripositories.GetCustomerNameByID(FRShow.CustomerID);
                    dgvReport.Rows.Add(FRShow.AccountingID, CustomerName, FRShow.Amount, FRShow.Description,
                        FRShow.DateTime.ToString("dddd yyyy/MM/dd"), FRShow.DateTime.GreCal(), FRShow.SubmitDateTime);
                }
                Context.Dispose();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReport.CurrentRow != null)
            {
                using (UnitOfWork Context = new UnitOfWork())
                {
                    int ID = Convert.ToInt32(dgvReport.CurrentRow.Cells[0].Value);
                    if (MessageBox.Show("ایا حذف شود؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Context.AccountingRepository.Delete(ID);
                        Context.SaveChanges();
                        Filter();
                    }
                    Context.Dispose();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReport.CurrentRow != null)
            {
                using (UnitOfWork Context = new UnitOfWork())
                {
                    int ID = Convert.ToInt32(dgvReport.CurrentRow.Cells[0].Value);
                    frmAccounting frmAcc = new frmAccounting();
                    frmAcc.EditOrAdd = ID;
                    if (frmAcc.ShowDialog() == DialogResult.OK)
                    {
                        Filter();
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter Printer = new DGVPrinter();
            if (ReportType == 1)
            {
                Printer.Title = "گزارش دریافت ها";
            }
            else
            {
                Printer.Title = "گزارش پرداخت ها";
            }
            Printer.SubTitle = DateTime.Now.ToString("dddd yyyy/MM/dd");
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //Specifies the display and layout information for text strings
            //https://learn.microsoft.com/en-us/dotnet/api/system.drawing.stringformatflags?view=windowsdesktop-8.0
            // LineLimit : Only entire lines are laid out in the formatting rectangle. By default layout continues
            //             until the end of the text, or until no more lines are visible as a result of clipping,
            //             whichever comes first. Note that the default settings allow the last line to be partially
            //             obscured by a formatting rectangle that is not a whole multiple of the line height. To
            //             ensure that only whole lines are seen, specify this value and be careful to provide a
            //             formatting rectangle at least as tall as the height of one line.
            //
            // NoClip : Overhanging parts of glyphs, and unwrapped text reaching outside the formatting
            //          rectangle are allowed to show. By default all text and glyph parts reaching outside
            //          the formatting rectangle are clipped.

            Printer.PageNumbers = true;
            Printer.PageNumberInHeader = false;
            Printer.PorportionalColumns = true;
            //سطون هایی که متناسب با همن هستند
            //به این شکل هست که عرض سطون هارو به نسبت  عرض صفحه درست میکنه
            //در واقع سطون هارو میکشه تا از هر دو سمت به صفحه چسبیده باشن 
            //مطمئن نیستم
            Printer.HeaderCellAlignment = StringAlignment.Near;
            //StringAlignment
            //Specifies the alignment of a text string relative to its layout rectangle
            //تراز یک رشته متن را نسبت به مستطیل طرح بندی آن مشخص می کند.
            //
            //Center  Specifies that text is aligned in the center of the layout rectangle.
            //Far     Specifies that text is aligned far from the origin position of the layout rectangle.
            //        In a left - to - right layout, the far position is right.In a right - to - left layout,
            //        the far position is left.
            //Near    Specifies the text be aligned near the layout. In a left - to - right layout,
            //        the near position is left.In a right - to - left layout, the near position is right

            Printer.Footer = "m_d_rezaei";
            Printer.FooterSpacing = 15;
            Printer.PrintDataGridView(dgvReport);
            
        }
    }
}