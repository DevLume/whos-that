using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Recognition.Models;
using Recognition.Utilities;

namespace Recognition.RecognitionServices
{
    public class RecServices
    {
        private const string _subscriptionKey = "67942c6970874ee1aa2e8d814955a0ba";
        private const string _recognitionApi = "https://northeurope.api.cognitive.microsoft.com/face/v1.0";
        private const string _groupId = "people";

        private FaceServiceClient _faceServiceClient;

        public RecServices()
        {
            _faceServiceClient = new FaceServiceClient(_subscriptionKey, _recognitionApi);
        }

        /// <summary>
        /// Identifies person from an image taken in the app
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> Identify(UserModel user)
        {
            string imageUri = user.ImageUri;
            RecognitionUtils recUtils = new RecognitionUtils();

            var memoryStream = new MemoryStream();
            memoryStream = recUtils.GetStream(imageUri);

            var faces = await _faceServiceClient.DetectAsync(memoryStream);

            var faceIds = faces.Select(face => face.FaceId).ToArray();

            var results = await _faceServiceClient.IdentifyAsync(_groupId, faceIds);

            var candidateId = results[0].Candidates[0].PersonId;
            var person = await _faceServiceClient.GetPersonAsync(_groupId, candidateId);

            return person.Name;
        }

        /// <summary>
        /// Inserts new image
        /// </summary>
        /// <param name="user"></param>
        /// <returns>boolean</returns>
        public async Task<bool> InsertPersonInToGroup(UserModel user)
        {
            CreatePersonResult result = await _faceServiceClient.CreatePersonAsync(_groupId, user.Id.ToString());
            RecognitionUtils recUtils = new RecognitionUtils();

            await _faceServiceClient.AddPersonFaceAsync(_groupId, result.PersonId, recUtils.GetStream(user.ImageUri));

            await _faceServiceClient.TrainPersonGroupAsync(_groupId);

            return true;
        }

        /// <summary>
        /// Creates person group in Azure face recognition API
        /// </summary>
        /// <returns>boolean</returns>
        public async Task<bool> CreateGroup()
        {
            await _faceServiceClient.CreatePersonGroupAsync(_groupId, "fun");

            await _faceServiceClient.TrainPersonGroupAsync(_groupId);

            TrainingStatus trainingStatus = null;
            while (true)
            {
                trainingStatus = await _faceServiceClient.GetPersonGroupTrainingStatusAsync(_groupId);

                if (trainingStatus.Status != Status.Running)
                {
                    break;
                }

                await Task.Delay(1000);
            }

            return true;
        }
    }
}
