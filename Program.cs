using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeacherPortal;
using TeacherPortal.Interfaces;
using TeacherPortal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TeacherPortalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TeacherPortalDbContext")));

var authenticationSettings = new AuthenticationSetting();

builder.Configuration.GetSection("Authentication");

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
