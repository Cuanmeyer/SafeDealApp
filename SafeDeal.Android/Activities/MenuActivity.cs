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
using SafeDeal.Android.Activities;

namespace SafeDeal.Android
{
    [Activity(Label = "Safe Deal")]
    public class MenuActivity : Activity
    {
        private Button orderButton;
        private Button cartButton;
        private Button aboutButton;
        private Button mapButton;
        private Button takePictureButton;
        private Button closeToYouBtn;
        private Button membersOnlyBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            FindViews();

            HandleEvents();

            // Create your application here
        }
        private void FindViews()
        {
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            cartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
            closeToYouBtn = FindViewById<Button>(Resource.Id.closeToYouBtn);
            membersOnlyBtn = FindViewById<Button>(Resource.Id.membersOnlyBtn);

        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            aboutButton.Click += AboutButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
            mapButton.Click += MapButton_Click;
            closeToYouBtn.Click += closeToYouBtn_Click;
            membersOnlyBtn.Click += membersOnlyBtn_Click;
            cartButton.Click += cartButton_Click;

        }

        private void cartButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SpecialDealActivity));
            StartActivity(intent);
        }

        private void membersOnlyBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MembersActivity));
            StartActivity(intent);
        }

        private void closeToYouBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CloseToYouActivity));
            StartActivity(intent);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DealMapActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }
        private void OrderButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DealMenuActivity));
            StartActivity(intent);
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }
    }
}