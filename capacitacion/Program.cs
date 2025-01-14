﻿using capacitacion.Data;
using capacitacion.Data.Interfaces;
using capacitacion.Data.Services;
var builder = WebApplication.CreateBuilder (args);

// Add services to the container.

builder.Services.AddControllers ();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer ();
builder.Services.AddSwaggerGen ();

PostgreSQLConnection postgreSQLConnection = new(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
builder.Services.AddSingleton(postgreSQLConnection);

// Servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build ();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment ()) {
  app.UseSwagger ();
  app.UseSwaggerUI ();
}

app.UseHttpsRedirection ();

app.UseAuthorization ();

app.MapControllers ();

app.Run ();
