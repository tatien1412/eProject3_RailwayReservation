using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IRepository<Station>, StationRepository>();
builder.Services.AddScoped<IRepository<Train>, TrainRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
