using CQRSProject.CQRS.Commands;
using CQRSProject.DAL;

namespace CQRSProject.CQRS.Handlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly Context _context;

        public RemoveCategoryCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(RemoveCategoryCommand command)
        {
            var value = _context.Categories.Find(command.Id);

            _context.Categories.Remove(value);
            _context.SaveChanges();
        }
    }
}
