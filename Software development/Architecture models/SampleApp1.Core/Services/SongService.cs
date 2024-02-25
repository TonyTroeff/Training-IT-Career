using SampleApp1.Core.Interfaces.Services;
using SampleApp1.Core.Projections.Songs;
using SampleApp1.Data.Models;
using SampleApp1.Data.Repositories;

namespace SampleApp1.Core.Services
{
    public class SongService : BaseService<Song>, ISongService
    {
        public SongService(IRepository<Song> repository)
            : base(repository)
        {
        }

        public IEnumerable<SongGeneralInfoProjection> GetAllSongs()
        {
            return this.Repository.GetMany(_ => true, s => new SongGeneralInfoProjection { Id = s.Id, Name = s.Name, ArtistNickname = s.Artist.Nickname });
        }
    }
}
