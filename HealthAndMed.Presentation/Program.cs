using AtivosTC5.Infra.Data.Contexts;
using AtivosTC5.Services.Extensions;
using HealthAndMed.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using static HealthAndMed.Infra.Messages.Consumers.ConsultaMessageConsumer;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TechChallengeConection");

builder.Services.AddDbContext<SqlServerContext>(
    o => o.UseSqlServer(connectionString)
    );

// Add services to the container.

builder.Services.AddRouting(map => map.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();
builder.Services.AddDependencyInjection();
builder.Services.AddJwtBearer();
builder.Services.AddHostedService<UsuarioMessageConsumer>();
builder.Services.AddCorsPolicy();
builder.Services.AddMvc();

var app = builder.Build();

app.UseSwaggerDoc();
app.UseCorsPolicy();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program()
{

}
