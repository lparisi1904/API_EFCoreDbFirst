using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class AuthorDataManager : IDataRepository<Author >
    {
        readonly BookStoreContext _db;

        public AuthorDataManager(BookStoreContext storeContext)
        {
            _db= storeContext;
        }
            

        public async Task AddAsync(Author entity)
        {
            await _db.Authors.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author entity)
        {
            _db.Authors.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public Task DeleteAsync(Task<Publisher> publisher)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetAsync(long id)
        {
            var author = _db.Authors
               .FirstOrDefaultAsync(b => b.Id == id);

            return await author;

        }

        public async Task<List<Author>> GetAll()
        {
            return await _db.Authors
                .Include(a => a.AuthorContact)
                .ToListAsync();
        }

        public async Task<AuthorDTO> GetDto(long id)
        {
            var context = new BookStoreContext();

            var author = context.Authors
                .SingleOrDefaultAsync(b => b.Id == id);

            return AuthorMapperDTO.MapAuthorToDTO(await author);
        }

        public Task Update(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Author entityToUpdate, Author entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Task<Author> authorToUpdate, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
