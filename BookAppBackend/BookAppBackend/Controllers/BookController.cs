using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookAppBackend.Models;
using System.Web.Http.Cors;

namespace BookAppBackend.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class BookController : ApiController
    {
        private IBook repo;
        public BookController()
        {
            this.repo = new BookSql();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data= this.repo.GetBooks();
            return Ok(data);

        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = this.repo.GetBookById(id);

            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
           
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book id does not exixt");
            
        }

        [HttpPost]
        public HttpResponseMessage Post(Book book)
        {
            var data= this.repo.AddBook(book);
           return Request.CreateResponse(HttpStatusCode.Created, "Record inserted ");
        }


        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
           var data= this.repo.DeleteBook(id);
           return Request.CreateResponse(HttpStatusCode.Created, "Record Deleted ");
        }

        [HttpPut]
        public HttpResponseMessage Put(int id,Book book)
        {
          var data=  this.repo.EditBook(id, book);

           return Request.CreateResponse(HttpStatusCode.Created, "Record Edited ");
        }


    }
}
