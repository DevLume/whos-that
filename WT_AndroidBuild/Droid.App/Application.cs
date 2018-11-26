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
using Droid.Core.Services.ViewEvent;
using Droid.Core.ViewModels;
using MvvmCross;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace Droid.App
{
    [Application]
    public class Application : MvxAppCompatApplication<MvxAppCompatSetup<LoginApp>, LoginApp>
    {
        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }
    }
}