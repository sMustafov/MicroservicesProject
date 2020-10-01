namespace CustomerApi.Data.Repository
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly CustomerContext customerContext;

        public Repository(CustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return this.customerContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Cannot retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await this.customerContext.AddAsync(entity);
                await this.customerContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
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
                this.customerContext.Update(entity);
                
                await this.customerContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }
    }
}
