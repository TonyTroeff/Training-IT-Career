using AutoMapper;
using SampleApp1.Core.Projections.Genres;
using SampleApp1.Data.Models;
using SampleApp1.Web.ViewModels.Genres;

namespace SampleApp1.Web.MVC.Mapping
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            this.CreateMap<GenreGeneralInfoProjection, GenreViewModel>();
            this.CreateMap<GenreMinifiedProjection, GenreMinifiedViewModel>();
            this.CreateMap<GenreCreateModel, Genre>();
            this.CreateMap<GenreEditProjection, GenreEditModel>();
        }
    }
}
