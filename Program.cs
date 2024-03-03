using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Data;
using Microsoft.EntityFrameworkCore;
using PruebaApi.Models; 


var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("BDMemoria"));


// Registra los servicios necesarios para los controladores
builder.Services.AddControllers(); // Añade soporte para controladores

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    // Asegúrate de que la base de datos está creada
    context.Database.EnsureCreated();
    
    // Precargar usuarios o cualquier otro dato necesario
    if (!context.Users.Any())
    {
        context.Users.Add(new User { Username = "usuarioPrueba", Password = "contraseñaPrueba" }); // Considera usar hashing para la contraseña
    }

    // Precargar libros si no existen en la base de datos
    if (!context.Books.Any())
    {
        context.Books.AddRange(
            new Book
            {
                Title = "Cien años de soledad",
                Author = "Gabriel García Márquez",
                Genre = "Realismo mágico",
                PublishDate = new DateTime(1967, 5, 30)
            },
            new Book
            {
                Title = "1984",
                Author = "George Orwell",
                Genre = "Ciencia ficción distópica",
                PublishDate = new DateTime(1949, 6, 8)
            },
            new Book
            {
                Title = "El señor de los anillos",
                Author = "J.R.R. Tolkien",
                Genre = "Fantasía",
                PublishDate = new DateTime(1954, 7, 29)
            }
        );
        context.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Asegura que la app use la autenticación
app.UseAuthorization(); // Asegura que la app use la autorización

app.MapControllers(); // Mapea los controladores

app.Run();
