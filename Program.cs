using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using simple.Data;
var url = Environment.GetEnvironmentVariable("DATABASE_PUBLIC_URL");
Console.WriteLine($"la cadena es :{url}");
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<simpleContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("simpleContext") ?? throw new InvalidOperationException("Connection string 'simpleContext' not found.")));

// Add services to the container.
builder.WebHost.UseUrls("http://0.0.0.0:8080");

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
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<simpleContext>();
    context.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
