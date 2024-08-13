using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PatientWebAPI.Data;
using PatientWebAPI.Extentions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.AddProfiles();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    var xmlPath = Path.Combine(basePath, "PatientWebAPI.xml");
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddScopped();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers().AddOData(x => x.Select().Filter());

var app = builder.Build();

app.UseSwagger();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = String.Empty;
});

app.UseAuthorization();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<DataContext>();
context?.Database.Migrate();

app.MapControllers();

app.Run();
