using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class PublisherDataManager : IDataRepository<Publisher>
    {
        readonly BookStoreContext _db;

        public PublisherDataManager(BookStoreContext context) { 
            _db= context;
        }

        public async Task AddAsync(Publisher entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Publisher entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public Task DeleteAsync(Task<Publisher> publisher)
        {
            throw new NotImplementedException();
        }

        public async Task<Publisher> GetAsync(long id)
        {
            return await _db.Publishers
              .Include(a => a.Books)
              .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Publisher>> GetAll()
        {
            return await _db.Publishers
                .Include(a => a.Books)
                .ToListAsync();
        }

        public Task<PublisherDTO> GetDto(long id)
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
