using SampleApp1.Core.Projections.Songs;
using SampleApp1.Data.Models;

namespace SampleApp1.Core.Interfaces.Services
{
    public interface ISongService : IService<Song>
    {
        IEnumerable<SongGeneralInfoProjection> GetAll();

        SongMinifiedProjection? GetOneMinified(Guid id);
    }
}
