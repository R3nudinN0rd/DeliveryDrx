using DeliveryDrxAPI.Context;
using DeliveryDrxAPI.Entities;
using DeliveryDrxAPI.Repositories.DriverRepositories;
using DeliveryDrxAPI.Repositories.GateRepository;
using DeliveryDrxAPI.Repositories.LocationManagerRepositories;
using DeliveryDrxAPI.Repositories.LocationRepositories;
using DeliveryDrxAPI.Repositories.TransportRepositories;
using DeliveryDrxAPI.Repositories.TransportScheduleRepositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region DatabaseInjection
builder.Services.AddDbContext<DeliveryDrxContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
#endregion
#region Repositories
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IGateRepository, GateRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationManagerRepository, LocationManagerRepository>();
builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped<ITransportScheduleRepository, TransportScheduleRepository>();
#endregion
#region CORS Origins
var AllowOrigins = "AllowOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod(); ;
                      });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
