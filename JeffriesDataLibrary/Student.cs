using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    public class Student
    {
        public int StudentId { get; set; } //(int, not null)
        public int CourseId { get; set; } //(int, not null)
        public string LastName { get; set; } //(varchar(50), not null)
        public string FirstName { get; set; } //(varchar(50), not null)
        public byte Campus { get; set; } //(tinyint, not null)
        public string Email { get; set; } //(varchar(100), not null)
    }
}
