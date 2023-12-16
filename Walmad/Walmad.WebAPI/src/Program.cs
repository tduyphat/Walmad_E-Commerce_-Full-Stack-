using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.WebAPI.src.Database;
using Walmad.WebAPI.src.Middleware;
using Walmad.WebAPI.src.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// declare Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// error handler middleware
builder.Services.AddTransient<ExceptionHandlerMiddleware>();

// add automapper dependency injection
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

//Add database context service
builder.Services.AddDbContext<DatabaseContext>();

// config authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    });

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
