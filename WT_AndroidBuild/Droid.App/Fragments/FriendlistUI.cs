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
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Droid.App.Fragments
{
    [MvxFragmentPresentation(typeof(FriendlistFragmentViewModel), Resource.Id.fragment_container)]
    [Register("Droid.App.FriendlistUI")]
    public class FriendlistUI : MvxFragment<FriendlistFragmentViewModel>
    {
        public FriendlistUI() { }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.friendlist_fragment, null);
        }
    }
}