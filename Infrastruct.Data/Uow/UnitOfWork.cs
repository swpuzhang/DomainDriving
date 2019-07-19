using Domain.Interfaces;
using Infrastruct.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruct.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudyContext _context;

        public UnitOfWork(StudyContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
