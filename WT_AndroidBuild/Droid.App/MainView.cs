using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;


using Droid.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Binding.BindingContext;
using Droid.App.Fragments;

namespace Droid.App
{
    [Activity(Label = "Main Screen")]
    public class MainView : MvxAppCompatActivity<MainScreenViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private SupportFragment currentFragment;
        private CreateTestUI createTestUI;
        private GuessUI guessUI;
        private StatisticsUI statisticsUI;
        private FriendlistUI friendlistUI; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            //handle fragments

            createTestUI = new CreateTestUI();
            guessUI = new GuessUI();
            statisticsUI = new StatisticsUI();
            friendlistUI = new FriendlistUI();

            //createTestUI = (CreateTestUI)SupportFragmentManager.FindFragmentById(Resource.Id.ct1);
            createTestUI.ViewModel = ((MainScreenViewModel)ViewModel).Crt;

            //guessUI = (GuessUI)SupportFragmentManager.FindFragmentById(Resource.Id.ct2);
            guessUI.ViewModel = ((MainScreenViewModel)ViewModel).Grt;

            //statisticsUI = (StatisticsUI)SupportFragmentManager.FindFragmentById(Resource.Id.ct3);
            statisticsUI.ViewModel = ((MainScreenViewModel)ViewModel).Srt;

            friendlistUI.ViewModel = ((MainScreenViewModel)ViewModel).Frt;
            
            var transaction = SupportFragmentManager.BeginTransaction();
            currentFragment = friendlistUI;
            transaction.Add(Resource.Id.fragment_container, createTestUI, "createTestUI");
            transaction.Add(Resource.Id.fragment_container, guessUI, "guessUI");
            transaction.Add(Resource.Id.fragment_container, statisticsUI, "statisticsUI");
            transaction.Add(Resource.Id.fragment_container, friendlistUI, "friendlistUI");
            transaction.Hide(guessUI);
            transaction.Hide(statisticsUI);
            transaction.Hide(createTestUI);
            transaction.Commit();
        }
        private void ShowFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out, Resource.Animation.slide_in, Resource.Animation.slide_out);
            transaction.Hide(currentFragment);
            transaction.Show(fragment);
            transaction.Commit();
            currentFragment = fragment;
        }
        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.nav_create_test)
            {
                ShowFragment(createTestUI);
            }
            else if (id == Resource.Id.nav_guess)
            {
                ShowFragment(guessUI);
            }
            else if (id == Resource.Id.nav_statistics)
            {
                ShowFragment(statisticsUI);
            }
            else if (id == Resource.Id.nav_friendlist)
            {
                ShowFragment(friendlistUI);
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }  
}