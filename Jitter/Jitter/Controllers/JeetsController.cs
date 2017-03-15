using System.Web.Mvc;

namespace Jitter.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using Data.Contracts;
    using Models;
    using Services;
    using Services.Contracts;
    using ViewModels.JeetViewModels;

    [Authorize]
    [RoutePrefix("jeets")]
    public class JeetsController : BaseController
    {
        private readonly IJeetService service;

        public JeetsController()
            : this(new JitterData(new JitterContext()))
        {
            
        }
        public JeetsController(IJitterData data)
            : base(data)
        {
            this.service = new JeetService(data);
        }

        [AllowAnonymous]
        [Route("all")]
        public ActionResult All()
        {
            var jeetViewModels =
                Mapper.Map<IEnumerable<Jeet>, IEnumerable<JeetViewModel>>
                    (this.service.GetAllJeets()).ToList();
            var item = jeetViewModels[0];
            return this.View(jeetViewModels);
        }

        [Route("new")]
        public ActionResult New()
        {
            return this.View();
        }

        [Route("new")]
        [HttpPost]
        public ActionResult New(JeetViewModel jvm)
        {

            var jeet = this.service.CreateJeet(jvm);
            this.data.Jeets.InsertOrUpdate(jeet);
            this.data.SaveChanges();
            return this.RedirectToAction("All");
        }

        public ActionResult BestJeet()
        {
            var bestJeet = Mapper.Map<JeetViewModel>(this.data.Jeets.GetAll().FirstOrDefault());
            return this.PartialView(bestJeet);
        }

        [Route("Error")]
        public ActionResult Error(int id)
        {
            return this.View();
        }
    }
}