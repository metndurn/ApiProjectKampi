using ApiProjectKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjectKampi.WebApi.ValidationRules
{
	/*FluentValidation, C# uygulamalarında nesnelerin doğrulama kurallarını tanımlamak için kullanılan bir kütüphanedir.*/
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş olamaz.!");
			RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.!");
			RuleFor(x => x.Name).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.!");

			RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş olamaz.!")
			.GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz.!")
			.LessThan(2000).WithMessage("Ürün fiyati bu kadar yüksek olamaz girdiğiniz değeri kontrol edin.!");

			RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün açıklaması boş olamaz.!");
		}
	}
}
