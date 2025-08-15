using AutoMapper;
using OrderViewer.Service.OrderAPI.Models;
using OrderViewer.Service.OrderAPI.Dtos;

namespace OrderViewer.Service.OrderAPI.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() { 
           var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Order, OrderDto>().ReverseMap();
                config.CreateMap<OrderDto, Order>().ReverseMap();

                // Entity -> DTO
                config.CreateMap<Product, ProductDetails>();
                config.CreateMap<Order, ProductDto>()
                    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

                // DTO -> Entity
                config.CreateMap<ProductDetails, Product>();
                config.CreateMap<ProductDto, Order>()
                    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            });
            return mappingConfig;
        }
    }
}
