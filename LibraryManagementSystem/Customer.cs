using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class Customer : IUser
    {
        private static int nextId = 1;

        public int id { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }

        public List<string> borrowedBookISBNs { get; private set; }

        public Customer(string username, string password)
        {
            id = nextId++;
            this.username = username;
            this.password = password;
            
        }

        public  Customer(int id, string username, string password, List<string> borrowedBookISBNs) {
            this.id = id;
            this.username = username;
            this.password = password;
            this.borrowedBookISBNs = borrowedBookISBNs;
        }

        public void ChangePassword(string newPassword)
        {
            password = newPassword;
        }

        public override string ToString()
        {
            return $"ID: {id}\n" +
                    "Username: {username}\n" +
                    "Password: {isbn}\n";
        }
    }
}