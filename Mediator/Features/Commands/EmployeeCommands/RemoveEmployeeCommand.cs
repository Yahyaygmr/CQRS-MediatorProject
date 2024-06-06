using MediatR;

namespace CQRSProject.Mediator.Features.Commands.EmployeeCommands
{
    public class RemoveEmployeeCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveEmployeeCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
