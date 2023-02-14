using NicaBusApp.Data;
using NicaBusApp.Models;

namespace NicaBusApp.Services
{
    public class UserRepository: GenericRepository<Users>, IUserRepository     
    {
        public UserRepository(NicaBusAppContext context) : base(context)
        {

        }

    }
}
