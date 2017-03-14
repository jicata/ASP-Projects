namespace Jitter.Services.Contracts
{
    using System.Collections.Generic;
    using System.Security.Principal;
    using Models;
    using ViewModels.JeetViewModels;

    public interface IJeetService : IService
    {
        IEnumerable<Jeet> GetAllJeets();
        Jeet CreateJeet(JeetViewModel jvm);
    }
}
