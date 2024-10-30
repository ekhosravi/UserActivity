using Microsoft.EntityFrameworkCore;
using UserActivityAPI.Data;
using UserActivityAPI.Services;
using UserActivityAPI.Services.IServices;
using UserActivityAPI.UserActivityMapper;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddAutoMapper(typeof(UserActivityMappings));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("UserActivityOpenAPISpec",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "UserActivityAPI",
            Version = "1"
        });
});

var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("swagger/UserActivityOpenAPISpec/swagger.json", "UserActivityAPI");
        options.RoutePrefix = "";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
