using Microsoft.EntityFrameworkCore;
using Oracle.DataAccess.Models;
using Oracle.Services.Actions;
using Oracle.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    // CONEXION HACIA LA BASE DE DATOS  
var cadenaConexion = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<ModelContext>(x =>
    x.UseOracle(
        cadenaConexion,
        options => options.UseOracleSQLCompatibility("11")
        )
    );

//Implementacion de los servicios para cada modelo

builder.Services.AddTransient<IProveedorService, ProveedorService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<ICategoriaService,CategoriaService>();
builder.Services.AddTransient<ITerritorioService, TerritorioService>();
builder.Services.AddTransient<ISucursalService, SucursalService>();
builder.Services.AddTransient<ITipoUserService,TipoUserService>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<ICardexService, CardexService>();
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddTransient<IOrdenCompraService, OrdenCompraService>();
builder.Services.AddTransient<IDescuentoService, DescuentoService>();
builder.Services.AddTransient<IFormaPagoService, FormaPagoService>(); 
builder.Services.AddTransient<IPuestoService, PuestoService>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IFacturaService, FacturaService>();
builder.Services.AddTransient<IPedidoService,PedidoService>();
builder.Services.AddTransient<IDetallePedidoService, DetallePedidoService>();
builder.Services.AddTransient<IDetalleFacturaService, DetalleFacturaService>();
builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
