using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Views.InputMethods;
using System;

using Android.Views;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace Whos_that
{
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnRegister;
        LinearLayout linearLayout;

        EditText usernameText;
        EditText passwordText;
        private Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
          
            usernameText = FindViewById<EditText>(Resource.Id.txtLoginUsername);
            passwordText = FindViewById<EditText>(Resource.Id.txtLoginPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnSignIn);
          
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += (object sender, System.EventArgs e) =>
            {
                Intent intent = new Intent(this, typeof(registerUI));
                this.StartActivity(intent);
            };

            btnLogin.Click += btnSignIn_Click;

            linearLayout = FindViewById<LinearLayout>(Resource.Id.loginLinearLayout);
            linearLayout.Click += LinearLayout_Click;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            EntryManager entryman = new EntryManager();
            entryman.SendLoginRequest(usernameText.Text, passwordText.Text, this);
        }

        private void LinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}