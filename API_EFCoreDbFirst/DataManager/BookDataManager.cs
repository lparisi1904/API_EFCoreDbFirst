using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class BookDataManager: IDataRepository<Book, BookRec>
    {
        readonly BookStoreContext _db;

        public BookDataManager(BookStoreContext storeContext) { 
            _db = storeContext;
        }

        public Task AddAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Task<Publisher> publisher)
        {
            throw new NotImplementedException();
        }

        public async Task<Book?> GetAsync(long id)
        {
           // _db.ChangeTracker.LazyLoadingEnabled = false;

            var book = _db.Books
                .SingleOrDefault(x=> x.Id == id);

            if (book == null)
                return null;

            // CARICAMENTO ESPLICITO..
            //È possibile caricare in modo esplicito una proprietà di navigazione tramite l'API ..
            // viene utilizzato per ottenere i dettagli di un file (Book..)
            _db.Entry(book)
                .Collection(b => b.BookAuthors)
                .Load();

            _db.Entry(book)
                .Reference(r => r.Publisher)
                .Load();

            return book;
        }

        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        private static BookRec BookToDTO(Book book) =>
        new()
        {
            Id= book.Id,
            Title= book.Title,
            Publisher = new PublisherRec ()
            {
                Id= book.Id,
                Name = book.Title
            },
            Authors = (ICollection<AuthorRec >)book.BookAuthors.Select(x => x.Author)
        };


        public Task<BookRec> GetDto(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book entityToUpdate, Book entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Task<Author> authorToUpdate, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
