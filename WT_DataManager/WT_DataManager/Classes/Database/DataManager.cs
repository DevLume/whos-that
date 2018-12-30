using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    public static class DataManager 
    {
        private static IDataManager Dataman { get; set; }

        public static void SetDataManager(IDataManager datman)
        {
            Dataman = datman;
        }

        public static IDataManager GetDataManager()
        {
            return Dataman;
        }
    }
}
