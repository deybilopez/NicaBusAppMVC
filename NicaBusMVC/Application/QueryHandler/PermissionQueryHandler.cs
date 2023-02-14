using NicaBusMVC.Application.Command;
using NicaBusMVC.Configuration;
using NicaBusMVC.Models;

namespace NicaBusMVC.Application.QueryHandler
{
    public class PermissionQueryHandler: IQueryHandler<User, QueryByIdCommand>
    {
        private readonly IUnidOfWork _unitOfWork;

        public PermissionQueryHandler(IUnidOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetOne(QueryByIdCommand query)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(query.id);
        }
    }
}
