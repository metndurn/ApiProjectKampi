using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Entities;
using ApiProjectKampi.WebApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*burada yapýcý metod kullandýgýmýz ýcýn buraya da býlgýsýný verdýk*/
builder.Services.AddDbContext<ApiContext>();
/*burada mapper kullanarak otomatik olarak map edebilecegimiz ýcýn buraya da býlgýsýný verdýk
 AutoMapper, nesneleri birbirine dönüþtürmek için kullanýlan bir kütüphanedir.
 Örneðin, bir DTO (Data Transfer Object) nesnesini bir Entity nesnesine dönüþtürmek için kullanýlabilir.*/

/*C#’ta yazdýðýn bir uygulama derlendiðinde (build),
 bu uygulama bir .exe veya .dll dosyasýna dönüþür.
 Ýþte bu dosyaya "assembly" denir.*/
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IValidator<Product>, ProductValidator>();



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
