using APICliente.Data;
using APICliente.Models;
using APICliente.Repositories;
using APICliente.Repositories.Interfaces;
using APICliente.Services;
using APICliente.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Get the configuration from appsettings.json
var configuration = new ConfigurationBuilder().SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

//Configure the database context
builder.Services.AddDbContext<DbClientesContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DbClientesConnection"));
});

//Add services to the container.
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<ILogradouroRepository, LogradouroRepository>();
builder.Services.AddScoped<ILogradouroService, LogradouroService>();

//Configure Controllers
builder.Services.AddControllers();

//Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
