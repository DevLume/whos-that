using Droid.Core.Services;
using Droid.Core.Services.ViewEvent;
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
        public static string loggedUserName = "";
        public static string createTestName = "";
        public static string guessTestName = "";
        public static string guessTestAuthorName = "";
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<ILoginService, LoginService>();
            Mvx.IoCProvider.RegisterType<IRegisterService, RegisterService>();
            Mvx.IoCProvider.RegisterType<ICreateTestService, CreateTestService>();
            Mvx.IoCProvider.RegisterType<IGuessTestService, GuessTestService>();
            Mvx.IoCProvider.RegisterType<ISubmitResultService, SubmitResultService>();
            Mvx.IoCProvider.RegisterType<ITestListService, TestListService>();

            RegisterAppStart<LoginViewModel>();
        } 
    }
}
