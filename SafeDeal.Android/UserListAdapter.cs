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
using Android.Graphics;

namespace SafeDeal.Android
{
    class UserListAdapter : BaseAdapter<User>
    {
        private Context mContext;
        private int mLayout;
        private List<User> mUsers;
        private Action<ImageView> mActionPicSelected;

        public UserListAdapter(Context context, int layout, List<User> users, Action<ImageView> picSelected)
        {
            mContext = context;
            mLayout = layout;
            mUsers = users;
            mActionPicSelected = picSelected;
        }

        public override User this[int position]
        {
            get { return mUsers[position]; }
        }

        public override int Count
        {
            get { return mUsers.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mLayout, parent, false);
            }

            row.FindViewById<TextView>(Resource.Id.txtName).Text = mUsers[position].Name;
            row.FindViewById<TextView>(Resource.Id.txtNumber).Text = mUsers[position].Number;

            ImageView pic = row.FindViewById<ImageView>(Resource.Id.imgPic);

            if (mUsers[position].Image != null)
            {
                pic.SetImageBitmap(BitmapFactory.DecodeByteArray(mUsers[position].Image, 0, mUsers[position].Image.Length));
            }

            pic.Click -= pic_Click;
            pic.Click += pic_Click;
            return row;
        }

        void pic_Click(object sender, EventArgs e)
        {
            //Picture has been clicked
            mActionPicSelected.Invoke((ImageView)sender);
        }
    }
}