using AutoMapper;
using SampleApp1.Core.Projections.Artists;
using SampleApp1.Web.ViewModels.Artists;

namespace SampleApp1.Web.MVC.Mapping
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            this.CreateMap<ArtistMinifiedProjection, ArtistMinifiedViewModel>();
        }
    }
}
