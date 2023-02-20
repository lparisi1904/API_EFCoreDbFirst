using API_EFCoreDbFirst.DTOs;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class PublisherDataManager : IService<Publisher, PublisherDto>
    {
        readonly BookStoreContext _db;

        public PublisherDataManager(BookStoreContext context) { 
            _db= context;
        }

        public async Task<IEnumerable<Publisher>> GetAll()
        {
            return await _db.Publishers
                    .ToListAsync();
        }

        public async Task<Publisher?> GetById(long id)
        {
            try
            {
                return await _db.Publishers
                    .SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Publisher?> Add(Publisher entity)
        {
            try
            {
                await _db.Publishers.AddAsync(entity);
                await _db.SaveChangesAsync();

                return await _db.Publishers.FindAsync(entity.Id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Publisher?> Update(long id, [FromBody] Publisher entityToUpdate)
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
                var dbPublisher = await _db.Publishers.FindAsync(id);

                if (dbPublisher == null)
                {
                    return (false, "Editore non trovato");
                }

                _db.Publishers.Remove(dbPublisher);
                await _db.SaveChangesAsync();

                return (true, "Editore cancellato.");
            }
            catch (Exception ex)
            {
                return (false, $"Si è verificato un errore. -> {ex.Message}");
            }
        }

        public Task<PublisherDto> GetDetailsDto(long id)
        {
            throw new NotImplementedException();
        }
    }
}
