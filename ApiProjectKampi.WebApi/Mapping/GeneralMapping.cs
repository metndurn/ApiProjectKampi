﻿using ApiProjectKampi.WebApi.Dtos.FeatureDtos;
using ApiProjectKampi.WebApi.Dtos.MessageDtos;
using ApiProjectKampi.WebApi.Dtos.ProductDtos;
using ApiProjectKampi.WebApi.Entities;
using AutoMapper;

namespace ApiProjectKampi.WebApi.Mapping
{
	/*profile automapperdan geliyor*/
	public class GeneralMapping:Profile
	{
		public GeneralMapping()//bu yapıcı metoddur
		{
			/*FeatureDtos ile Feature entitysini eşleştiriyoruz
			 AutoMapper'deki ReverseMap() metodu, iki yönlü dönüşüm sağlar.
			Yani, bir nesneyi diğerine dönüştürdüğünüz gibi,
			tersini de otomatik olarak yapmanıza olanak tanır.*/
			CreateMap<Feature, ResultFeatureDtos>().ReverseMap();
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
			CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

			CreateMap<Message, ResultMessageDtos>().ReverseMap();
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
			CreateMap<Message, GetByIdMessageDto>().ReverseMap();

			CreateMap<Product, CreateProductDto>().ReverseMap(); //Product ile CreateProductDto arasında dönüşüm yapar
			CreateMap<Product, ResultProductWithCategoryDto>()
				.ForMember(x => x.CategoryName, y => y.MapFrom
				(z => z.Category.CategoryName)).ReverseMap();//Product ile ResultProductWithCategoryDto arasında dönüşüm yapar
		}
	}
}
