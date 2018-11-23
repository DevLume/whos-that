using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.Services.ViewEvent
{
    public interface ILoginEventManager
    {
        void OnError(object sender, SendErrorArgs e);
        void OnActivityChange(object sender, ChangeActivityArgs e);
        void OnLogin(object sender, SendLoginRequestArgs e);
    }
}
