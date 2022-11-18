using Microsoft.EntityFrameworkCore;
using Steeltoe.Management.Endpoint;
using Steeltoe.Management.Tracing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<API.Domain.TodoDbContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.AddAllActuators();
builder.Services.AddDistributedTracingAspNetCore();

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<API.Domain.TodoDbContext>();
await dbContext.Database.EnsureCreatedAsync();

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
