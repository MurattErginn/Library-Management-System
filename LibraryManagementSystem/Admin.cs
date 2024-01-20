using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class Admin : IUser
    {
        private static int nextId = 1;
        public int id { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }

        public Admin(string username, string password)
        {
            id = nextId++;
            this.username = username;
            this.password = password;
        }

        public Admin()
        {
            id = nextId++;
            this.username = "admin";
            this.password = "admin1234"; //sorry about the default values :)
        }

        public void ChangePassword(string newPassword)
        {
            password = newPassword;
        }
    }
}
