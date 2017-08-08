using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RepositoryPattern_Pluto
{
    public interface ICourseRepository:IRepository<Cours>
    {
        IEnumerable<Cours> GetTopSellingCourses(int count);
        IEnumerable<Cours> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }

    public class CourseRepository : Repository<Cours>, ICourseRepository
    {
        private PlutoEntities plutoContext;
        public CourseRepository(PlutoEntities context):base(context)
        {
            context = plutoContext;
        }

        public IEnumerable<Cours> GetCoursesWithAuthors(int pageIndex, int pageSize)
        {
            return plutoContext.Courses
                .Include(c=>c.Author)
                .OrderBy(c => c.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
                
        }

        public IEnumerable<Cours> GetTopSellingCourses(int count)
        {
            
            return plutoContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public PlutoEntities PlutoContext
        {
            get { return Context as PlutoEntities; }
        }
    }
}
