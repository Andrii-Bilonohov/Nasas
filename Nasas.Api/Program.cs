using Microsoft.EntityFrameworkCore;
using Nasas.Application.Services;
using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Abstraction.Interfaces.Services;
using Nasas.Infrastructure.Data;
using Nasas.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NasasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IScientistService, ScientistService>();
builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<IScientistRepository, ScientistRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});




var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
