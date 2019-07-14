using Application.Interfaces;
using Application.ViewModels;
using DomainDriving.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return null;
        }

        public CustomerViewModel GetById(Guid id)
        {
            return null;
        }

        public void Register(CustomerViewModel customer)
        {
            
        }

        public void Remove(Guid id)
        {
           
        }

        public void Update(CustomerViewModel customerViewModel)
        {
            
        }
    }
}
