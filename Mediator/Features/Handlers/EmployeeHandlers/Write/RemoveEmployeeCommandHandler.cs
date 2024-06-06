using CQRSProject.CQRS.Commands;
using CQRSProject.DAL;
using CQRSProject.Mediator.Features.Commands.EmployeeCommands;
using MediatR;

namespace CQRSProject.Mediator.Features.Handlers.EmployeeHandlers.Write
{
    public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly Context _context;

        public RemoveEmployeeCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
