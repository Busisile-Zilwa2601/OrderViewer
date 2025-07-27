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
                // Add more mappings as needed
            });
            return mappingConfig;
        }
    }
}
