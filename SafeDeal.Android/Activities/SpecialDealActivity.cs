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
using Android.Support.V7.App;
using Com.Romainpiel.Shimmer;

namespace SafeDeal.Android.Activities
{
    [Activity(Label = "SpecialDealActivity")]
    public class SpecialDealActivity : AppCompatActivity
    {
        ShimmerTextView textview;
        Shimmer shimmer;
        Button animateBtn;
        bool isStart = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SpecialDealsLayout);
            textview = FindViewById<ShimmerTextView>(Resource.Id.specialDealShineTextView);
            animateBtn = FindViewById<Button>(Resource.Id.shineBtn);
            shimmer = new Shimmer()
                .SetDuration(500)
                .SetStartDelay(300)
                .SetDirection(Shimmer.AnimationDirectionLtr);
            animateBtn.Click += delegate
            {

                if (!isStart)
                {
                    shimmer.Start(textview);
                    animateBtn.Text = "Stop Animation";
                }
                else
                {
                    shimmer.Cancel();
                    animateBtn.Text = "Start Animation";
                }
                isStart = !isStart;

            };
            
        }
    }
}