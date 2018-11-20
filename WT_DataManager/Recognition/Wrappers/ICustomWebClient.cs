using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recognition.Wrappers
{
    public interface ICustomWebClient
    {
        byte[] DownloadData(string uri);
    }
}
