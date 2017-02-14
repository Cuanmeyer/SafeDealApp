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

namespace SafeDeal.Android
{
    [Activity(Label = "Welcome")]
    public class FirstMenuActivity : Activity
    {
        private Button firstmenuSignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FirstMenuLayout);
            // Create your application here
            firstmenuSignUp = FindViewById<Button>(Resource.Id.firstmenu_signupBtn);
            firstmenuSignUp.Click += firstmenuSignUp_Click;
        }

        private void firstmenuSignUp_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_sign_up signUpDialog = new Dialog_sign_up();
            signUpDialog.Show(transaction, "dialog fragment");
        }
    }
}