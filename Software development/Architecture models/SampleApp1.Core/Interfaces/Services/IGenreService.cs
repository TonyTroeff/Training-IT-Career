using SampleApp1.Core.Projections.Genres;
using SampleApp1.Data.Models;

namespace SampleApp1.Core.Interfaces.Services
{
    public interface IGenreService : IService<Genre>
    {
        IEnumerable<GenreGeneralInfoProjection> GetAll();
        GenreGeneralInfoProjection? GetOne(Guid id);

        IEnumerable<GenreMinifiedProjection> GetAllMinified();
        GenreMinifiedProjection? GetOneMinified(Guid id);

        GenreEditProjection? GetOneEdit(Guid id);
    }
}
