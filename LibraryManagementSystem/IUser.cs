using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    public interface IUser
    {
        int id { get; }
        string username { get; }
        string password { get; }

        void ChangePassword(string newPassword);
    }
}
