using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.MVC.Models.TaskGroups;

namespace PersonalOrganizer.MVC.Profiles;

public class TaskGroupProfile : Profile
{
    public TaskGroupProfile()
    {
        this.CreateMap<TaskGroup, TaskGroupViewModel>();
        this.CreateMap<TaskGroup, TaskGroupInputModel>();
        this.CreateMap<TaskGroup, SelectListItem>()
            .ForMember(sli => sli.Text, conf => conf.MapFrom(tg => tg.Name))
            .ForMember(sli => sli.Value, conf => conf.MapFrom(tg => tg.Id));
        
        this.CreateMap<TaskGroupInputModel, TaskGroupPrototype>();
    }
}
