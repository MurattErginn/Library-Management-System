using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementSystem
{
    class BookBorrowingManager
    {
        List<BorrowTransaction> borrowingTransactions = new List<BorrowTransaction>();

        public BookBorrowingManager()
        {
        }

        public void RemoveTransactionFromList(Customer customer, Book book) {
            BorrowTransaction transactionToRemove = borrowingTransactions.Find(transaction => transaction.customer == customer && transaction.book == book);

            if(transactionToRemove != null)
            {
                borrowingTransactions.Remove(transactionToRemove);
                Console.WriteLine("Borrow transaction has been removed.");
            }

            else
            {
                Console.WriteLine("No matching borrow transaction found to remove.");
            }
        }

        public void AddTransactionToList(BorrowTransaction newTransaction)
        {
            borrowingTransactions.Add(newTransaction);
        } 

        public void DisplayBorrows()
        {
            foreach (var transaction in borrowingTransactions) 
            { 
                Console.WriteLine($"Borrowed Book Information:\n" +
                                  $"Title: {transaction.book.title}\n" +
                                  $"Author: {transaction.book.author}\n" +
                                  $"ISBN: {transaction.book.isbn}\n" +
                                  $"Borrower: {transaction.customer.username}\n" +
                                  $"Borrow Start Date: {transaction.startDate}\n" +
                                  $"Due Time: {transaction.dueTime}\n" +
                                  $"Remaining Time: {transaction.CalculateRemaningTime()} days");
            }
        }

        public void DisplayOverdueTransactions(Customer customer, BookBorrowingManager borrowingManager)
        {
            var overdueTransactions = borrowingManager.borrowingTransactions
                .Where(transaction => transaction.customer == customer && IsTransactionOverdue(transaction))
                .ToList();

            if (overdueTransactions.Any())
            {
                Console.WriteLine($"Overdue Transactions for {customer.username}:");
                foreach (var transaction in overdueTransactions)
                {
                    Console.WriteLine($"Book Title: {transaction.book.title}, Due Time: {transaction.dueTime}");
                }
            }
            else
            {
                Console.WriteLine($"No overdue transactions found for {customer.username}.");
            }
        }

        public bool IsTransactionOverdue(BorrowTransaction transaction)
        {
            return DateTime.Now > transaction.dueTime;
        }

        //deneme
        public void ChangeDueTimeOfTransaction()
        {
            this.borrowingTransactions.First().ChangeDueTime();
        }
    }
}
