using CvManagerApp.Core.Services;
using CvManagerApp.Data;
using CvManagerApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CvManagerApp.Data.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CvManagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CvManager")));

builder.Services.AddTransient(typeof(IEntityService<>), typeof(EntityService<>));
builder.Services.AddTransient<IEducationService>(sp =>
    new EducationService(sp.GetRequiredService<CvManagerDbContext>()));
builder.Services.AddTransient<IWorkExperienceService>(sp =>
    new WorkExperienceService(sp.GetRequiredService<CvManagerDbContext>()));
builder.Services.AddTransient<ISkillAchievementService>(sp =>
    new SkillAchievementService(sp.GetRequiredService<CvManagerDbContext>()));
builder.Services.AddTransient<ICvService, CvService>
    (sp => new CvService(sp.GetRequiredService<CvManagerDbContext>()));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CvManagerDbContext>();
    context.Database.Migrate();
    SeedData.Seed(context);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cv}/{action=Home}/{id?}");

app.Run();