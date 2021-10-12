using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAppBackend.Models
{
    interface IBook
    {
        List<Book> GetBooks();
        Book GetBookById(int i);
        Book AddBook(Book book);
        int DeleteBook(int id);
        int EditBook(int id, Book book);

    }
}
