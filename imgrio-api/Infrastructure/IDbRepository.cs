using imgrio_api.Entities;

namespace imgrio_api.Infrastructure;

public interface IDbRepository<TEntity> where TEntity : IEntity
{
    public Task<TEntity?> GetSingle(Guid id);

    public Task<IEnumerable<TEntity>> GetAll();

    public Task<IEnumerable<TEntity>> GetAll(Guid authorId);

    public Task<TEntity> Create(TEntity entity);

    public Task<TEntity> Update(TEntity entity);

    public Task Delete(TEntity entity);
}