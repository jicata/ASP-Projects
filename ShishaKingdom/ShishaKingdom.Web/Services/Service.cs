namespace ShishaKingdom.Web.Services
{
    using Data.Contracts;

    public class Service
    {
        protected IShishaKingdomData data;

        public Service(IShishaKingdomData data)
        {
            this.data = data;
        }
    }
}