using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class Library
    {
        FileManager fileManager;

        private List<Book> books;

        BookBorrowingManager bbmanager = new BookBorrowingManager();

        public Library()
        {
            fileManager = new FileManager();
            books = fileManager.ReadBooksFromFile();
            bbmanager = new BookBorrowingManager();
        }

        public BookBorrowingManager BookBorrowingManagerInstance
        {
            get { return bbmanager; }
        }

        public void AddBook(Book newBook)
        {
            books.Add(newBook);
            WriteBooksToFile();
        }

        public void AddBook(string title, string author, string isbn, int copyAmount)
        {
            Book newBook = new Book(title, author, isbn, copyAmount);
            books.Add(newBook);
            WriteBooksToFile();
        }

        public void DisplayAllBooks()
        {
            foreach (Book book in books)
            {
                //Console.WriteLine($"Book Title: {book.title}, Author: {book.author}, ISBN: {book.isbn}, Amount of Copies: {book.copyAmount}, Amount of Borrowed Copies: {book.borrowedCopyAmount}");
                Console.WriteLine(book.ToString());
            }
        }

        public List<Book> SearchByTitle(string title)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if(title.Equals(book.title))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public List<Book> SearchByAuthor(string author)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (author.Equals(book.author))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        public Book SearchByIsbn(string isbn)
        {
            foreach (Book book in books)
            {
                if (isbn.Equals(book.isbn))
                {
                    return book;
                }
            }
            return null;
        }

        public void BorrowBookByISBN(string isbn, Customer customer)
        {
            Book bookToBorrow = books.Find(book => book.isbn == isbn);
            
            if(bookToBorrow != null && bookToBorrow.copyAmount > 0)
            {
                bbmanager.AddTransactionToList(new BorrowTransaction(bookToBorrow, customer));
                bookToBorrow.copyAmount--;
                bookToBorrow.borrowedCopyAmount++;
                customer.borrowedBookISBNs.Add(bookToBorrow.isbn);
                Console.WriteLine("Book has been borrowed.");
                WriteBooksToFile();
            }
            else
            {
                Console.WriteLine("Error");
            }

        }

        public void BorrowBookByTitle(string title, Customer customer)
        {
            Book bookToBorrow = books.Find(book => book.title == title);

            if (bookToBorrow != null && bookToBorrow.copyAmount > 0)
            {
                bbmanager.AddTransactionToList(new BorrowTransaction(bookToBorrow, customer));
                bookToBorrow.copyAmount--;
                bookToBorrow.borrowedCopyAmount++;
                customer.borrowedBookISBNs.Add(bookToBorrow.isbn);
                Console.WriteLine("Book has been borrowed.");
                WriteBooksToFile();
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        public void ReturnBookByISBN(string isbn, Customer customer)
        {
            if (customer.borrowedBookISBNs.Contains(isbn))
            {
                customer.borrowedBookISBNs.Remove(isbn);

                Book returnedBook = this.SearchByIsbn(isbn);

                if (returnedBook != null)
                {
                    bbmanager.RemoveTransactionFromList(customer, returnedBook);
                    returnedBook.borrowedCopyAmount--;
                    returnedBook.copyAmount++;

                    WriteBooksToFile();
                    Console.WriteLine("The book has been returned.");
                }
            }
            else
            {
                Console.WriteLine("No book borrowed with this ISBN could be found.");
            }
        }

        public void ReturnBookByTitle(string title, Customer customer)
        {
            List<string> borrowedISBNs = customer.borrowedBookISBNs;

            Book bookToReturn = books.Find(book => book.title == title);

            if (bookToReturn != null && borrowedISBNs.Contains(bookToReturn.isbn)) 
            {
                bbmanager.RemoveTransactionFromList(customer, bookToReturn);
                borrowedISBNs.Remove(bookToReturn.isbn);
                bookToReturn.borrowedCopyAmount--;
                bookToReturn.copyAmount++;

                WriteBooksToFile();
                Console.WriteLine("The Book has been returned.");
            }
            else
            {
                Console.WriteLine("No book borrowed with this title could be found.");
            }

        }

        public void DisplayOverdueBooks(Customer customer, BookBorrowingManager borrowingManager)
        {
            bbmanager.DisplayOverdueTransactions(customer, borrowingManager);
        }

        public void ReadBooksFromFile()
        {
            books = fileManager.ReadBooksFromFile();
        }

        public void WriteBooksToFile()
        {
            fileManager.WriteBooksToFile(books);
        }
    }
}
