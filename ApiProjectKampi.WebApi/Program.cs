using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Entities;
using ApiProjectKampi.WebApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*burada yap�c� metod kulland�g�m�z �c�n buraya da b�lg�s�n� verd�k*/
builder.Services.AddDbContext<ApiContext>();
/*burada mapper kullanarak otomatik olarak map edebilecegimiz �c�n buraya da b�lg�s�n� verd�k
 AutoMapper, nesneleri birbirine d�n��t�rmek i�in kullan�lan bir k�t�phanedir.
 �rne�in, bir DTO (Data Transfer Object) nesnesini bir Entity nesnesine d�n��t�rmek i�in kullan�labilir.*/

/*C#�ta yazd���n bir uygulama derlendi�inde (build),
 bu uygulama bir .exe veya .dll dosyas�na d�n���r.
 ��te bu dosyaya "assembly" denir.*/
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
