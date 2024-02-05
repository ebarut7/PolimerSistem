using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TetraPolimerSistem.Business.DependencyResolvers.Autofac;
using TetraPolimerSistem.Business.DependencyResolvers.Extension;
using TetraPolimerSistem.DataAccess.Concrete.EntityFrameworkCore.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new BusinessModule()));

//AddDbContext
builder.Services.Register();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TetraPolimerSistemContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddCors(options =>
{
    options.AddPolicy("guvenlik", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("guvenlik");

app.MapControllers();

app.Run();
