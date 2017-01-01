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
    [Activity(Label = "MembersActivity")]
    public class MembersActivity : Activity
    {
        private Button mbtnSignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.LoginScreen);

            // Create your application here
          

            mbtnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            mbtnSignUp.Click += MbtnSignUp_Click;
        }


        void MbtnSignUp_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_sign_up signUpDialog = new Dialog_sign_up();
            signUpDialog.Show(transaction, "dialog fragment");

        }
    }
}