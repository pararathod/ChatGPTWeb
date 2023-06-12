using OpenAI.GPT3.Extensions;

using ChatGPTAPI.Data;
using Microsoft.EntityFrameworkCore;
using ChatGPTAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
      "appsettings.json", optional: true, reloadOnChange: true
  ).AddEnvironmentVariables();
//builder.Services.Add;
builder.Services.AddDbContext<DbContextClass>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ChatGPTContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Configuration.AddJsonFile(
        "appsettings.json", optional: true, reloadOnChange: true
    ).AddEnvironmentVariables();
builder.Services.AddOpenAIService();

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
