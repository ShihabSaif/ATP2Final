using BMSEntity;
using BMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BMSApi.Controllers
{
    [RoutePrefix("api/UserBook")]
    public class UserBookController : ApiController
    {
        UserBookRepository repo = new UserBookRepository();

        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        public IHttpActionResult Post(UserBook bk)
        {
            repo.Insert(bk);
            return Ok(bk);
        }

        //[Route("{id}")]
        //public IHttpActionResult Put(UserBook bk, int id)
        //{
        //    repo.Update(bk, id);
        //    return Ok(bk);
        //}

        [Route("{id}")]
        public IHttpActionResult GetDetails(int id)
        {
            return Ok(repo.Get(id));
        }

        //[Route("{id}")]
        //public IHttpActionResult Delete(int id)
        //{
        //    repo.Delete(id);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //average rating of a specific book
        //public IHttpActionResult GetAverageRating(int id)
        //{
        //    return Ok(repo.GetAverageRating(id));
        //}

        //public IHttpActionResult GetAverageRatingForUser(int id)
        //{
        //    return Ok(repo.GetAverageRatingForUser(id));
        //}

        //total number of books for a specific userID
        //[Route("{id}")]
        //public IHttpActionResult GetBookCount(int id)
        //{
        //    int count = repo.GetBookCount(id);
        //    return Ok(count);
        //}
        //[Route("{id}")]
        //public IHttpActionResult GetAverageRatingForUser(int id)
        //{
        //    double count = repo.GetAverageRatingForUser(id);
        //    return Ok(count);
        //}

        [Route("{id}")]
        public IHttpActionResult GetAverageRatingForBook(int id)
        {
            double count = repo.GetAverageRating(id);
            return Ok(count);
        }

        [Route("{UserId}/{BookId}")]
        public IHttpActionResult GetUserAndBookId(int UserId, int BookId)
        {
            return Ok(repo.GetUserAndBookId(UserId,BookId));
        }
    }
}
