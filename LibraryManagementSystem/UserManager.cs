using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class UserManager
    {
        FileManager fileManager { get; }

        public List<Customer> customerList;

        public UserManager()
        {
            fileManager = new FileManager();
            customerList = fileManager.getAllUserDataFromFile();
        }

        public void AddUser(Customer customer)
        {
            fileManager.writeUserDataToFile(customer);
            Console.WriteLine("User has been added.");
        }

        public void DisplayUsers()
        {
            foreach (Customer customer in customerList)
            {
                Console.WriteLine(customer.ToString());
            }
        }
    }
}
