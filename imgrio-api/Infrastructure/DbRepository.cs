using imgrio_api.Data;
using imgrio_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace imgrio_api.Infrastructure
{
    public class DbRepository<TEntity> : IDbRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ImgrioDbContext _dbContext;

        public DbRepository(ImgrioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity?> GetSingle(Guid id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAll(Guid authorId)
        {
            var entities = await _dbContext.Set<TEntity>().Where(x => x.AuthorId == authorId).ToListAsync();

            return entities;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(TEntity entity)
        {
             _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
