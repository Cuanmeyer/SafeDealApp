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
            dealListView.ItemClick += dealListView_ItemClick;
        }

        private void dealListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var deal = allDeals[e.Position];
            var intent = new Intent();
            intent.SetClass(this, typeof(DealDetailActivity));
            intent.PutExtra("selectedDealId", deal.DealId);
            StartActivityForResult(intent, 100);

        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedDeal = dealDataService.GetDealById(data.GetIntExtra("selectedDealId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format("You've added {0} time(s) the {1}", data.GetIntExtra("amount", 0), selectedDeal.Name));
                dialog.Show();
            }
        }

    }
}