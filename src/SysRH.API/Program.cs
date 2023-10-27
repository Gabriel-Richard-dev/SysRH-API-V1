using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SysRH.Domain.Entities;
using SysRH.Infra.Context;
using SysRH.Infra.Interfaces;
using SysRH.Infra.Repositories;
using SysRH.Services.DTO;
using SysRH.Services.Interfaces;
using SysRH.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AutoMapperDependenceInjection();

void AutoMapperDependenceInjection()
{
    var automapperconfig = new MapperConfiguration(cfg => { cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap(); });
    builder.Services.AddSingleton(automapperconfig.CreateMapper());
}

builder.Services.AddSingleton(d => builder.Configuration);
var stringconection = builder.Configuration.GetConnectionString("DEFAULT");
builder.Services.AddDbContext<SysRHContext>(options =>
    options.UseMySql(stringconection, ServerVersion.AutoDetect(stringconection)));


builder.Services.AddScoped<IEmployeeServiceInterface, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();