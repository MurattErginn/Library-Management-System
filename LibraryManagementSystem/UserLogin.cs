using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class UserLogin
    {
        UserManager userManager = new UserManager();

        public UserLogin()
        {   
        }

        public List<Customer> GetCustomerList()
        {
            return userManager.customerList;
        }

        public Customer Login(string username, string password)
        {
            foreach (var customer in userManager.customerList)
            {
                if(customer.username == username && customer.password == password)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
