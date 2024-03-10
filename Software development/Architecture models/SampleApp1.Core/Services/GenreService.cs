using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Projections.Genres;
using SampleApp1.Data.Models;
using SampleApp1.Data.Repositories;
using SampleApp1.Data.Sorting;
using System.Linq.Expressions;

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
                this.GetGeneralInfoProjection(),
                new[] { nameOrderClause });
        }

        public IEnumerable<GenreMinifiedProjection> GetAllMinified()
        {
            var nameOrderClause = new OrderClause<Genre> { Expression = g => g.Name };
            return this.Repository.GetMany(
                _ => true,
                this.GetMinifiedProjection(),
                new[] { nameOrderClause });
        }

        public GenreGeneralInfoProjection? GetOne(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                this.GetGeneralInfoProjection());
        }

        public GenreMinifiedProjection? GetOneMinified(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                this.GetMinifiedProjection());
        }

        public GenreEditProjection? GetOneEdit(Guid id)
        {
            return this.Repository.Get(
                g => g.Id == id,
                g => new GenreEditProjection
                {
                    Id = g.Id,
                    Name = g.Name
                });
        }

        private Expression<Func<Genre, GenreGeneralInfoProjection>> GetGeneralInfoProjection()
        {
            return g => new GenreGeneralInfoProjection
            {
                Id = g.Id,
                Name = g.Name,
                ArtistsCount = g.Songs.Select(s => s.ArtistId).Distinct().LongCount(),
                SongsCount = g.Songs.LongCount()
            };
        }

        private Expression<Func<Genre, GenreMinifiedProjection>> GetMinifiedProjection()
        {
            return g => new GenreMinifiedProjection
            {
                Id = g.Id,
                Name = g.Name,
            };
        }
    }
}
