using AutoMapper;
using CleanArch.Application.Command;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;

namespace CleanArch.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Customer, EditAccountCommand>();
            CreateMap<Customer, DeleteAccountCommand>();

            CreateMap<CreateAccountCommand, CustomerViewModel>();



        }
    }
}
