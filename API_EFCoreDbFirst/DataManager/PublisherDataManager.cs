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

        public async Task Add(Publisher entity)
        {
            _bookStoreContext.Add(entity);
            await _bookStoreContext.SaveChangesAsync();
        }

        public async Task Delete(Publisher entity)
        {
            _bookStoreContext.Remove(entity);
            await _bookStoreContext.SaveChangesAsync();
        }

        public Task Delete(Task<Publisher> publisher)
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher> Get(long id)
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

        public Task Update(Publisher entityToUpdate, Publisher entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Task<Author> authorToUpdate, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
