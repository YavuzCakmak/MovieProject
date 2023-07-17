using MicroGroup.Api.Middlewares;
using MicroGroup.Business.DependencyContainer;
using MicroGroup.Core.Sieve;
using MicroGroup.Core.Utilities;
using MicroGroup.Data.Context;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<SieveOptions>(builder.Configuration.GetSection("Sieve"));
builder.Services.AddScoped<BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm>>();

builder.Services.AddDbContext<MicroGroupDbContext>(options =>
options.UseMySQL(
builder.Configuration.GetConnectionString("MySQL")!)
);

builder.Services.AddContainerServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();

app.UseRouting();

app.UseCustomAuthMiddleware();

app.MapControllers();

app.Run();
