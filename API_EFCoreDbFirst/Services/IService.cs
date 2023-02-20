//using API_EFCoreDbFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_EFCoreDbFirst.Repository
{
    public interface IService<TEntity, TDto>
    {
        /// <summary>
        /// add a new interface named IService 
        /// </summary>
        /// <param name="xx">...</param>
        /// <returns></returns>
        /// 

        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(long id, TEntity entity);
        Task<(bool, string)> Delete(long id);
        Task<TEntity> GetById(long id);
        Task<TDto> GetDetailsDto(long id);
    }
}