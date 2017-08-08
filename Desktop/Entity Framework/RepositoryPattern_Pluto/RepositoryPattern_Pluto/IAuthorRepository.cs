using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queries.Core;

namespace RepositoryPattern_Pluto
{
   public interface IAuthorRepository:IRepository<Author>
    {
    }

    public class AuthorRepository : Repository<Author>,IAuthorRepository
    {
        private PlutoEntities plutoContext;
        public AuthorRepository(PlutoEntities context):base(context)
        {
            context = plutoContext;
        }
    }
}
