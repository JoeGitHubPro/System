using AutoMapper;
using System.DAL.DTOs;
using System.DAL.Models;

namespace System.DAL.Data.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Addition, AdditionDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();
        }
    }
}
