namespace API_EFCoreDbFirst.Repository
{
    public interface IDataRepository<TEntity, TDto>
    {
        Task<List<TEntity>> GetAll();
        //IEnumerable<TEntity> GetAll();
        Task<TEntity> Get(long id);
        Task<TDto> GetDto(long id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete2(TEntity entity);
    }
}
