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
using SafeDeal.Core.Service;
using SafeDeal.Core.Model;
using SafeDeal.Android.Adapters;

namespace SafeDeal.Android
{
    [Activity(Label = "Deals Menu")]
    public class DealMenuActivity : Activity
    {

        private ListView dealListView;
        private List<Deal> allDeals;
        private DealDataService dealDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.DealMenuView);

            dealListView = FindViewById<ListView>(Resource.Id.dealListView);

           dealDataService = new DealDataService();

            allDeals = dealDataService.GetAllDeals();

            dealListView.Adapter = new DealListAdapter(this, allDeals);
        }
    }
}