using AutoMapper;
using CleanArch.Infra.Data.Context;
using CleanArch.Application.Command;
using CleanArch.Application.Handler;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repository;
using CleanArch.Application.Contract;
using CleanArch.Domain.Models;

namespace CustomerTest.Tests.Domain.Commands.CustomerCommands
{
    [TestClass]
    public class AddCustomerCommandHandlerTests : BaseTests
    {
        private CRUDContext _inMemoryContext;
        private ICustomerService _customerService;
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _uow;
        private IMapper _mapper;


        private static IEnumerable<object[]> InvalidCustomers
        {
            get
            {
                return new[]
                {
                    //First name incorrect
                 new object[] { new Customer() {Id = 1, Firstname = "", Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = "email@mail.com" } },
                 new object[] { new Customer() {Id = 1, Firstname = " ", Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = "email@mail.com" } },
                 new object[] { new Customer() {Id = 1, Firstname = null, Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = "email@mail.com" } },

                 //Last name incorrect
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = "email@mail.com" } },
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = " ", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = "email@mail.com" } },
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = null, PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = "email@mail.com" } },

                 //PhoneNumber incorrect
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = 0, BankAccountNumber = "1234567890", Email = "email@mail.com" } },
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = 0, BankAccountNumber = "1234567890", Email = "email@mail.com" } },
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = 0, BankAccountNumber = "1234567890", Email = "email@mail.com" } },

                 //BankAccountNumber incorrect
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber = "", Email = "email@mail.com" } },
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber ="", Email = "email@mail.com" } },

                 //Email incorrect
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = "" } },
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = " " } },
                 new object[] { new Customer() {Id = 1, Firstname = "Rafael", Lastname = "Baptista", PhoneNumber = +989151131123, BankAccountNumber = "1234567890", Email = null } },
                };
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _inMemoryContext = Context;
            _customerRepository = new CustomerRepository(_inMemoryContext);
            _uow = GetUnitOfWork(_inMemoryContext);
            _mapper = IMapper;
            _customerService = new CustomerService();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _inMemoryContext.Dispose();
        }
        
        
        [TestMethod, TestCategory("Customer Commands by MSTest")]        
        public async Task ShouldInsertValidCustomer()
        {
            var command = new CreateAccountCommand
            {
                RegisterAccountDto = new RegisterAccountDtos
                {
                    Firstname = "cristiano",
                    Lastname = "Ronaldo",
                    DateOfBirth = new DateTime(2020, 1, 1),
                    Email = "cristiano.Ronaldo@example.com",
                    BankAccountNumber = "1234567890",
                    PhoneNumber = "+989151228380"
                }
            };
            var handler = new CreateCustomerCommandHandler(_customerRepository, _customerService, _uow);

            var result = await handler.Handle(command, CancellationToken.None);
            var customer = _inMemoryContext.Customers.FirstOrDefault();

            Assert.AreEqual(_inMemoryContext.Customers.Count(), 1);
            Assert.IsTrue(result.IsSuccedded == true);
            Assert.IsTrue(customer.Id != 0);
            Assert.AreEqual(command.RegisterAccountDto.Firstname, customer.Firstname);
            Assert.AreEqual(command.RegisterAccountDto.Email, customer.Email);                       
        }
        [DataTestMethod, TestCategory("Customer Commands by MSTest")]
        [DynamicData(nameof(InvalidCustomers))]    //this unit test will run against each object
        public async Task ShouldNotInsertInvalidCustomer(Customer customer)
        {
            //Arrange
            var command =  new CreateAccountCommand
            {
                RegisterAccountDto = new RegisterAccountDtos
                {
                    Firstname = customer.Firstname,
                    Lastname = customer.Lastname,
                    DateOfBirth = customer.DateOfBirth,
                    Email = customer.Email,
                    BankAccountNumber = customer.BankAccountNumber,
                    PhoneNumber = customer.PhoneNumber.ToString(),
                }
            };
            var handler = new CreateCustomerCommandHandler(_customerRepository, _customerService, _uow);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsTrue(!result.IsSuccedded);
            Assert.AreEqual(_inMemoryContext.Customers.Count(), 0);
        }


    }
}
