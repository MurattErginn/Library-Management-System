using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class BorrowTransaction
    {
        private DateTime _dueTime;
        public Book book { get; }
        public DateTime startDate { get; }
        public DateTime dueTime
        {
            get { return _dueTime; }
            private set { _dueTime = value; }
        }
        public Customer customer { get; }

        public BorrowTransaction(Book book, Customer customer)
        {
            this.book = book;
            this.startDate = DateTime.Now;
            this.customer = customer;
            this.dueTime = startDate.AddDays(7);
        }

        public int CalculateRemaningTime()
        {
            TimeSpan remainingTime = dueTime - DateTime.Now;

            int remainingDays = (int)remainingTime.TotalDays;

            return remainingDays;
        }

        public void ChangeDueTime()
        {
            dueTime = dueTime.AddDays(-10);
        }

    }
}
