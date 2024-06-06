namespace CQRSProject.Mediator.Features.Results.EmployeeResults
{
    public class GetEmployeeByIdQueryResult
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surmane { get; set; }
        public decimal Salary { get; set; }
    }
}
}
