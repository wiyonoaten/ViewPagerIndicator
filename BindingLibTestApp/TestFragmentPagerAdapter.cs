using Android.Support.V4.App;

namespace BindingLibTestApp
{
	class TestFragmentPagerAdapter : FragmentPagerAdapter
	{
		protected static readonly string[] CONTENT = new string[] { "This", "Is", "A", "Test", };

		private int mCount = CONTENT.Length;

		public TestFragmentPagerAdapter(FragmentManager fm)
			: base(fm)
		{
		}

		public override Fragment GetItem(int position) 
		{
			return TestFragment.NewInstance(CONTENT[position % CONTENT.Length]);
		}

		public override int Count 
		{
			get { return mCount; }
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted(int position) 
		{
			return new Java.Lang.String(TestFragmentPagerAdapter.CONTENT[position % CONTENT.Length]);
		}

		public void SetCount(int count) 
		{
			if (count > 0 && count <= 10) 
			{
				mCount = count;
				NotifyDataSetChanged();
			}
		}
	}
}
