using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Droid.Core.Services.Tools
{
    public interface IPhotoService
    {
        void GetNewPhoto();
        void HandlePhotoAvailable(Stream pictureStream);
        event EventHandler<PhotoStreamEventArgs> PhotoStreamAvailable;
    }
}
