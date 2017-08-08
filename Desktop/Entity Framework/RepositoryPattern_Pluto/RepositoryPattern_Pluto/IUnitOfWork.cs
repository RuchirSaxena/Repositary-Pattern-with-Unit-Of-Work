using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queries.Core;


namespace RepositoryPattern_Pluto
{
    interface IUnitOfWork:IDisposable
    {
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        int Save();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoEntities _context;
        
        public UnitOfWork(PlutoEntities context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
        }
        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
