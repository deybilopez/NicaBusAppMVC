using NicaBusMVC.Application.Command;
using NicaBusMVC.Configuration;

namespace NicaBusMVC.Application.CommandsHandler
{
    public class RemovePermissionCommandHandler : ICommandHandler<RemoveByIdCommand>
    {
        private readonly IUnidOfWork _unitOfWork;
        public RemovePermissionCommandHandler(IUnidOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CommandResult Execute(RemoveByIdCommand command)
        {
            _unitOfWork.UserRepository.Delete(command.Id);

            _unitOfWork.commit();
            return new CommandResult { Status = true, Message = "Permission added succesfully" };
        }
    }
}
