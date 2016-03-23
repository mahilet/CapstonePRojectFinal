using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    public class VBlog
    {
        public int VBlogId { get; set; } //(int, not null)
        public string Title { get; set; } //(varchar(50), not null)
        public string Description { get; set; } //(varchar(200), not null)
        public string FileName { get; set; } //(varchar(50), not null)
        public string FileType { get; set; } //(varchar(3), not null)
        public byte[] FileBinary { get; set; } //(varbinary(max)2147483647)
        public DateTime DatePosted { get; set; } //(datetime, not null)
        public int IndexOrder { get; set; } //(int, not null)
    }
}
