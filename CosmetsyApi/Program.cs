using System.Text;
using Business.Abstract;
using Business.Concrete;
using Core.Entity.Models;
using Core.Security.Hasing;
using Core.Security.Models;
using Core.Security.TokenHandler;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTConfig:Key"]);
    var issuer = builder.Configuration["JWTConfig:Issuer"];
    var audience = builder.Configuration["JWTConfig:Audience"];
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidIssuer = issuer,
        ValidAudience = audience
    };
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings
.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IBlogDal, BlogDal>();
builder.Services.AddScoped<IBlogManager, BlogManager>();
builder.Services.AddScoped<IAuthDal, AuthDal>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ICommentDal, CommentDal>();
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<IOrderDal, OrderDal>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<IOrderTrackingDal, OrderTrackingDal>();
builder.Services.AddScoped<IOrderTrackingManager, OrderTrackingManager>();
builder.Services.AddScoped<IProductDal, ProductDal>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IProductPictureDal, ProductPictureDal>();
builder.Services.AddScoped<IProductPictureManager, ProductPictureManager>();

builder.Services.AddScoped<HasingHandler>();
builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<JWTConfig>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
