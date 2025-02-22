using AutoMapper;
using PersonalOrganizer.Core.Prototypes;
using PersonalOrganizer.Data.Models;
using PersonalOrganizer.MVC.Models.TaskItems;

namespace PersonalOrganizer.MVC.Profiles;

public class TaskItemProfile : Profile
{
    public TaskItemProfile()
    {
        this.CreateMap<TaskItem, TaskItemViewModel>();
        this.CreateMap<TaskItem, TaskItemInputModel>()
            .ForMember(im => im.LabelIds, conf => conf.MapFrom(ti => ti.Labels.Select(l => l.Id)));

        this.CreateMap<TaskItemInputModel, TaskItemPrototype>();
    }
}
