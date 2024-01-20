using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem
{
    class FileManager
    {
        private string filePathBookData = "data//bookdata.txt";
        private string filePathUserData = "data//users.txt";

        public FileManager() { 
        }

        public void  WriteBooksToFile(List<Book> books)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePathBookData))
                {
                    foreach (var book in books)
                    {
                        writer.WriteLine($"{book.title},{book.author},{book.isbn},{book.copyAmount},{book.borrowedCopyAmount}");
                    }
                    writer.Close();
                }
               // Console.WriteLine("Book information was written to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writining to file: Error: {ex.Message}");
            }
        }

        public List<Book> ReadBooksFromFile()
        {
            List<Book> books = new List<Book>();

            try
            {
                using (StreamReader reader = new StreamReader(filePathBookData))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] bookInfo = line.Split(',');

                        if (bookInfo.Length == 5)
                        {
                            string title = bookInfo[0];
                            string author = bookInfo[1];
                            string isbn = bookInfo[2];
                            int copyAmount = int.Parse(bookInfo[3]);
                            int borrowedCopyAmount = int.Parse(bookInfo[4]);

                            books.Add(new Book(title, author, isbn, copyAmount, borrowedCopyAmount));
                        }
                    }
                }

                //Console.WriteLine("Book information was read from the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }

            return books;
        }
    
        public void writeUserDataToFile(Customer customer)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePathUserData, true))
                {
                    writer.WriteLine($"{customer.id},{customer.username},{customer.password},{customer.borrowedBookISBNs}");
                    writer.Close();
                }
                //Console.WriteLine("User has been added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding the customer: Error: {ex.Message}");
            }
        }

        public List<Customer> getAllUserDataFromFile() 
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (StreamReader reader = new StreamReader(filePathUserData))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] userInfo = line.Split(',');

                        if (userInfo.Length == 4)
                        {
                            int id = int.Parse(userInfo[0]);
                            string username = userInfo[1];
                            string password = userInfo[2];
                            List<string> borrowedBookISBNs = (userInfo[3].Split(',')).ToList();

                            customers.Add(new Customer(id, username, password, borrowedBookISBNs));
                              
                        }
                    }
                }

                //Console.WriteLine("Users data was read from the file.");
                //foreach (Customer customer in customers)
                //{
                //    Console.WriteLine($"Customer id: {customer.id}\nCustomer username: {customer.username}\nCustomer psw: {customer.password}\nBorrowedBooks: {customer.borrowedBookISBNs}\n");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }

            return customers;
        }
    }
}
