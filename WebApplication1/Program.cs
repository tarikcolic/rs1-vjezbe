using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;


//– Prvi dio (builder.Services…) kaže koji servisi postoje. Drugi dio (app.Use…, app.Map…) određuje kroz šta prolazi svaki zahtjev: Swagger, HTTPS i kontrolere.
//– AddSingleton<StudentStorage>(): cijela aplikacija dijeli jedno skladište. Kad biste napisali AddScoped, svaki zahtjev bi dobio novo, prazno skladište: POST bi dodao studenta, a sljedeći GET ga ne bi vidio. Probajte.


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Jedna instanca za cijelu aplikaciju, inače bi svaki request dobio praznu listu.
builder.Services.AddSingleton<StudentStorage>();

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
