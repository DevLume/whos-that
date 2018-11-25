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
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Droid.App
{
    [MvxFragmentPresentation(typeof(GuessTestFragmentViewModel), Resource.Id.fragment_container)]
    [Register("Droid.App.GuessUI")]
    public class GuessUI : MvxFragment<GuessTestFragmentViewModel>
    {
        public GuessUI() { }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here

            GuessTestFragmentViewModel.OnRequestSent += GuessTestViewModel_OnGuessTestRequestSent;
            GuessTestFragmentViewModel.OnWrongInput += GuessTestViewModel_OnWrongInput;
        }

        private void GuessTestViewModel_OnWrongInput(object sender, WrongInputEventArgs e)
        {
            Toast.MakeText(this.Activity, e.response, ToastLength.Long).Show(); // Or give photo of him
        }

        private void GuessTestViewModel_OnGuessTestRequestSent(object sender, GuessTestRequestArgs e)
        {
            if (e.authorName == "" || e.authorName == null)
            {
                Toast.MakeText(this.Activity, "Write user name first!", ToastLength.Long).Show(); 
            }
            else if (e.title == "" || e.title == null)
            {
                Toast.MakeText(this.Activity, "Write user test name first!", ToastLength.Long).Show(); 
            }
            else
            {             
                Intent intent = new Intent(this.Activity, typeof(GuessTestView));
                this.StartActivity(intent);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.guess_test_fragment, null);
        }
    }
}