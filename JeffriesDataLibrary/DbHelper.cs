using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeffriesDataLibrary {
    public static class DbHelper {
        public static string ConnectionString {
            get { return "Data Source=WIN8MH;Initial Catalog=JefferiesWebsite;Integrated Security=True"; } 
        }
    }
}
