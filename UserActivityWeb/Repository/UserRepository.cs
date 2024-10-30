using UserActivityWeb.Models;
using UserActivityWeb.Repository.IRepository;

namespace UserActivityWeb.Repository
{
        public class UserRepository : Repository<User>, IUserRepository
        {
            private readonly IHttpClientFactory _clientFactory;

            public UserRepository(IHttpClientFactory clientFactory) : base(clientFactory)
            {
                _clientFactory = clientFactory;
            }

        }
    }
