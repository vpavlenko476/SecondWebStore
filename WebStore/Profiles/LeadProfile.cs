using AutoMapper;
using Store.Domain;
using Store.Entities;
using WebStore.ViewModels;

namespace WebStore.Profiles
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
            CreateMap<BrandEntity, Brand>();
            CreateMap<Brand, BrandEntity>();
            CreateMap<Product, ProdctEntity>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Blog, BlogEntity>();
            CreateMap<BlogEntity, Blog>();
        }
    }
}
