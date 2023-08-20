using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Sdatcc_v2.Infrastructure;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);
const string allowOrigins = "_allowAllOrigins";
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Carregar a configuração do arquivo appsettings.json
// builder.Configuration.AddJsonFile("appsettings.json");
/*builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));*/
builder.Services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer("Persist Security Info=False;Integrated Security=true;Initial Catalog=sdatccdb;server=(LocalDb)\\MSSQLLocalDB; TrustServerCertificate=true"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddPolicy(allowOrigins, builder =>
	{
		builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();



