using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem
{
    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public int copyAmount { get; set; }
        public int borrowedCopyAmount { get; set; }

        public Book(string title, string author, string isbn, int copyAmount)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.copyAmount = copyAmount;
            this.borrowedCopyAmount = 0;
        }

        public Book(string title, string author, string isbn, int copyAmount, int borrowedCopyAmount)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.copyAmount = copyAmount;
            this.borrowedCopyAmount = borrowedCopyAmount;
        }

        public override string ToString()
        {
            return $"Title: {title}, Author: {author}, ISBN: {isbn}, Copy Amount: {copyAmount}, Borrowed Copy Amount: {borrowedCopyAmount}";
        }
    }
}
