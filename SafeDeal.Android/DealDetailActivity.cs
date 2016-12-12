using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SafeDeal.Core.Service;
using SafeDeal.Core.Model;
using Android.Graphics;
using SafeDeal.Android.Utility;

namespace SafeDeal.Android
{
    [Activity(Label = "Deal Details")]
    public class DealDetailActivity : Activity
    {
        private ImageView dealImageView;
        private TextView dealNameTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private TextView priceTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;

        private Deal selectedDeal;
        private DealDataService dataService;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DealDetailView);


            //early demos
            DealDataService dataService = new DealDataService ();
          

            var selectedDealId = Intent.Extras.GetInt("selectedDealId");
            selectedDeal = dataService.GetDealById(selectedDealId);

            // Create your application here

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            dealImageView = FindViewById<ImageView>(Resource.Id.dealImageView);
            dealNameTextView = FindViewById<TextView>(Resource.Id.dealNameTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {

            dealNameTextView.Text = selectedDeal.Name;
            shortDescriptionTextView.Text = selectedDeal.ShortDescription;
            descriptionTextView.Text = selectedDeal.Description;
            priceTextView.Text = "Price: " + selectedDeal.Price;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedDeal.ImagePath + ".jpg");

            dealImageView.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
            //orderButton.Click += (object sender, EventArgs e) =>
            //{
            //    var amount = Int32.Parse(amountEditText.Text);
            //    AddToCart(selectedDeal, amount);

            //    var dialog = new AlertDialog.Builder(this);
            //    dialog.SetTitle("Confirmation");
            //    dialog.SetMessage("Your hot dog has been added to your cart!");
            //    dialog.Show();

            //    //var intent = new Intent();
            //    //intent.PutExtra("selectedDealId", selectedDeal.DealId);
            //    //intent.PutExtra("amount", amount);

            //    //SetResult(Result.Ok, intent);

            //    //this.Finish();
            //};

            //var amount = Int32.Parse(amountEditText.Text);
            //var dialog = new AlertDialog.Builder(this);
            //dialog.SetTitle("Confirmation");
            //dialog.SetMessage("Your hot dog has been added to your cart!");
            //dialog.Show();
            //cancelButton.Click += (object sender, System.EventArgs e) =>
            //{
            //    SetResult(Result.Canceled);

            //    this.Finish();
            //};

        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = Int32.Parse(amountEditText.Text);
            var intent = new Intent();
            intent.PutExtra("selectedDealId", selectedDeal.DealId);
            intent.PutExtra("amount", amount);
            SetResult(Result.Ok, intent);
            this.Finish();
            //cancelButton.Click += (object sender, System.EventArgs e) =>
            //{
            //    SetResult(Result.Canceled);

            //    this.Finish();
            //};

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }


        public void AddToCart(Deal deal, int amount)
        {
            CartDataService cartDataService = new CartDataService();
            cartDataService.AddCartItem(deal, amount);
        }

    }
}