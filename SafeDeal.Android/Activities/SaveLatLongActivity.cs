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

namespace SafeDeal.Android.Activities
{
    [Activity(Label = "SaveLatLongActivity")]
    public class SaveLatLongActivity : Activity
    {

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LatLongLayout);
            var editText = FindViewById<EditText>(Resource.Id.editText);

            var textView = FindViewById<TextView>(Resource.Id.textView);

            editText.TextChanged += (object sender, global::Android.Text.TextChangedEventArgs e) => {

                textView.Text = e.Text.ToString();

            };
        }
    }
}