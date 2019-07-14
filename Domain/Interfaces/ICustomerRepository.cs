using DomainDriving.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDriving.Domains.Interfaces
{
    /// <summary>
    /// 定义Customer独有的数据操作
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetEmail(string email);
    }
}
