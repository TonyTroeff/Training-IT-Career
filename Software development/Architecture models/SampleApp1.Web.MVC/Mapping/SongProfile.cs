using AutoMapper;
using SampleApp1.Core.Projections.Songs;
using SampleApp1.Data.Models;
using SampleApp1.Web.ViewModels.Songs;

namespace SampleApp1.Web.MVC.Mapping
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            this.CreateMap<SongGeneralInfoProjection, SongViewModel>();
            this.CreateMap<SongMinifiedProjection, SongMinifiedViewModel>();
            this.CreateMap<SongCreateModel, Song>()
                .ForMember(x => x.Artist, conf => conf.Ignore())
                .ForMember(x => x.Genres, conf => conf.Ignore());

            this.CreateMap<SongEditProjection, SongEditModel>()
                .ForMember(x => x.Artist, conf => conf.MapFrom(y => y.ArtistId))
                .ForMember(x => x.Genres, conf => conf.MapFrom(y => y.GenreIds));
        }
    }
}
