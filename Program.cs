using Microsoft.AspNetCore.Mvc;
using primeraapi;
using primeraapi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareasService, TareasService>();

builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("cnTareasPostgres"));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//Corregir problemas con timestamp
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(o=>{
    o.WithOrigins("http://localhost:5500");
    o.AllowAnyHeader();
    o.AllowAnyMethod();
    o.AllowCredentials();
});
app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
