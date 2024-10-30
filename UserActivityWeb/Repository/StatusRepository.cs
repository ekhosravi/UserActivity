using UserActivityWeb.Models;
using UserActivityWeb.Repository.IRepository;

namespace UserActivityWeb.Repository
{
    public class StatusRepository : Repository< Status> , IStatusRepository 
    {
        private readonly IHttpClientFactory _clientFactory;

        public StatusRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

    }
}
