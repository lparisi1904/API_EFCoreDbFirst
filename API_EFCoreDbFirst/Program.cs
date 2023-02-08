using API_EFCoreDbFirst.DataManager;
using API_EFCoreDbFirst.Dto;
using API_EFCoreDbFirst.Models;
using API_EFCoreDbFirst.Repository;
using Microsoft.EntityFrameworkCore;


#region builder

var builder = WebApplication.CreateBuilder(args);

// AddAsync services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnStr");
builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDataRepository<Author>,AuthorDataManager>();
builder.Services.AddScoped<IDataRepository<Book>,BookDataManager>();
builder.Services.AddScoped<IDataRepository<Publisher>,PublisherDataManager>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#endregion


#region app
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
