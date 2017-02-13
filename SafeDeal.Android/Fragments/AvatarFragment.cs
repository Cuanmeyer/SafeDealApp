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
using SafeDeal.Android.Models;

namespace SafeDeal.Android.Fragments
{
    public class AvatarFragment : Fragment
    {

        const string ArgEdit = "EDIT";
        const string KeySelectedAvatarIndex = "selectedAvatarIndex";

        Player player;
        EditText firstName;
        EditText lastInitial;
        Avatar selectedAvatar = Avatar.One;
        View selectedAvatarView;
        GridView avatarGrid;
        DoneFab doneFab;
        bool edit;

        public static AvatarFragment Create(bool edit)
        {
            var args = new Bundle();
            args.PutBoolean(ArgEdit, edit);
            var fragment = new AvatarFragment();
            fragment.Arguments = args;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            if (savedInstanceState != null)
            {
                var savedAvatarIndex = savedInstanceState.GetInt(KeySelectedAvatarIndex);
                selectedAvatar = (Avatar)savedAvatarIndex;
            }
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View contentView = inflater.Inflate(Resource.Layout.fragment_sign_in, container, false);
            EventHandler<View.LayoutChangeEventArgs> handler = null;
            handler = ((sender, e) => {
                ((View)sender).LayoutChange -= handler;
                SetUpGridView(View);
            });
            contentView.LayoutChange += handler;
            return contentView;
        }
    }
}