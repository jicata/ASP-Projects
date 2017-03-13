namespace Jitter.Data.Service
{
    using Contracts;
    public class Service : IService
    {
        public Service(IJitterData data)
        {
            this.Data = data;
        }

        public IJitterData Data { get; private set; }
    }
}
