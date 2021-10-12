using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookAppBackend.Models
{
    
    public class BookSql : IBook
    {
        private string connectionString;


        public BookSql()
        {
           this.connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM Books";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    Book book = new Book();
                    book.Id = dr.GetInt32(0);
                    book.Title = dr.GetString(1);
                    book.Author = dr.GetString(2);
                    book.Price = dr.GetInt32(3);
                    book.Image = dr.GetString(4);
                    books.Add(book);
                }

            }

            return books;

        }
        public Book AddBook(Book book)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into Books ( Title, Author, Price , Image) values ('" + book.Title + "', '" + book.Author + "' , " + Convert.ToInt32(book.Price) + " , '"+ book.Image +"')";
                conn.Open();
                int rows = comm.ExecuteNonQuery();
            }
            return book;
              
               
        }

        public int DeleteBook(int id)
        {
            int rows=0;
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            { 
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "DELETE FROM Books WHERE Id="+id;
                conn.Open();
                 rows = comm.ExecuteNonQuery();
            }
           return rows;
        }

        public int EditBook(int id, Book book)
        {
            int rows=0;
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "UPDATE Books SET Title = '" + book.Title + "', Author = '" + book.Author + "', Price = '" + Convert.ToInt32( book.Price) + "', Image = '" + book.Image+"'  WHERE Id = "+id;
                conn.Open();
                 rows = comm.ExecuteNonQuery();
            }
            return rows;
            
        }

        public Book GetBookById(int id)
        {
            Book book = new Book();
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT * FROM Books WHERE Id="+id;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {

                    book.Id = dr.GetInt32(0);
                    book.Title = dr.GetString(1);
                    book.Author = dr.GetString(2);
                    book.Price = dr.GetInt32(3);
                    book.Image = dr.GetString(4);
                  
                }
            }

            return book;
        }

       
    }
}