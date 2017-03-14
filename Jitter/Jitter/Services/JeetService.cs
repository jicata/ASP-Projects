namespace Jitter.Services
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Data.Contracts;
    using Models;
    using ViewModels.JeetViewModels;

    public class JeetService : Service,IJeetService
    {
        public JeetService(IJitterData data) 
            : base(data)
        {
        }

        public IEnumerable<Jeet> GetAllJeets()
        {
            return this.Data.Jeets.GetAll();
        }

        public Jeet CreateJeet(JeetViewModel jvm)
        {
            var userId = base.GetCurrentUser();
            Jeet jeet = new Jeet()
            {
                UserId = userId,
                Content = jvm.Content,
                PostedOn = DateTime.Now
            };
            return jeet;
        }

    }
}
