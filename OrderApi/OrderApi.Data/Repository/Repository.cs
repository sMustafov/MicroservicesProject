namespace OrderApi.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using OrderApi.Data.Database;
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly OrderContext orderContext;
        public Repository(OrderContext orderContext)
        {
            this.orderContext = orderContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await this.orderContext.AddAsync(entity);
                await this.orderContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved!");
            }
        }
        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return this.orderContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Cannot retrieve entities!");
            }
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                this.orderContext.Update(entity);

                await this.orderContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }
        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entities must not be null");
            }

            try
            {
                this.orderContext.UpdateRange(entities);

                await this.orderContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entities)} could not be updated");
            }
        }
    }
}
