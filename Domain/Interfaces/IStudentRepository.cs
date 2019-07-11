using Domain.Models;
using DomianDriving.Domains.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetEmail(string email);
    }
}
