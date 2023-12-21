using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Walmad.Business.src;
using Walmad.Business.src.Abstraction;
using Walmad.Business.src.Service;
using Walmad.Business.src.Shared;
using Walmad.Core.src.Abstraction;
using Walmad.WebAPI.src.Authorization;
using Walmad.WebAPI.src.Database;
using Walmad.WebAPI.src.Middleware;
using Walmad.WebAPI.src.Repository;
using Walmad.WebAPI.src.Service;

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
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepo, ReviewRepo>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductImageRepo, ProductImageRepo>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressRepo, AddressRepo>();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<CheckAddressHandler>();

// error handler middleware
builder.Services.AddTransient<ExceptionHandlerMiddleware>();

// add automapper dependency injection
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

//Add database context service
builder.Services.AddDbContext<DatabaseContext>();

// config authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    });

// config authorization
builder.Services.AddAuthorization(policy =>
{
    policy.AddPolicy("SuperAdmin", policy => policy.RequireClaim(ClaimTypes.Email, "jim2qwdqwd@gmail.com"));
    policy.AddPolicy("MaxLength", policy => policy.AddRequirements(new CheckAddressRequirement(10)));
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
