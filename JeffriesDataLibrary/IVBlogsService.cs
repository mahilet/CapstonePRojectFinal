using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    interface IVBlogsService
    {
        List<VBlog> GetAll();
        VBlog Get(int vBlogId);
        VBlog Add(VBlog item);
        void Remove(int vBlogId);
        bool Update(VBlog item);
    }
}
