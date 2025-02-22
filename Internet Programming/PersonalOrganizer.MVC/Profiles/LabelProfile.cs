using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.MVC.Models.Labels;

namespace PersonalOrganizer.MVC.Profiles;

public class LabelProfile : Profile
{
    public LabelProfile()
    {
        this.CreateMap<Label, LabelViewModel>();
        this.CreateMap<Label, LabelInputModel>();
        this.CreateMap<Label, SelectListItem>()
            .ForMember(sli => sli.Text, conf => conf.MapFrom(tg => tg.Name))
            .ForMember(sli => sli.Value, conf => conf.MapFrom(tg => tg.Id));

        this.CreateMap<LabelInputModel, LabelPrototype>();
    }
}
