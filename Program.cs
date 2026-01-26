// Este es el punto de entrada principal de la aplicación API.
using PetSavingBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Databse conection
builder.Services.AddDbContext<ApplicationDBContext>(Options => Options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Este es el punto donde se configura la canalización de solicitudes HTTP.
var app = builder.Build();

//Este bloque configura Swagger para el entorno de desarrollo.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Este middleware redirige las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

app.MapControllers();

//app.run inicia la aplicación y comienza a escuchar las solicitudes entrantes.
app.Run();