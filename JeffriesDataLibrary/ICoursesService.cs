using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    interface ICoursesService
    {
        List<Course> GetAll();
        Course Get(int courseId);
        Course Add(Course item);
        void Remove(int courseId);
        bool Update(Course item);
    }
}
