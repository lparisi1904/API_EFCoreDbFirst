using API_EFCoreDbFirst.DataManager;
using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;


#region builder

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

// Register Library Service to use it with Dependency Injection in Controllers
builder.Services.AddScoped<IService<Author>, AuthorDataManager>();
builder.Services.AddScoped<IService<Book>, BookDataManager>();
builder.Services.AddScoped<IService<Publisher>, PublisherDataManager>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion


#region app

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

#endregion
