using CQRSProject.CQRS.Commands;
using CQRSProject.CQRS.Queries;
using CQRSProject.CQRS.Results;
using CQRSProject.DAL;

namespace CQRSProject.CQRS.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler
    {
        private readonly Context _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(RemoveProductCommand command)
        {
            var value = _context.Products.Find(command.Id);

            _context.Products.Remove(value);
            _context.SaveChanges();
        }
    }
}
