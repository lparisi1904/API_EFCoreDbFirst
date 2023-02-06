using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class AuthorDataManager : IDataRepository<Author, AuthorDto>
    {
        readonly BookStoreContext _bookStoreContext;

        public AuthorDataManager(BookStoreContext storeContext)
        {
            _bookStoreContext= storeContext;
        }
            

        public async Task Add(Author entity)
        {
            _bookStoreContext.Authors.AddAsync(entity);
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task Delete(Author entity)
        {
            _bookStoreContext.Authors.Remove(entity);
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task<Author> Get(long id)
        {
            var author = _bookStoreContext.Authors
               .FirstOrDefaultAsync(b => b.Id == id);

            return await author;
        }

        public async Task<List<Author>> GetAll()
        {
            return await _bookStoreContext.Authors
                .Include(a=> a.AuthorContact)
                .ToListAsync();
        }

        public async Task<AuthorDto> GetDto(long id)
        {
            _bookStoreContext.ChangeTracker.LazyLoadingEnabled = true;

            var context = new BookStoreContext();

            var author = context.Authors
                .SingleOrDefaultAsync(b => b.Id == id);

            return AuthorDtoMapper.MapToDto(await author);
        }

        public Task Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
