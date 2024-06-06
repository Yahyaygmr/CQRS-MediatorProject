using CQRSProject.Mediator.Features.Results.EmployeeResults;
using MediatR;

namespace CQRSProject.Mediator.Features.Queries.EmployeeQueries
{
    public class GetEmployeeQuery : IRequest<List<GetEmployeeQueryResult>>
    {
    }
}
