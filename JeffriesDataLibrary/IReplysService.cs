using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    interface IReplysService
    {
        List<Reply> GetAll();
        Reply Get(int replyId);
        Reply Add(Reply item);
        void Remove(int replyId);
        bool Update(Reply item);

    }
}
