using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Projections.Artists;
using SampleApp1.Core.Projections.Songs;
using SampleApp1.Data.Models;
using SampleApp1.Data.Repositories;
using SampleApp1.Data.Sorting;

namespace SampleApp1.Core.Services
{
    public class ArtistService : BaseService<Artist>, IArtistService
    {
        public ArtistService(IRepository<Artist> repository)
            : base(repository)
        {
        }

        public IEnumerable<ArtistGeneralInfoProjection> GetAll()
        {
            var nicknameOrderClause = new OrderClause<Artist> { Expression = a => a.Nickname };

            return this.Repository.GetMany(
                _ => true,
                a => new ArtistGeneralInfoProjection
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Nickname = a.Nickname,
                    Songs = a.Songs
                        .Select(s => new SongMinifiedProjection
                        {
                            Id = s.Id,
                            Name = s.Name
                        })
                        .OrderBy(s => s.Name)
                        .ToArray()
                },
                new[] { nicknameOrderClause });
        }

        public IEnumerable<ArtistMinifiedProjection> GetAllMinified()
        {
            var nicknameOrderClause = new OrderClause<Artist> { Expression = a => a.Nickname };

            return this.Repository.GetMany(
                _ => true,
                a => new ArtistMinifiedProjection
                {
                    Id = a.Id,
                    Nickname = a.Nickname
                },
                new[] { nicknameOrderClause });
        }
    }
}
