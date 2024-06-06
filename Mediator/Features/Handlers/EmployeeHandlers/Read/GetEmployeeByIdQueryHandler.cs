using CQRSProject.DAL;
using CQRSProject.Mediator.Features.Queries.EmployeeQueries;
using CQRSProject.Mediator.Features.Results.EmployeeResults;
using MediatR;

namespace CQRSProject.Mediator.Features.Handlers.EmployeeHandlers.Read
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
    {
        private readonly Context _context;

        public GetEmployeeByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetEmployeeByIdQueryResult> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            return new GetEmployeeByIdQueryResult
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Salary = employee.Salary,
                Surmane = employee.Surmane,
            };
        }
    }
}
