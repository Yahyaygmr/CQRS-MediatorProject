using CQRSProject.Mediator.Features.Queries.EmployeeQueries;
using CQRSProject.Mediator.Features.Results.EmployeeResults;
using MediatR;

namespace CQRSProject.Mediator.Features.Handlers.EmployeeHandlers.Read
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
    {
        public Task<GetEmployeeByIdQueryResult> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
