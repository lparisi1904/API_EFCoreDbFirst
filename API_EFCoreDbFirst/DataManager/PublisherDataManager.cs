using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;

namespace API_EFCoreDbFirst.DataManager
{
    public class PublisherDataManager : IDataRepository<Publisher, PublisherDto>
    {
        readonly BookStoreContext _bookStoreContext;

        public PublisherDataManager(BookStoreContext context) { 
            _bookStoreContext= context;
        }

        public Task Add(Publisher entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Publisher entity)
        {
            _bookStoreContext.Remove(entity);
            await _bookStoreContext.SaveChangesAsync();
        }

        public Task<Publisher> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Publisher>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PublisherDto> GetDto(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Publisher entity)
        {
            throw new NotImplementedException();
        }
    }
}
