using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2_Accounting_ViewModels;
using WindowsFormsApp2_Accounting_DataLayer;

namespace WindowsFormsApp2_Accounting_Logic
{
    public class BalanceReport
    {
        public static ReportViewModel Report()
        {
            ReportViewModel RVM = new ReportViewModel();

            using (UnitOfWork Context = new UnitOfWork())
            {
                DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
                DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, date.Day);

                var recive = Context.AccountingRepository.Get(a => a.TypeID == 1 && a.DateTime >= StartDate && a.DateTime <= EndDate).Select(a => a.Amount).ToList();
                var pay = Context.AccountingRepository.Get(a => a.TypeID == 2 && a.DateTime >= StartDate && a.DateTime <= EndDate).Select(a => a.Amount).ToList();

                RVM.Recive = recive.Sum();
                RVM.Payment = pay.Sum();
                RVM.Balance = RVM.Recive - RVM.Payment;

                Context.Dispose();
            }          
            return RVM;
        }
    }
}
