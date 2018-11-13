using Recognition.Wrappers;
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
        private ICustomWebClientFactory WebClientFactory { get; set; }
        public ICustomWebClient CustomWebClient { get; set; }

        public RecognitionUtils()
        {
            WebClientFactory = new CustomWebClientFactory();
            CustomWebClient = WebClientFactory.Create();
        }

        /// <summary>
        /// Gets stream of image from URI
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public MemoryStream GetStream(string uri)
        {
            byte[] imageData = null;

            imageData = CustomWebClient.DownloadData(uri);

            return new MemoryStream(imageData);
        }
    }
}
