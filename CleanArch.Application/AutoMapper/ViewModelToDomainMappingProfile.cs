using AutoMapper;
using CleanArch.Application.Command;
using CleanArch.Application.Query;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, CreateAccountCommand>();
            CreateMap<CustomerViewModel, GetCustomerByIdQuery>();
            CreateMap<CustomerViewModel, EditAccountCommand>();
            CreateMap<CreateAccountCommand, Customer>();

            
        }
    }
}
