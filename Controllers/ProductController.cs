using CQRSProject.CQRS.Commands;
using CQRSProject.CQRS.Handlers.ProductHandlers;
using CQRSProject.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public ProductController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveProduct(int id)
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(new UpdateProductCommand()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice
            });
        }
        [HttpPost]
        public IActionResult EditProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
