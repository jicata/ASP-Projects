namespace ShishaKingdom.Web.Services.Contracts
{
    using Data.Contracts;

    public interface IService
    {
        string GetCurrentUser();
        IShishaKingdomData Data { get; }

    }
}
