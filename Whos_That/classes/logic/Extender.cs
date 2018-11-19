using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Whos_that.ListManager;

namespace Whos_that
{
    //Extension methods here 
    public static class Extender
    {
        public static IEnumerable<Enum> GetSorts(this sortOptions sorts)
        {
            Enum e = sorts;
            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag); //lambada + linq + enums (COMBO)
        }
    }
}
