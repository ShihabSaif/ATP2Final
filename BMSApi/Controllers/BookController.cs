using BMSEntity;
using BMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BMSApi.Controllers
{
    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {
        BookRepository repo = new BookRepository();
        private BMSDBContext context = new BMSDBContext();

        public IHttpActionResult Get()
        {
            //List<string> list = repo.DistinctCategoryString();
            List<Book> list = repo.DistinctCategory();

            //ViewBag.bList = list;
            return Ok(this.repo.GetAll());
        }

        public IHttpActionResult Create(Book bk)
        {                 
                repo.Insert(bk);
                //string uri = Url.Link("GetProductById", new { id = bk.BookId });
            //return RedirectToAction(uri,"Index");

            return Created("",bk);
        }

        //[Route("{id}")]
        //public IHttpActionResult Put(Book bk,int id)
        //{
        //        repo.Update(bk,id);
        //        //return RedirectToAction("Index");
            
        //    return Ok(bk);
        //    //return RedirectToAction("Index");
        //}

        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //list of books of a specific category
        //[Route("{category}")]
        //public IHttpActionResult GetCategory(string category)
        //{
        //    List<Book> bk = context.Books.Where(b => b.category == category).ToList();

        //    if (bk != null)
        //        return Ok(bk);
        //    else
        //        return null;
        //}

        ////search a book using title name or author name
        //[Route("{search}")]
        //public IHttpActionResult GetCategorizedBook(string search)
        //{
        //    return Ok(repo.BookSearch(search));
        //}

        [Route("{bookId}/{str}")]
        public IHttpActionResult GetRating(double str, int bookId)
        {
            return Ok(repo.rating(str,bookId));
        }









        ////unique category list
        //public IHttpActionResult GetCategory()
        //{
        //    return Ok(repo.DistinctCategoryString());
        //}
    }
}
