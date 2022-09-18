using AutoTrainerDB;
using AutoTrainerServices.Services.Services;
using AutoTrainerServices.Services.Servises;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GYMApp", Version = "v1" });
   
});
builder.Services.AddDbContext<ContextDB>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutoTrainerDB;Trusted_Connection=true"));

builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<IClientExerciseService, ClientExerciseService>();

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
