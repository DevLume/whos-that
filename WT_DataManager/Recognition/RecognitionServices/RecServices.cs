using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;

namespace Recognition.RecognitionServices
{
    public class RecServices
    {
        private const string _subscriptionKey = "67942c6970874ee1aa2e8d814955a0ba";
        private const string _recognitionApi = "https://northeurope.api.cognitive.microsoft.com/face/v1.0";

        private FaceServiceClient _faceServiceClient;

        public RecServices()
        {
            _faceServiceClient = new FaceServiceClient(_subscriptionKey, _recognitionApi);
        }


    }
}
