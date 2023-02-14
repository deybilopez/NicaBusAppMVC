using NicaBusMVC.Configuration;
using NicaBusMVC.Models;

namespace NicaBusMVC.Application.CommandsHandler
{
    public class AddPermissionCommandHandler : ICommandHandler<UserDTO>
    {
        private readonly IUnidOfWork _unitOfWork;
        public AddPermissionCommandHandler(IUnidOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public CommandResult Execute(UserDTO user)
        {
            var newUser = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            _unitOfWork.UserRepository.Add(newUser);
            _unitOfWork.commit();

            return new CommandResult { Status = true, Message = "Permission added succesfully" };
        }
    }
}
