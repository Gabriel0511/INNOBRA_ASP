using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.Server.Repositorio;
using INNOBRA_ASP.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

//Configuracion de los servicios en el constructor de la aplicacion
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));
builder.Services.AddAutoMapper(typeof (Program));

//PABLO
builder.Services.AddScoped<IItemTipoRepositorio, ItemTipoRepositorio>();
builder.Services.AddScoped<IItemTipoRenglonRepositorio,ItemTipoRenglonRepositorio>();
builder.Services.AddScoped<IUnidadRepositorio, UnidadRepositorio>();

//STEFANO
builder.Services.AddScoped<IAvanceRepositorio, AvanceRepositorio>();
builder.Services.AddScoped<IRecursoRepositorio, RecursoRepositorio>();

//GABRIEL
builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
builder.Services.AddScoped<IPresupuestoRepositorio, PresupuestoRepositorio>();

//LUCIA
builder.Services.AddScoped<IItemRepositorio, ItemRepositorio>();
builder.Services.AddScoped<IItemRenglonRepositorio, ItemRenglonRepositorio>();


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
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();


app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");


app.Run();
