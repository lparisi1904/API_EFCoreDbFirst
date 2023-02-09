using API_EFCoreDbFirst.Models;

namespace API_EFCoreDbFirst.Repository
{
    public interface IService<TEntity>
    {
        /// <summary>
        /// add a new interface named IService 
        /// </summary>
        /// <param name="xx">...</param>
        /// <returns></returns>
        /// 

        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<(bool, string)> Delete(long id);
    }
}