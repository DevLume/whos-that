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
    [Activity(Label = "registerUI")]
    public class registerUI : Activity
    {
        LinearLayout linearLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.register);

            linearLayout = FindViewById<LinearLayout>(Resource.Id.registerLinearLayout);
            linearLayout.Click += LinearLayout_Click;
        }

        private void LinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }
    }
}