using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class PublisherDataManager : IDataRepository<Publisher, PublisherDto>
    {
        readonly BookStoreContext _bookStoreContext;

        public PublisherDataManager(BookStoreContext context) { 
            _bookStoreContext= context;
        }

        public async Task AddAsync(Publisher entity)
        {
            _bookStoreContext.Add(entity);
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Publisher entity)
        {
            _bookStoreContext.Remove(entity);
            await _bookStoreContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Task<Publisher> publisher)
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher> GetAsync(long id)
        {
            return await _bookStoreContext.Publishers
              .Include(a => a.Books)
              .SingleAsync(b => b.Id == id);
        }

        public async Task<List<Publisher>> GetAll()
        {
            return await _bookStoreContext.Publishers
                .Include(a => a.Books)
                .ToListAsync();
        }

        public Task<PublisherDto> GetDto(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Publisher entityToUpdate, Publisher entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Task<Author> authorToUpdate, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
