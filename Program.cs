using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using CodeChallenge.Api.Logic;
using CodeChallenge.Api.Repositories;
using CodeChallenge.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (!string.IsNullOrEmpty(connectionString))
{
   
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("CodeChallengeDb"));
}


// Dependency injection
builder.Services.AddScoped<IMessageLogic, MessageLogic>();

var useInMemoryRepo = builder.Configuration.GetValue<bool>("UseInMemoryRepository");
if (useInMemoryRepo)
{
    builder.Services.AddScoped<IMessageRepository, InMemoryMessageRepository>();
}
else
{
    builder.Services.AddScoped<IMessageRepository, EfMessageRepository>();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
