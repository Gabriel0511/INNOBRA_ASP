using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.Server.Repositorio;
using Microsoft.EntityFrameworkCore;

//Configuracion de los servicios en el constructor de la aplicacion
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));
builder.Services.AddAutoMapper(typeof (Program));
builder.Services.AddScoped<IItemTipoRepositorio, ItemTipoRepositorio>();


//------------------------------------------------------------------------------
//Construccion de la aplicacion
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
