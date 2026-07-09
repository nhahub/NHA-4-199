using FluentValidation;
using FluentValidation.AspNetCore;
using HRManagementSystem.BLL.BusinessRules;
using HRManagementSystem.BLL.BusinessRules.Interfaces;
using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.BLL.Services;
using HRManagementSystem.BLL.Validators;
using HRManagementSystem.DAL.Context;
using HRManagementSystem.DAL.Repositories;
using HRManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HRDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDepartmentBusinessRules, DepartmentBusinessRules>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services
    .AddControllersWithViews()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateDepartmentValidator>();
    });

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IPersonBusinessRules, PersonBusinessRules>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ICandidateBusinessRules, CandidateBusinessRules>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

builder.Services.AddScoped<IApplicationBusinessRules, ApplicationBusinessRules>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

builder.Services.AddScoped<IJobRequisitionBusinessRules, JobRequisitionBusinessRules>();
builder.Services.AddScoped<IJobRequisitionService, JobRequisitionService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
//smnld