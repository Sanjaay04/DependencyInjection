using DependencyInjection.Controllers;
using DependencyInjection.Interface;
using DependencyInjection.Service;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Iproductservice,DependencyInjection.Service.ProductService>();
builder.Services.AddSingleton<Ilogger,LoggerService>();
builder.Services.AddTransient<Idiscount,discountservice>();
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
// Enable Swagger middleware
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
