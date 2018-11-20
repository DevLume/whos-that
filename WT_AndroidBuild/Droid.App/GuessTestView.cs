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
using Droid.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Droid.App
{
    [Activity(Label ="Guess Test Screen")]
    public class GuessTestView : MvxActivity<GuessTestViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.guessTestView);

            GuessTestViewModel.OnWrongInput += GuessTestViewModel_OnWrongInputEntered;
            GuessTestViewModel.OnTestEnd += GuessTestViewModel_OnTestEnd;
        }

        private void GuessTestViewModel_OnWrongInputEntered(object sender, WrongInputEventArgs e)
        {
            Toast.MakeText(this, e.response, ToastLength.Long).Show();
        }

        private void GuessTestViewModel_OnTestEnd(object sender, EndTestEventArgs e)
        {
            Toast.MakeText(this, e.response + " "+ e.correctAnswerCount + " of "+ e.questionCount, ToastLength.Long).Show();
        }
    }
}