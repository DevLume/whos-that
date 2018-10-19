using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    [Flags]
    public enum sortOptions
    {
        none = 0,
        byName = 1,
        byGender = 2
        //by whatever we might sort...
    }
    public static class ListManager
    { 
        private static IEnumerable<Enum> GetFlags(Enum e)
        {
            return Enum.GetValues(e.GetType()).Cast<Enum>().Where(e.HasFlag); //lambada + linq + enums (COMBO)
        }

        public static List<User> CreateOutputList(sortOptions opt, List<User> list)
        {
            IEnumerable<Enum> flags = GetFlags(opt);
            bool byName = false;
            bool byGender = false;
            List<User> output = new List<User>();
            foreach (Enum en in flags) {
                if (en.HasFlag(sortOptions.byName))
                {
                    byName = true;
                }
                if (en.HasFlag(sortOptions.byGender))
                {
                    byGender = true;
                }
            }          
            
            if (byName && byGender)
            {
                var listQuery =
                    (from obj in list
                     select obj).OrderBy(c => c.username).ThenBy(c => c.gender);
                foreach (var v in listQuery)
                {
                    output.Add(v);
                }
            }
            else if (byName)
            {
                var listQuery =
                    (from obj in list
                     select obj).OrderBy(c => c.username);
                foreach (var v in listQuery)
                {
                    output.Add(v);
                }
            }
            else if (byGender)
            {
                var listQuery =
                    (from obj in list
                     select obj).OrderBy(c => c.gender);
                foreach (var v in listQuery)
                {
                    output.Add(v);
                }
            }

            return output;
        }   
    }
}
