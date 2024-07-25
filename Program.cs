using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FacturacionHogar.Infraestructure.Context;
using FacturacionHogar.Infraestructure.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

builder.Services.RegisterApplicationServices();
builder.Services.RegisterRepositories();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Facturacion",
        Version = "v1",
        Description = "Prueba de descripcion",
        Contact = new OpenApiContact
        {
            Name = "cesar luis reyes lopez",
            Email = "cesarlu-12@hotmail.com",
            Url = new Uri("https://github.com/Khesartt")
        }
    });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
}));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200", "http://localhost:9095")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Facturacion"));
app.UseCors("AllowOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
