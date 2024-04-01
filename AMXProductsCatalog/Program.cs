using AMXProductsCatalog.Adapters.Persistence.Data;
using AMXProductsCatalog.Adapters.Persistence.Ioc;
using AMXProductsCatalog.Automapper;
using AMXProductsCatalog.Core.Application.Ioc;
using AMXProductsCatalog.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddPersistenceRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddPortsPresenters();

// AutoMapper
builder.Services.AddAutoMapper(typeof(ProductsCatalogProfile).Assembly);

builder.Services.AddControllers();

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

app.UseAuthorization();


app.MapControllers();

app.Run();
