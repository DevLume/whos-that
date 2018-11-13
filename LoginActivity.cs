using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;

namespace Whos_that
{
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        private Button btnRegister;
        LinearLayout linearLayout;

        EditText usernameText;
        EditText passwordText;
        private Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            usernameText = FindViewById<EditText>(Resource.Id.txtLoginUsername);
            passwordText = FindViewById<EditText>(Resource.Id.txtLoginPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnSignIn);
            btnLogin.Click += btnSignIn_Click;

            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += (object sender, System.EventArgs e) =>
            {
                Intent intent = new Intent(this, typeof(RegisterUI));
                this.StartActivity(intent);
            };

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