using AMXProductsCatalog;
using AMXProductsCatalog.Adapters.Persistence.Data;
using AMXProductsCatalog.Adapters.Persistence.Ioc;
using AMXProductsCatalog.Automapper;
using AMXProductsCatalog.Core.Application.Ioc;
using AMXProductsCatalog.Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddPersistenceRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddPortsPresenters();

// AutoMapper
builder.Services.AddAutoMapper(typeof(ProductsCatalogProfile).Assembly);

// Authentication
builder.Services.AddCors();
builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(q =>
{
    q.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    q.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(q =>
    {
        q.RequireHttpsMetadata = false;
        q.SaveToken = true;
        q.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.GeneratePolymorphicSchemas();
});

AMXDatabase.startDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Authentication
app.UseCors(q =>
{
    q.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthentication();
app.UseAuthentication();


app.MapControllers();

app.Run();
