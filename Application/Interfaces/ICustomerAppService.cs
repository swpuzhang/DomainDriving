using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    /// <summary>
    /// 定义app服务
    /// </summary>
    public interface ICustomerAppService :IDisposable
    {
        void Register(CustomerViewModel customer);
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel GetById(Guid id);
        void Update(CustomerViewModel customerViewModel);
        void Remove(Guid id);
    }
}
