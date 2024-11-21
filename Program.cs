using GeekyMon2.Tasker.Common;
using GeekyMon2.Tasker.DB;
using GeekyMon2.Tasker.Exception;
using GeekyMon2.Tasker.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddControllers(options => { options.Filters.Add(new ExceptionFilter()); });
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(O => O.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var logger = app.Logger;
var version = VersionHelper.GetBuildVersion();
logger.LogInformation("Application Build Version: {Version}", version);

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
