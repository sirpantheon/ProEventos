using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

public class Startup
{
    public Startup(IConfiguration configuration){
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
        => services.AddDbContext<DataContext>(
            context => context.UseSqlite(Configuration.GetConnectionString("Default"))
        );

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
