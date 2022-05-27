using Infrastructure;
using Service.Interfaces;
using Service;
using Application.Validation;
using FluentValidation;
using Application.DTOs;
using Application.Mapper;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(j => j.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve)
    .AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("PetDatabase");
builder.Services.AddSqlite<SqLiteContext>(connectionString);

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAccommodationService, AccommodationService>();
builder.Services.AddScoped<IPetService, PetService>();

builder.Services.AddTransient<IValidator<PetDTO>, PetDTOValidator>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
