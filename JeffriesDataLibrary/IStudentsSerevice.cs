using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    interface IStudentsSerevice
    {
        List<Student> GetAll();
        Student Get(int studentId);
        Student Add(Student item);
        void Remove(int studentId);
        bool Update(Student item);
    }
}
