using CvManagerApp.Core.Models;

namespace CvManagerApp.Data.SeedData;

public static class SeedData
{
    public static void Seed(CvManagerDbContext context)
    {
        if (context.Cvs.Any())
        {
            return;
        }

        var cv = new Cv
        {
            FirstName = "Jānis",
            LastName = "Bērziņš",
            PhoneNumber = "27123456",
            Email = "jankanavlabi@example.com",
            DateOfBirth = "2000-01-01",
            WorkExperiences = new List<WorkExperience>(),
            Educations = new List<Education>(),
            SkillsAchievements = new List<SkillAchievement>()
        };

        cv.WorkExperiences.Add(new WorkExperience
        {
            Company = "Elteks",
            Position = "elektromontieris",
            StartDate = "2020-01-01",
            EndDate = "2021-12-31"
        });

        cv.WorkExperiences.Add(new WorkExperience
        {
            Company = "AS \"Sadales Tīkls\"",
            Position = "elektromontieris",
            StartDate = "2022-01-01",
            EndDate = "2023-12-31"
        });

        cv.Educations.Add(new Education
        {
            EducationalEstablishment = "Latvijas Universitāte",
            Faculty = "kaut kas",
            StudyProgram = "vēl kaut kas",
            StudyStatus = "Absolvējis"
        });

        cv.SkillsAchievements.Add(new SkillAchievement
        {
            SkillOrAchievement = "ļoti foršs skills"
        });

        cv.SkillsAchievements.Add(new SkillAchievement
        {
            SkillOrAchievement = "vienkārša prasme"
        });

        context.Cvs.Add(cv);
        context.SaveChanges();
    }
}
