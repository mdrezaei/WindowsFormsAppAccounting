using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2_Accounting_ViewModels;

namespace WindowsFormsApp2_Accounting_DataLayer
{
    public interface ICustomers_Repositories
    {
        List<Customers_info> GetAllCustomers();
        Customers_info GetCustomerByID(int customerID);
        List<string> GetCustomersName(string Search = "");
        List<ListCustomersViewModels> SecondGetCustomersName(string Search = "");
        bool InsertCustomer(Customers_info customers); 
        bool UpdateCustomer(Customers_info customers); 
        bool DeleteCustomer(Customers_info customers); 
        bool DeleteCustomer(int customersID);
        IEnumerable<Customers_info> SearchCustomers(string searchValues);
        int GetCustomerIDByName(string name);
        string GetCustomerNameByID(int customerID);
        
    }
}
