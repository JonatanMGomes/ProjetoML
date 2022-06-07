using ProjetoML.Lib.Data;
using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Data.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MLContext>(
        conn => conn.UseNpgsql(builder.Configuration.GetConnectionString("ML_DB"))
        .UseSnakeCaseNamingConvention()
    );

builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<PedidoRepositorio>();
builder.Services.AddScoped<ProdutoRepositorio>();
builder.Services.AddScoped<ProdutoPedidoRepositorio>();
builder.Services.AddScoped<TransportadoraRepositorio>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<VendedorRepositorio>();

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
