using System;
using Android.Support.V4.App;
using System.Text;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Util;

namespace BindingLibTestApp
{
	public sealed class TestFragment : Fragment 
	{
		private const string KEY_CONTENT = "TestFragment:Content";

		public static TestFragment NewInstance(String content) 
		{
			TestFragment fragment = new TestFragment();

			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < 20; i++) 
			{
				builder.Append(content).Append(" ");
			}
			builder.Remove(builder.Length - 1, 1);
			fragment.mContent = builder.ToString();

			return fragment;
		}

		private string mContent = "???";

		public override void OnCreate(Bundle savedInstanceState) 
		{
			base.OnCreate(savedInstanceState);

			if ((savedInstanceState != null) && savedInstanceState.ContainsKey(KEY_CONTENT)) 
			{
				mContent = savedInstanceState.GetString(KEY_CONTENT);
			}
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			TextView text = new TextView(Activity);
			text.Gravity = GravityFlags.Center;
			text.Text = mContent;
			text.SetTextSize(ComplexUnitType.Px, 20 * Resources.DisplayMetrics.Density);
			text.SetPadding(20, 20, 20, 20);

			LinearLayout layout = new LinearLayout(Activity);
			layout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);
			layout.SetGravity(GravityFlags.Center);
			layout.AddView(text);

			return layout;
		}

		public override void OnSaveInstanceState(Bundle outState) 
		{
			base.OnSaveInstanceState(outState);

			outState.PutString(KEY_CONTENT, mContent);
		}
	}
}
