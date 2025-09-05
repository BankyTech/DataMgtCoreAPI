using DataManagement.Business;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using DataManagement.Repository;
using DataManagement.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// DI registrations (previously in Startup)
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services.AddTransient<IRepository<Product>, ProductRepository>();

var app = builder.Build();

// if needed, add Swagger via Swashbuckle.AspNetCore package and enable here

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
