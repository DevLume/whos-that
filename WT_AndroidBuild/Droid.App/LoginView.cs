using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Droid.Core;
using Droid.Core.ViewModels;
using Droid.Core.Services.ViewEvent;
using MvvmCross.Platforms.Android.Views;
using Acr.UserDialogs;

namespace Droid.App
{
    [Activity(Label = "Login Screen", MainLauncher = true)]
    public class LoginView : MvxActivity<LoginViewModel>, ILoginEventManager
    {   
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.login);

            LoginViewModel.OnRequestSent += OnLogin;
            LoginViewModel.OnActivityChange += OnActivityChange;
            LoginViewModel.OnError += OnError;               
        }

        
        public void OnError(object sender, SendErrorArgs e)
        {
            Toast.MakeText(this, e.errorInfo, ToastLength.Long).Show();
        }

        public void OnLogin(object sender, SendLoginRequestArgs e)
        {
            Toast.MakeText(this, e.response, ToastLength.Long).Show();
            if (e.pass)
            {              
                Intent intent = new Intent(this, typeof(MainView));
                this.StartActivity(intent);
            }
        }

        public void OnActivityChange(object sender, ChangeActivityArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterView));
            this.StartActivity(intent);
        }

       
    }
}