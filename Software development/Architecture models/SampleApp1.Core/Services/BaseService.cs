using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Data.Repositories;

namespace SampleApp1.Core.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class
    {
        protected BaseService(IRepository<TEntity> repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected IRepository<TEntity> Repository { get; }

        public bool Create(TEntity entity)
        {
            if (!this.IsValid(entity)) return false;

            this.Repository.Create(entity);
            return true;
        }

        protected virtual bool IsValid(TEntity entity) => true;
    }
}
