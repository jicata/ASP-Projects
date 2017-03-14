namespace Jitter.Services.Contracts
{
    using Data.Contracts;
    using Models;

    public interface IService
    {
        string GetCurrentUser();
        IJitterData Data { get; }

    }
}
