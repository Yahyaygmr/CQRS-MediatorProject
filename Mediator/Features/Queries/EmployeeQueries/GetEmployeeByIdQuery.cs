using CQRSProject.Mediator.Features.Results.EmployeeResults;
using MediatR;

namespace CQRSProject.Mediator.Features.Queries.EmployeeQueries
{
    public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdQueryResult>
    {
        public int Id { get; set; }

        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
