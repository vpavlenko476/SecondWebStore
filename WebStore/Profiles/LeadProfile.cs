using AutoMapper;
using Store.Domain;
using Store.Entities;

namespace WebStore.Profiles
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<EmployeeEntity, Employee>();
            CreateMap<Employee, EmployeeEntity>();
        }
    }
}
