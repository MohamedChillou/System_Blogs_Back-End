using Back_Blogs.ConfigSecurity;
using Back_Blogs.Data;
using Back_Blogs.Models;
using Back_Blogs.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("key"));
    op.UseLazyLoadingProxies();
});
builder.Services.AddScoped<IServiceBlog,ServiceBlog>();
builder.Services.AddScoped<IServiceUser, ServiceUser>();
builder.Services.AddScoped<IServiceCategory, ServiceCategory>();
builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddCustomJwt(builder.Configuration);
builder.Services.AddCors( op =>
    op.AddPolicy("AllowSpecificOrigin",builder =>
    {
        builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    })
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
