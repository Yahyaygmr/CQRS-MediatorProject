using CQRSProject.CQRS.Commands;
using CQRSProject.CQRS.Handlers;
using CQRSProject.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getCategoryQueryHandler.Handle();

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryCommand command)
        {
            _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveCategory(int id)
        {
            _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return View(new UpdateCategoryCommand()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            });
        }
        [HttpPost]
        public IActionResult EditCategory(UpdateCategoryCommand command)
        {
            _updateCategoryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
