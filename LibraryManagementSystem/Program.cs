using System;
using System.Collections.Generic;
using System.Numerics;
using System.Transactions;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {   
            // To check if you can write to file.
            //List<string> list = new List<string>();
            //list.Add("ISBN-1");
            //list.Add("ISBN-2");
            //Customer newCustomer = new Customer(2, "murat", "heyyo", list);

            //FileManager fileManager = new FileManager();

            //fileManager.writeUserDataToFile(newCustomer);

            int maxLoginAttempts = 3;
            int loginAttempts = 0;


            string loginMenu = "1. Login\n" +
                               "2. Register\n";

            string mainMenu = "1. Add a new book\n" +
                          "2. List all of the books\n" +
                          "3. Search for a book\n" +
                          "4. Borrow a book\n" +
                          "5. Return a book\n" +
                          "6. View information about overdue books\n" +
                          "0. Exit";

            string searchMenu = "1. Search by title\n" +
                                "2. Search by author\n";

            string borrowMenu = "1. Search by title\n" +
                                "2. Search by ISBN\n";

            UserManager userManager = new UserManager();

            while (true)
            {
                Console.WriteLine(loginMenu);
                Console.Write("Please choose the transaction you want to perform: ");
                string loginChoice = Console.ReadLine();

                switch (loginChoice)
                {
                    case "1":
                        //login
                        while (loginAttempts < maxLoginAttempts)
                        {
                            Console.Write("Username: ");
                            string userName = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();

                            UserLogin newLogin = new UserLogin();

                            Customer LoggedCustomer = newLogin.Login(userName, password);

                            if (LoggedCustomer != null)
                            {
                                Console.WriteLine($"Hello {userName}, you logged in successfully !");
                                List<Customer> customerList = newLogin.GetCustomerList();

                                Library library = new Library();

                                while (true)
                                {
                                    Console.WriteLine(mainMenu);
                                    Console.Write("Please choose the transaction you want to perform: ");
                                    string choice = Console.ReadLine();
                                    switch (choice)
                                    {
                                        case "1":
                                            //add book
                                            Console.Write("Book title: ");
                                            string title = Console.ReadLine();
                                            Console.Write("Book author: ");
                                            string author = Console.ReadLine();
                                            Console.Write("Book ISBN: ");
                                            string ISBN = Console.ReadLine();
                                            Console.Write("Book Copy Amount: ");
                                            int copyAmount = int.Parse(Console.ReadLine());

                                            library.AddBook(title, author, ISBN, copyAmount);
                                            Console.WriteLine("Book has been added.");
                                            break;

                                        case "2":
                                            //list book
                                            library.DisplayAllBooks();
                                            Console.WriteLine("Please press any key to continue...");
                                            Console.ReadKey();
                                            break;

                                        case "3":
                                            // search book
                                            Console.WriteLine(searchMenu);
                                            Console.Write("Please choose the search method you want to perform: ");
                                            string searchChoice = Console.ReadLine();
                                            switch (searchChoice)
                                            {
                                                case "1":
                                                    Console.Write("Please enter the title of the book: ");
                                                    string searchedBookTitle = Console.ReadLine();
                                                    List<Book> serchedBooksByTitle = library.SearchByTitle(searchedBookTitle);
                                                    if (serchedBooksByTitle != null)
                                                    {
                                                        foreach (Book book in serchedBooksByTitle)
                                                        {
                                                            Console.WriteLine(book.ToString());
                                                        }
                                                        Console.WriteLine("Please press any key to continue...");
                                                        Console.ReadKey();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There is no book with the entered title.");
                                                    }
                                                    break;

                                                case "2":
                                                    Console.Write("Please enter the author of the book: ");
                                                    string searchedBookAuthor = Console.ReadLine();
                                                    List<Book> serchedBooksbyAuthor = library.SearchByAuthor(searchedBookAuthor);
                                                    if (serchedBooksbyAuthor != null)
                                                    {
                                                        foreach (Book book in serchedBooksbyAuthor)
                                                        {
                                                            Console.WriteLine(book.ToString());
                                                        }
                                                        Console.WriteLine("Please press any key to continue...");
                                                        Console.ReadKey();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There is no book with the entered author.");
                                                    }
                                                    break;
                                            }
                                            break;

                                        case "4":
                                            // borrow book
                                            Console.Write(borrowMenu);
                                            Console.Write("Please choose the search method you want to perform: ");
                                            string searchChoiceForBorrow = Console.ReadLine();

                                            switch (searchChoiceForBorrow)
                                            {
                                                case "1":
                                                    Console.Write("Enter the title of the book you want to borrow: ");
                                                    string bookToBorrowTitle = Console.ReadLine();
                                                    if (bookToBorrowTitle != null)
                                                    {
                                                        library.BorrowBookByTitle(bookToBorrowTitle, LoggedCustomer);
                                                        Console.WriteLine("Please press any key to continue...");
                                                        Console.ReadKey();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There is no book with the entered title.");
                                                    }
                                                    break;

                                                case "2":
                                                    Console.Write("Enter the ISBN of the book you want to borrow: ");
                                                    string bookToBorrowISBN = Console.ReadLine();
                                                    if (bookToBorrowISBN != null)
                                                    {
                                                        library.BorrowBookByISBN(bookToBorrowISBN, LoggedCustomer);
                                                        Console.WriteLine("Please press any key to continue...");
                                                        Console.ReadKey();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There is no book with the entered title.");
                                                    }
                                                    break;
                                            }
                                            break;

                                        case "5":
                                            //return book
                                            Console.Write(borrowMenu);
                                            Console.Write("Please choose the search method you want to perform: ");
                                            string searchChoiceForReturn = Console.ReadLine();
                                            switch (searchChoiceForReturn)
                                            {
                                                case "1":
                                                    Console.Write("Enter the title of the book you want to return: ");
                                                    string bookToReturnTitle = Console.ReadLine();
                                                    if (bookToReturnTitle != null)
                                                    {
                                                        library.ReturnBookByTitle(bookToReturnTitle, LoggedCustomer);
                                                        Console.WriteLine("Please press any key to continue...");
                                                        Console.ReadKey();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There is no book to return with the entered title.");
                                                    }

                                                    break;

                                                case "2":
                                                    Console.Write("Enter the ISBN of the book you want to return: ");
                                                    string bookToReturnISBN = Console.ReadLine();
                                                    if (bookToReturnISBN != null)
                                                    {
                                                        library.ReturnBookByISBN(bookToReturnISBN, LoggedCustomer);
                                                        Console.WriteLine("Please press any key to continue...");
                                                        Console.ReadKey();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("There is no book to return with the entered ISBN.");
                                                    }
                                                    break;
                                            }
                                            break;

                                        case "6":
                                            //display overdue books
                                            library.DisplayOverdueBooks(LoggedCustomer, library.BookBorrowingManagerInstance);
                                            Console.WriteLine("Please press any key to continue...");
                                            Console.ReadKey();
                                            break;

                                        // To test if overDueTime is working, uncomment the lines below and enter "7" in the menu
                                        // after that enter "6" to see overDueTransactions.

                                        //case "7":
                                        //    library.BookBorrowingManagerInstance.ChangeDueTimeOfTransaction();
                                        //    Console.WriteLine("Please press any key to continue...");
                                        //    Console.ReadKey();
                                        //    break;

                                        case "0":
                                            //exit
                                            Console.WriteLine("Exiting... Have a nice day!");
                                            return;
                                        default:
                                            Console.WriteLine("Invalid choice. Be careful!");
                                            break;
                                    }
                                }

                            }
                            else
                            {
                                loginAttempts++;
                                Console.WriteLine("Wrong password or username. Try again!");
                                Console.WriteLine($"Remaining attempts: {maxLoginAttempts - loginAttempts}");
                            }
                            if (loginAttempts == maxLoginAttempts)
                            {
                                Console.WriteLine("Too many unsuccessful login attempts. Exiting program.");
                            }
                        }
                        break;

                    case "2":
                        //register
                        Console.Write("Username: ");
                        string newCustomerUserName = Console.ReadLine();
                        Console.Write("Password: ");
                        string newCustomerPassword = Console.ReadLine();
                        Customer newCustomer = new Customer(newCustomerUserName, newCustomerPassword);
                        userManager.AddUser(newCustomer);
                        Console.WriteLine("Please press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }
        }
    }
}
