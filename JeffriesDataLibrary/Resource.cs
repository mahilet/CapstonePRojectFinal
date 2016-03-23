using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    public class Resource
    {
        public int ResourceId { get; set; } //(int, not null)
        public int CourseId { get; set; } //(int, not null)
        public string FileName { get; set; } //(varchar(200), not null)
        public string FileType { get; set; } //(varchar(3), not null)
        public byte[] FileBinary { get; set; } //(varbinary(max)2147483647)
    }
}
