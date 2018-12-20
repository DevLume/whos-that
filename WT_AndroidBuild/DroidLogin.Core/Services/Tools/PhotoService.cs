using MvvmCross;
using MvvmCross.Plugin.PictureChooser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.Services.Tools
{
    public class PhotoService : IPhotoService, IMvxPictureChooserTask
    {
        public event EventHandler<PhotoStreamEventArgs> PhotoStreamAvailable;

        private const int MaxPixelDimension = 1024;
        private const int DefaultJpegQuality = 92;

        public void GetNewPhoto()
        {
            Trace.TraceInformation("Get a new Photo started");

            TakePicture(MaxPixelDimension, DefaultJpegQuality, HandlePhotoAvailable, () => { });
        }

           

        public void ChooseOrTakePicture(int maxPixelDimension, int percentQuality, Action<Stream, string> pictureAvailable, Action assumeCancelled)
        {
            throw new NotImplementedException();
        }

        public void ChoosePictureFromLibrary(int maxPixelDimension, int percentQuality, Action<Stream, string> pictureAvailable, Action assumeCancelled)
        {
            throw new NotImplementedException();
        }

        public void ChoosePictureFromLibrary(int maxPixelDimension, int percentQuality, Action<Stream> pictureAvailable, Action assumeCancelled)
        {
            throw new NotImplementedException();
        }

        public void TakePicture(int maxPixelDimension, int percentQuality, Action<Stream> pictureAvailable, Action assumeCancelled)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> ChoosePictureFromLibrary(int maxPixelDimension, int percentQuality)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> TakePicture(int maxPixelDimension, int percentQuality)
        {
            throw new NotImplementedException();
        }

        public void ContinueFileOpenPicker(object args)
        {
            throw new NotImplementedException();
        }

        public void HandlePhotoAvailable(Stream pictureStream)
        {
            throw new NotImplementedException();
        }
    }
}
