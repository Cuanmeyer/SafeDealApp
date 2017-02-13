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
    [Activity(WindowSoftInputMode = SoftInput.AdjustPan, Label = "AvatarActivity")]
    public class AvatarActivity : Activity
    {
        const string ExtraEdit = "EDIT";
        public static void Start(Activity activity, bool edit, ActivityOptions options)
        {
            var starter = new Intent(activity, typeof(AvatarActivity));
            starter.PutExtra(ExtraEdit, edit);
            if (options == null)
            {
                activity.StartActivity(starter);
                activity.OverridePendingTransition(global::Android.Resource.Animation.SlideInLeft, global::Android.Resource.Animation.SlideOutRight);
            }
            else
            {
                activity.StartActivity(starter, options.ToBundle());
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.avatar_sign_In);
            var edit = Intent != null && Intent.GetBooleanExtra(ExtraEdit, false);
            if (savedInstanceState == null)
                FragmentManager.BeginTransaction().Replace(Resource.Id.sign_in_container, SignInFragment.Create(edit)).Commit();
        }
    }
}