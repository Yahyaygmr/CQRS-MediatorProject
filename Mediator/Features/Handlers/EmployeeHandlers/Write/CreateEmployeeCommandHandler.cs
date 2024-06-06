using CQRSProject.DAL;
using CQRSProject.Mediator.Features.Commands.EmployeeCommands;
using MediatR;

namespace CQRSProject.Mediator.Features.Handlers.EmployeeHandlers.Write
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
    {
        private readonly Context _context;

        public CreateEmployeeCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Employee
            {
                Name = request.Name,
                Salary = request.Salary,
                Surmane = request.Surmane,
            });
            await _context.SaveChangesAsync();
        }
    }
}
