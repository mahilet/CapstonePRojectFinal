using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    interface ICommentsService
    {
        List<Comment> GetAll();
        Comment Get(int commentId);
        Comment Add(Comment item);
        void Remove(int commentId);
        bool Update(Comment item);
    }

}
