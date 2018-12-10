using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Droid.Core;
using Droid.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using static Android.App.ActionBar;

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

           
            LayoutInflater vi = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);

            View v = vi.Inflate(Resource.Layout.friendlist_fragment, null);

            ViewGroup vg = (ViewGroup)v;
            for (int i = 0; i < 3; i++)
            {
                vg.AddView(AddFriendLayout(i));
            }

           
            return this.BindingInflate(Resource.Layout.friendlist_fragment, vg);
        }

        public GridLayout AddFriendLayout(int givenID)
        {         
            GridLayout.Spec gridColumn = GridLayout.InvokeSpec(16, GridLayout.BaselineAlighment);
            GridLayout.Spec gridRow = GridLayout.InvokeSpec(16, GridLayout.BaselineAlighment);

            GridLayout.LayoutParams gl = new GridLayout.LayoutParams(gridRow, gridColumn);          
                  
            GridLayout gridLayout = new GridLayout(Context);
            gridLayout.LayoutParameters = gl;
           /* gridLayout.Orientation = GridOrientation.Horizontal;
            gridLayout.Id = givenID;*/
           
            GridLayout.Spec imageColumn = GridLayout.InvokeSpec(0, GridLayout.BaselineAlighment);
            GridLayout.Spec imageRow = GridLayout.InvokeSpec(0, GridLayout.BaselineAlighment);

            GridLayout.Spec usernameColumn = GridLayout.InvokeSpec(0, GridLayout.BaselineAlighment);
            GridLayout.Spec usernameRow = GridLayout.InvokeSpec(0, GridLayout.BaselineAlighment);

            GridLayout.Spec messageColumn = GridLayout.InvokeSpec(0, GridLayout.BaselineAlighment);
            GridLayout.Spec messageRow = GridLayout.InvokeSpec(0, GridLayout.BaselineAlighment);

            GridLayout.LayoutParams usernameLayout = new GridLayout.LayoutParams(usernameRow, usernameColumn);
            usernameLayout.SetMargins(256, 32, 0, 0);

            GridLayout.LayoutParams messageLayout = new GridLayout.LayoutParams(messageRow, messageColumn);
            messageLayout.SetMargins(248,112,0,0);

            GridLayout.LayoutParams imageLayout = new GridLayout.LayoutParams(imageRow, imageColumn);
            imageLayout.SetMargins(48,32,0,0);
            imageLayout.Width = 196;
            imageLayout.Height = 196;
           
            ImageView imageView = new ImageView(Context);        
            imageView.LayoutParameters = imageLayout;
                    
            TextView usernameView = new TextView(Context);
            usernameView.SetTextColor(Color.White);
            usernameView.SetTextSize(Android.Util.ComplexUnitType.Px, 64);
            usernameView.LayoutParameters = usernameLayout;

            TextView messageView = new TextView(Context);
            messageView.SetTextColor(Color.White);
            messageView.SetTextSize(Android.Util.ComplexUnitType.Px, 48);
            messageView.LayoutParameters = messageLayout;
         
            gridLayout.AddView(imageView, imageLayout);
            gridLayout.AddView(usernameView, usernameLayout);
            gridLayout.AddView(messageView, messageLayout);

            return gridLayout;
        }
    }
}