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
    [RoutePrefix("api/Book")]
    public class UserController : ApiController
    {
        BMSDBContext context = new BMSDBContext();
        UserRepository repo = new UserRepository();

        public IHttpActionResult Get()
        {
            return Ok(repo.GetAll());
        }

        public IHttpActionResult Post(User bk)
        {
            repo.Insert(bk);
            return Ok(bk);
        }

        //[Route("{id}")]
        //public IHttpActionResult Put(User bk, int id)
        //{
        //    repo.Update(bk, id);
        //    return Ok(bk);
        //}

        public IHttpActionResult Delete(int id)
        {
            repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //[Route("{id}")]
        //public IHttpActionResult GetDetails(int id)
        //{
        //    return Ok(repo.Get(id));
        //}

        //[Route("email/pass")]
        //public IHttpActionResult GetEmailAndPass(string email, string pass)
        //{
        //    return Ok(repo.GetEmailNdPass(email, pass));
        //}

        [Route("{email}")]
        public IHttpActionResult GetDuplicateMail(string email)
        {
            bool us = context.Users.Any(u => u.email == email);
            if (us == true)
            {
                return Ok();
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}

    

