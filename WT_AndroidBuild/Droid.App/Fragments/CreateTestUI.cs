using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Droid.Core;
using Droid.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace Droid.App
{
    [MvxFragmentPresentation(typeof(CreateTestFragmentViewModel), Resource.Id.fragment_container)]
    [Register("Droid.App.CreateTestUI")]
    public class CreateTestUI : MvxFragment<CreateTestFragmentViewModel>
    {
        public CreateTestUI() { }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
           
            CreateTestFragmentViewModel.OnRequestSent += CreateTestViewModel_OnGetToCreateTestActivityArgsSent;
        }

        private void CreateTestViewModel_OnGetToCreateTestActivityArgsSent(object sender, GetToCreateTestActivityArgs e)
        {
            if (e.title == "" || e.title == null)
            {
                Toast.MakeText(Activity, "Create a name for your test first!", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(Activity, "Kek Cheburek", ToastLength.Long).Show();
                Intent intent = new Intent(this.Activity, typeof(CreateTestView)).SetFlags(ActivityFlags.ReorderToFront);
                this.StartActivity(intent);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.create_test_fragment, null);
        }
    }
}