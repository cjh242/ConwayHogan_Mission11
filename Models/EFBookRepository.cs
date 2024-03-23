using System.Runtime.CompilerServices;

namespace ConwayHogan_Mission11.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookstoreContext _context;

        public EFBookRepository(BookstoreContext context)
        {
            _context = context;
        }

        public List<Book> Books => _context.Books.ToList();
    }
}
