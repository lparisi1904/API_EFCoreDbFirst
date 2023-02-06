using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;

namespace API_EFCoreDbFirst.DataManager
{
    public class BookDataManager: IDataRepository<Book, BookDto>
    {
        readonly BookStoreContext _storeContext;

        public BookDataManager(BookStoreContext storeContext) { 
            _storeContext = storeContext;
        }

        public Task Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Book?> Get(long id)
        {
           // _bookStoreContext.ChangeTracker.LazyLoadingEnabled = false;

            var book = _storeContext.Books
                .SingleOrDefault(x=> x.Id == id);
            if (book == null)
                return null;

            // CARICAMENTO ESPLICITO..
            //È possibile caricare in modo esplicito una proprietà di navigazione tramite l'API ..
            // viene utilizzato per ottenere i dettagli di un file (Book..)
            _storeContext.Entry(book)
                .Collection(b => b.BookAuthors)
                .Load();

            _storeContext.Entry(book)
                .Reference(r => r.Publisher)
                .Load();


            return book;
        }

        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetDto(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
