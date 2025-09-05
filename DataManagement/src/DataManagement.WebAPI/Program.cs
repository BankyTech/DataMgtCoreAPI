using DataManagement.Business;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;
using DataManagement.Repository;
using DataManagement.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
	{
		Title = "DataManagement API",
		Version = "v1",
		Description = "REST API for managing users, customers, and products"
	});
	var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
	if (System.IO.File.Exists(xmlPath))
	{
		c.IncludeXmlComments(xmlPath);
	}
});

// DI registrations (previously in Startup)
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services.AddTransient<IRepository<Product>, ProductRepository>();

var app = builder.Build();

// Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "DataManagement API v1");
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
