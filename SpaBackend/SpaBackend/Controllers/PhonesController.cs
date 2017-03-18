using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpaBackend.Controllers
{
    using System.Data.Entity.Migrations;
    using Models;

    [RoutePrefix("phones")]
    public class PhonesController : ApiController
    {
        SpaBackendContext context = new SpaBackendContext();
        // GET api/values
        
        public IEnumerable<Phone> Get()
        {

            return this.context.Phones.ToList();
        }

        // GET api/values/5
        public object Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.context.Phones.Find(id));            
        }

        [HttpPost]
        // POST api/values
        public Phone Post([FromBody]Phone phone)
        {
            this.context.Phones.Add(phone);
            this.context.SaveChanges();
            return phone;
        }

        // PUT api/values/5
        [HttpPut]
        public object Put(int id,[FromBody]Phone phone)
        {
            var entity = this.context.Phones.Find(id);
            entity = phone;
            this.context.Phones.AddOrUpdate(entity);
            this.context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }



        // DELETE api/values/5
        public object Delete(int id)
        {
            var entity = this.context.Phones.Find(id);
            this.context.Phones.Remove(entity);
            this.context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }
    }
}
