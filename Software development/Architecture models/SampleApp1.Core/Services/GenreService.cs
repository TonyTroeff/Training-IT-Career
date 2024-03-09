using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Projections.Genres;
using SampleApp1.Data.Models;
using SampleApp1.Data.Repositories;
using SampleApp1.Data.Sorting;

namespace SampleApp1.Core.Services
{
    public class GenreService : BaseService<Genre>, IGenreService
    {
        public GenreService(IRepository<Genre> repository)
            : base(repository)
        {
        }

        public IEnumerable<GenreGeneralInfoProjection> GetAll()
        {
            var nameOrderClause = new OrderClause<Genre> { Expression = g => g.Name };
            return this.Repository.GetMany(
                _ => true,
                g => new GenreGeneralInfoProjection { Id = g.Id, Name = g.Name },
                new[] { nameOrderClause });
        }

        public GenreGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                g => new GenreGeneralInfoProjection { Id = g.Id, Name = g.Name });
        }
    }
}
