namespace SampleApp1.Core.Interfaces.Services
{
    public interface IService<TEntity>
        where TEntity : class
    {
        bool Create(TEntity entity);
    }
}
