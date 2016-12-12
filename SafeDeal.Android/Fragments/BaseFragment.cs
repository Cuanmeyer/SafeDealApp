using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SafeDeal.Core.Model;
using SafeDeal.Core.Service;

namespace SafeDeal.Android.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected DealDataService dealDataService;
        protected List<Deal> deals;

        public BaseFragment()
        {
            dealDataService = new DealDataService();
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.dealListView);
        }

        protected void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var deal = deals[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(DealDetailActivity));
            intent.PutExtra("selectedDealId", deal.DealId);

            StartActivityForResult(intent, 100);
        }

      
    }
}