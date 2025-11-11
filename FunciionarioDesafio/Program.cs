using FunciionarioDesafio.Data.Context;
using FunciionarioDesafio.Data.Repository;
using FunciionarioDesafio.Data.Repository.Interface;
using FunciionarioDesafio.Service.Service;
using FunciionarioDesafio.Service.Service.Inetrface;
using FunciionarioDesafio.Service.Service.Interface;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FuncionarioDesafioContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")
    ));

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRpository>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IEstatisticaService, EstatisticaService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
