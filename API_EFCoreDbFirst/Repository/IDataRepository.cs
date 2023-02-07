using API_EFCoreDbFirst.Models;

namespace API_EFCoreDbFirst.Repository
{
    public interface IDataRepository<TEntity, TDto>
    {
        /// <summary>
        /// add a new interface named IDataRepository 
        /// </summary>
        /// <param name="xx">...</param>
        /// <returns></returns>
        Task<List<TEntity>> GetAll();
        //IEnumerable<TEntity> GetAll();
        Task<TEntity> GetAsync(long id);
        Task<TDto> GetDto(long id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(Task<Author> authorToUpdate, Author author);
        Task DeleteAsync(Task<Publisher> publisher);
    }
}