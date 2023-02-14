using NicaBusMVC.Models;

namespace NicaBusMVC
{
    public interface IQueryHandler<M, C> where M : class where C : class
    {
        Task<IEnumerable<M>> GetAll();
        Task<User> GetOne(C query);

    }
}
