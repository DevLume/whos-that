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
    [Activity(Label ="Create Test Screen")]
    public class CreateTestView : MvxActivity<CreateTestViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.createTestView);

            CreateTestViewModel.OnCreateTest += CreateTestViewModel_OnTestCreated;
            CreateTestViewModel.OnAddQuestion += CreateTestViewModel_OnQuestionAdded;
            CreateTestViewModel.OnTestCreated += CreateTestViewModel_OnTempActivityRequest;
        }

        private void CreateTestViewModel_OnTempActivityRequest(object sender, ShowTempActivityArgs e)
        {
            base.OnBackPressed();         
        }
            
        private void CreateTestViewModel_OnQuestionAdded(object sender, AddQuestionEventArgs e)
        {            
            Toast.MakeText(this,e.response,ToastLength.Long).Show();
        }

        private void CreateTestViewModel_OnTestCreated(object sender, CreateTestEventArgs e)
        {            
            Toast.MakeText(this, e.response, ToastLength.Long).Show();
        }
    }
}