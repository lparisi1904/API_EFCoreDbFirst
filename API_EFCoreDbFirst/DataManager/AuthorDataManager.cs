using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_EFCoreDbFirst.DataManager
{
    public class AuthorDataManager : IService<Author>
    {
        readonly BookStoreContext _db;

        public AuthorDataManager(BookStoreContext storeContext)
        {
            _db = storeContext;
        }

        public async Task<Author?> Get(long id)
        {
            try
            {
                var author = _db.Authors
                    .Include(c => c.AuthorContact)
                    .SingleOrDefault(b => b.Id == id);

                return author;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Author>?> GetAll()
        {
            try
            {
                return  _db.Authors
                        //.Include(c => c.AuthorContact)
                        .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Author?> Add(Author author)
        {
            try { 
                await _db.Authors.AddAsync(author);
                await _db.SaveChangesAsync();

                return await _db.Authors.FindAsync(author.Id);
            }
            catch (Exception) {
                return null;
            }
        }
        public async Task<Author?> Update(long id, Author entityToUpdate)
        {
            Author entity = _db.Authors
              //.Include(a => a.BookAuthors)
              .Include(a => a.AuthorContact)
              .Single(b => b.Id == id);

            if (entity == null || entity.Id != id)
                return null; 

            try {

                entity.Name = entityToUpdate.Name;
                entity.AuthorContact.Address = entityToUpdate.AuthorContact.Address;
                entity.AuthorContact.ContactNumber = entityToUpdate.AuthorContact.ContactNumber;


                _db.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return entity;
            }
            catch (Exception) {
                return null;
            }
        }


        public async Task<(bool, string)> Delete(long id)
        {
            try
            {
                var author = await _db.Authors.FindAsync(id);

                if (author == null)
                    return (false, "Autore non presente.");

                _db.Authors.Remove(author);
                _db.Entry(author).State = EntityState.Deleted;

                await _db.SaveChangesAsync();

                return (true, "L'autore è stato cancellato.");
            }
            catch (Exception ex)
            {
                return (false, $"Si è verificato un errore. ->  {ex.Message}");
            }
        }
    }
}
