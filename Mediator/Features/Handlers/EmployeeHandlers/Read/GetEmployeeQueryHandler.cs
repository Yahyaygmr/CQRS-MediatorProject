using CQRSProject.DAL;
using CQRSProject.Mediator.Features.Queries.EmployeeQueries;
using CQRSProject.Mediator.Features.Results.EmployeeResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Mediator.Features.Handlers.EmployeeHandlers.Read
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<GetEmployeeQueryResult>>
    {
        private readonly Context _context;

        public GetEmployeeQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetEmployeeQueryResult>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {

            return await _context.Employees.Select(e => new GetEmployeeQueryResult
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                Salary = e.Salary,
                Surmane = e.Surmane,
            }).ToListAsync();
        }
    }
}
