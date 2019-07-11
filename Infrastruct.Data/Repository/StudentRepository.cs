using Domain.Interfaces;
using Domain.Models;
using Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastruct.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(StudyContext context) : base(context)
        {

        }
        public Student GetEmail(string email)
        {
            var students = _dbSet.Where(b => b.Email == email).ToList();
            return students.Count > 0 ? students.First() : null;
        }
    }
}
