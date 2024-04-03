using AutoMapper;
using CvManagerApp.Core.Models;
using CvManagerApp.Dtos;

namespace CvManagerApp.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CvInputModel, Cv>();
        CreateMap<EducationInputModel, Education>();
        CreateMap<WorkExperienceInputModel, WorkExperience>();
        CreateMap<SkillAchievementInputModel, SkillAchievement>();

        CreateMap<Cv, CvViewModel>();
        CreateMap<CvViewModel, Cv>();
        CreateMap<Education, EducationViewModel>();
        CreateMap<EducationViewModel, Education>();
        CreateMap<WorkExperience, WorkExperienceViewModel>();
        CreateMap<WorkExperienceViewModel, WorkExperience>();
        CreateMap<SkillAchievement, SkillAchievementViewModel>();
        CreateMap<SkillAchievementViewModel, SkillAchievement>();
    }
}