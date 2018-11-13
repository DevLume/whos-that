using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recognition.Wrappers
{
    public class CustomWebClientFactory : ICustomWebClientFactory
    {
        public ICustomWebClient Create()
        {
            return new CustomWebClient();   
        }
    }
}
