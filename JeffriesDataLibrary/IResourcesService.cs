using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary
{
    interface IResourcesService
    {
        List<Resource> GetAll();
        Resource Get(int resourceId);
        Resource Add(Resource item);
        void Remove(int resourceId);
        bool Update(Resource item);
    }
}
