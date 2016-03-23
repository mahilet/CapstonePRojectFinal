using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    public class Reply
    {
        public int ReplyId { get; set; } //(int, not null)
        public int CommentId { get; set; } //(int, not null)
        public string Name { get; set; } //(varchar(50), not null)
        public string Text { get; set; } //(varchar(1000), not null)
        public DateTime DateReplied { get; set; } //(datetime, not null)
    }
}
