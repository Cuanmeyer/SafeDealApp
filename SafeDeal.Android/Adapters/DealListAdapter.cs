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
using SafeDeal.Core.Model;
using SafeDeal.Android.Utility;

namespace SafeDeal.Android.Adapters
{
   public class DealListAdapter : BaseAdapter<Deal>
    {
        List<Deal> items;
        Activity context;

        public DealListAdapter(Activity context, List<Deal> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Deal this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + item.ImagePath + ".jpg");
            if (convertView == null)
            {
                convertView = context.LayoutInflater.Inflate(Resource.Layout.DealRowView, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.dealNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "R " + item.Price;
            convertView.FindViewById<ImageView>(Resource.Id.dealImageView).SetImageBitmap(imageBitmap);

            return convertView;
        }

        }
}