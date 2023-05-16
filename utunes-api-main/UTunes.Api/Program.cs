using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UTunes.Core.Entities;
using UTunes.Core.Interfaces;
using UTunes.Core.Services;
using UTunes.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
var allowAllOriginsPolicy = "_allowAllOriginsPolicy";


// Add services to the container.

builder.Services.AddDbContext<UTunesContext>(options => options.UseSqlite("DataSource=UTunes.db"));
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllOriginsPolicy,
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});
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

app.UseCors(allowAllOriginsPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

