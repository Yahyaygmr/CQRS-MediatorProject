using MediatR;

namespace CQRSProject.Mediator.Features.Commands.EmployeeCommands
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surmane { get; set; }
        public decimal Salary { get; set; }
    }
}
