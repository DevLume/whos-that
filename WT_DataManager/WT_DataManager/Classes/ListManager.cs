using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    public class ListManager
    {
        [Flags]
        public enum sortOptions
        {
            none = 0,
            byName = 1,
            byGender = 2
            //by whatever we might sort...
        }

        public List<User> CreateOutputList(List<User> list, sortOptions opt = sortOptions.none)
        {
            IEnumerable<Enum> flags = opt.GetSorts();
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
            else
            {
                Console.WriteLine("No sorting options chosen");
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
