using Droid.Core.Services;
using Droid.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core
{
    public class LoginApp : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<ILoginService, LoginService>();
            Mvx.IoCProvider.RegisterType<IRegisterService, RegisterService>();

            RegisterAppStart<LoginViewModel>();
        }
    }
}
