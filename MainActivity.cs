using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Views.InputMethods;
using System;
using Android.Views;

namespace Whos_that
{
    [Activity(Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnRegister;
        LinearLayout linearLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnRegister.Click += (object sender, System.EventArgs e) =>
            {
                Intent intent = new Intent(this, typeof(registerUI));
                this.StartActivity(intent);
            };

            linearLayout = FindViewById<LinearLayout>(Resource.Id.loginLinearLayout);
            linearLayout.Click += LinearLayout_Click;
        }

        private void LinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}