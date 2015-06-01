using System;

using Android.App;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using ViewPagerIndicator;

namespace BindingLibTestApp
{
	[Activity(Label = "ViewPagerIndicatorBindingLibTestApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : FragmentActivity
	{
		private static readonly Random RANDOM = new Random();

		private TestFragmentPagerAdapter mAdapter;
		private ViewPager mPager;
		private IPageIndicator mTitleIndicator;
		private IPageIndicator mCircleIndicator;

		protected override void OnCreate(Bundle savedInstanceState) 
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			mAdapter = new TestFragmentPagerAdapter(SupportFragmentManager);

			mPager = FindViewById<ViewPager>(Resource.Id.pager);
			mPager.Adapter = mAdapter;

			mTitleIndicator = FindViewById<TitlePageIndicator>(Resource.Id.titleIndicator);
			mTitleIndicator.SetViewPager(mPager);

			mCircleIndicator = FindViewById<CirclePageIndicator>(Resource.Id.circleIndicator);
			mCircleIndicator.SetViewPager(mPager);
		}
	}
}
