using CsvToJsonDemo.Data;
using CsvToJsonDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Register EF Core with in-memory DB (or switch to SQL Server/Postgres/etc.)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EmployeesDb"));

// Register services
builder.Services.AddScoped<CsvHelperService>();

// Add OpenAPI/Swagger with NSwag
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "CSV Import API";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(config =>
    {
        config.DocumentPath = "/swagger/v1/swagger.json";
        config.Path = "/swagger";
    });
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
