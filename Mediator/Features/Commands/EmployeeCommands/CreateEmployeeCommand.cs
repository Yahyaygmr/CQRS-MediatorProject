using MediatR;

namespace CQRSProject.Mediator.Features.Commands.EmployeeCommands
{
    public class CreateEmployeeCommand : IRequest
    {
        public string Name { get; set; }
        public string Surmane { get; set; }
        public decimal Salary { get; set; }
    }
}
