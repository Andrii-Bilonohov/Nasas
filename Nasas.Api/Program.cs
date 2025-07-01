using Nasas.Application.Services;
using Nasas.Domain.Abstraction.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddScoped<IPlanetService, PlanetService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
