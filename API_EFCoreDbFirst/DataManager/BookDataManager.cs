using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using API_EFCoreDbFirst.DTOs;
using API_EFCoreDbFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API_EFCoreDbFirst.Utilities.MapToDto;

namespace API_EFCoreDbFirst.DataManager
{
    public class BookDataManager: IService<Book, BookDetailDto>
    {
        readonly BookStoreContext _db;

        public BookDataManager(BookStoreContext storeContext) { 
            _db = storeContext;
        }

        //public async Task<Book?> GetById(long id)
        //{
        //    var dbBook = _db.Books vnb
        //        //.Include(a => a.Authors)
        //        .Include(c=> c.Category)
        //        .Include(p => p.Publisher)
        //        .Include(p => p.Authors)

        //        .SingleOrDefault(book=> book.Id == id);

        //    if (dbBook == null)
        //        return null;

        //    return dbBook;
        //}

        //public async Task<Book?> GetById(long id)
        //{
        //    var book = _db.Books.Include(b => b.Authors).Select(b => new BookDetailDto()
        //    {
        //        Id = b.Id,
        //        Title = b.Title,
        //        AuthorName = b.Authors.First().Name,
        //    })
        //   .SingleOrDefault(b => b.Id == id);

        //    //var dbBook = _db.Books
        //    //    //.Include(b => b.BookAuthors)
        //    //    .Include(p => p.Publisher)
        //    //    .SingleOrDefault(book => book.Id == id);


        //    //var book = await _db.Books.Include(b => b.Authors).Select(b =>
        //    //new BookDetailDto()
        //    //{
        //    //    Id = b.Id,
        //    //    Title = b.Title,
        //    //    AuthorName = b.Authors.FirstOrDefault().Name,
        //    //    Publisher = b.Publisher.Name
        //    //}).SingleOrDefaultAsync(b => b.Id == id);

        //    return book;

        //}

        public async Task<Book?> GetById(long id)
        {
            var dbBook = _db.Books
                //.Include(b => b.BookAuthors)
                .Include(p => p.Publisher)
                .SingleOrDefault(book => book.Id == id);

            if (dbBook == null)
                return null;

            return dbBook;
        }

     

        public async Task<IEnumerable<Book>?> GetAll()
        {
            try
            {
                return _db.Books
                    //.Include(b=> b.BookAuthors)
                    .Include(p => p.Publisher)
                    .ToList();
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

        public async Task<Book?> Update(long id, Book entityToUpdate)
        {
            try
            {
                _db.Entry(entityToUpdate).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return entityToUpdate;
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

        public async Task<BookDetailDto> GetDetailsDto(long id)
        {
            _db.ChangeTracker.LazyLoadingEnabled = true;

            var author = _db.Authors
                .SingleOrDefault(b => b.Id == id);

            var book = _db.Books
                .Include(c => c.Category)
                .Include(x => x.Publisher)
                .SingleOrDefault(b => b.Id == id);


            // var book = _db.Books
            //     .Include(c=> c.Category)
            //     .Include(x=> x.Publisher)
            //     .Select(b => new BookDetailDto()
            // {
            //     Id = b.Id,
            //     Title = b.Title,
            //     AuthorName = author.Name ?? "Autore NoN presente",
            //     Category = b.Category.Name,
            //     Publisher = b.Publisher.Name
            // })
            //.SingleOrDefault(b => b.Id == id);
            // return book;

            return BookMapperDto.MapBookToDto(book, author);
        }
    }
}
