using AutoMapper;
using Store.Domain;
using Store.Entities;
using Store.ViewModels;

namespace Store.ServicesHosting.Profiles
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
            CreateMap<Employee, EmployeeEntity>();
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<ProdctEntity, Product>();
            CreateMap<OrderEntity, Order>();
            CreateMap<Order, OrderEntity>();
            CreateMap<object, Employee>();
            CreateMap<Employee, object>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<BrandEntity, Brand>();
            CreateMap<Brand, BrandEntity>();
            CreateMap<Product, ProdctEntity>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Blog, BlogEntity>();
            CreateMap<BlogEntity, Blog>();
        }
    }
}
