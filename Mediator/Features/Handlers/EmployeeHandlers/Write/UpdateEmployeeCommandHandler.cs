using CQRSProject.DAL;
using CQRSProject.Mediator.Features.Commands.EmployeeCommands;
using MediatR;
using NuGet.Protocol.Plugins;

namespace CQRSProject.Mediator.Features.Handlers.EmployeeHandlers.Write
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly Context _context;

        public UpdateEmployeeCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.EmployeeId);

            employee.Surmane = request.Surmane;
            employee.Salary = request.Salary;
            employee.Name = request.Name;

            await _context.SaveChangesAsync();
        }
    }
}
