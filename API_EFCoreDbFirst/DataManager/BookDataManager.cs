using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class BookDataManager: IService<Book>
    {
        readonly BookStoreContext _db;

        public BookDataManager(BookStoreContext storeContext) { 
            _db = storeContext;
        }

        public async Task<Book?> Get(long id)
        {
            var book = _db.Books
                .SingleOrDefault(x => x.Id == id);

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

        public async Task<IEnumerable<Book>?> GetAll()
        {
            try 
            { 
                return await _db.Books
                    .ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book> Add(Book entity)
        {
            try
            {
                await _db.Books.AddAsync(entity);
                await _db.SaveChangesAsync();

                return await _db.Books.FindAsync(entity.Id); 
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Book?> Update(Book entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<(bool, string)> Delete(long id)
        {
            try
            {
                var book = await _db.Books.FindAsync(id);

                if (book == null)
                    return (false, "Il libro non può essere trovato.");

                _db.Books.Remove(book);

                _db.Entry(book).State = EntityState.Deleted;
                await _db.SaveChangesAsync();

                return (true, $"Il libro {book.Title} è stato cancellato.");
            }
            catch (Exception ex)
            {
                return (false, $"Si è verificato un errore. -> {ex.Message}");
            }
        }

    }
}
