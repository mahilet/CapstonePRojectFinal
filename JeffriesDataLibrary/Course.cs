using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    public class Course
    {
        public int CourseId { get; set; } //(int, not null)
        public string Title { get; set; } //(varchar(200), not null)
        public string Description { get; set; } //(varchar(2000), not null)
    }
}
