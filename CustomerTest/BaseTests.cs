using AutoMapper;
using Microsoft.Extensions.Configuration;
using CleanArch.Application.AutoMapper;
using CustomerTest.Factory;
using CleanArch.Infra.Data.Repository;
using CleanArch.Infra.Data.Context;
using CleanArch.Domain.Interfaces;

namespace CustomerTest
{
    public abstract class BaseTests
    {
        protected IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder();
                builder.AddInMemoryCollection(new Dictionary<string, string>()
                {
                    {"key", "value"}
                });
                return builder.Build();
            }
            set
            {
                Configuration = value;
            }
        }

        //Creates a in-memory database for tests purpose
        protected CRUDContext Context
        {
            get
            {
                return DatabaseFactory.Create();
            }
        }

        //must share same in-memory context as the unit test
        public IUnitOfWork GetUnitOfWork(CRUDContext context)
        {
            return new UnitOfWork(context);
        }

        protected IMapper IMapper
        {
            get
            {
                var config = new MapperConfiguration(config =>
                {
                    config.AddProfile<DomainToViewModelMappingProfile>();
                    config.AddProfile<ViewModelToDomainMappingProfile>();
                });
                return config.CreateMapper();
            }
        }
    }
}
