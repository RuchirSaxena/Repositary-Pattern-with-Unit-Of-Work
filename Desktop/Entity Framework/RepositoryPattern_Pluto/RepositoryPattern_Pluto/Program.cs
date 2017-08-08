using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Pluto
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var unitofWork=new UnitOfWork(new PlutoEntities()))
            {
                //Cours c = new Cours() {
                //    AuthorID=1,
                //    CourseID=12,
                //    Title="new course",
                //    t
                //};
               var course= unitofWork.Courses.Get(3);
                var courses = unitofWork.Courses.GetCoursesWithAuthors(1, 4);
               




            }
        }
    }
}
