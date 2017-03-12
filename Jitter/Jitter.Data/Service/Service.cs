namespace Jitter.Data.Service
{
    using Contracts;
    public class Service : IService
    {
        private IJitterData data;

        public Service(IJitterData data)
        {
            this.Data = data;
        }

        public IJitterData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }
    }
}
