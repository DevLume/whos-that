using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Recognition.Utilities
{
    public class RecognitionUtils
    {
        public WebClient WebClient { get; set; }

        /// <summary>
        /// Gets stream of image from URI
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public MemoryStream GetStream(string uri)
        {
            WebClient = new WebClient();
            byte[] imageData = null;

            imageData = WebClient.DownloadData(uri);

            return new MemoryStream(imageData);
        }
    }
}
