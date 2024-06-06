using CQRSProject.DAL;
using CQRSProject.Mediator.Features.Commands.EmployeeCommands;
using CQRSProject.Mediator.Features.Queries.EmployeeQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetEmployeeQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _mediator.Send(new RemoveEmployeeCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }


    }
}
