using SampleApp1.Core.Projections.Artists;
using SampleApp1.Data.Models;

namespace SampleApp1.Core.Interfaces.Services
{
    public interface IArtistService : IService<Artist>
    {
        IEnumerable<ArtistGeneralInfoProjection> GetAll();
        IEnumerable<ArtistMinifiedProjection> GetAllMinified();
    }
}
