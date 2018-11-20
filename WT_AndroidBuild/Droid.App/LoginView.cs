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
using MvvmCross.Platforms.Android.Views;

namespace Droid.App
{
    [Activity(Label = "Login Screen", MainLauncher = true)]
    public class LoginView : MvxActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.login);
            LoginViewModel.OnRequestSent += LoginViewModel_OnLoginRequestSent;
            LoginViewModel.OnActivityChange += LoginViewModel_OnActivityChange;
            LoginViewModel.OnError += LoginViewModel_OnError;
        }

        private void LoginViewModel_OnError(object sender, SendErrorArgs e)
        {
            Toast.MakeText(this, e.errorInfo, ToastLength.Long).Show();
        }

        private void LoginViewModel_OnLoginRequestSent(object sender, SendLoginRequestArgs e)
        {
            Toast.MakeText(this, e.response, ToastLength.Long).Show();
            if (e.pass)
            {              
                Intent intent = new Intent(this, typeof(MainView));
                this.StartActivity(intent);
            }
        }

        private void LoginViewModel_OnActivityChange(object sender, ChangeActivityArgs e)
        {
            Intent intent = new Intent(this, typeof(RegisterView));
            this.StartActivity(intent);
        }
    }
}