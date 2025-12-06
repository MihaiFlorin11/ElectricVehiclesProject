using Mappers;
using Data.Context;
using Data.Settings;
using MediatR;
using System.Reflection;
using CQRS.VehicleQueries;
using API.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

Extension.Services(builder.Services);

builder.Services.AddAutoMapper(typeof(Profiles).Assembly);

builder.Services.AddMediatR(typeof(GetVehiclesQueryHandler).GetTypeInfo().Assembly);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAnyOrigin",
    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseCors("AllowAnyOrigin");

app.Run();