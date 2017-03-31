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
using System.IO;
using Android.Graphics;
using System.Net;
using System.Collections.Specialized;
using SafeDeal.Android.Utility;

namespace SafeDeal.Android
{
    [Activity(Label = "CreateUserActivity")]
    public class CreateUserActivity : Activity
    {
        private ListView mListView;
        private BaseAdapter<User> mAdapter;
        private List<User> mUsers;
        private ImageView mSelectedPic;
        private Button _createUserButton;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateUserMain);

            mListView = FindViewById<ListView>(Resource.Id.createUserlistView);
            mUsers = new List<User>();

            Action<ImageView> action = PicSelected;

            mAdapter = new UserListAdapter(this, Resource.Layout.row_user, mUsers, action);
            mListView.Adapter = mAdapter;

            _createUserButton = FindViewById<Button>(Resource.Id.btnCreateUser);
            //_createUserButton.SetOnClickListener+= (sender, obj){

                // Get text from edittext
                UserDetails.Name = "this is test ";
            //} 


        }

        private void PicSelected(ImageView selectedPic)
        {
            mSelectedPic = selectedPic;
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            this.StartActivityForResult(Intent.CreateChooser(intent, "Selecte a Photo"), 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                Stream stream = ContentResolver.OpenInputStream(data.Data);
                mSelectedPic.SetImageBitmap(DecodeBitmapFromStream(data.Data,150,150));
            }
        }

        private Bitmap DecodeBitmapFromStream(global::Android.Net.Uri data, int requestedWidth, int requestedHeight)
        {
            //Decode with InJustDecodeBounds = true to check dimensions
            Stream stream = ContentResolver.OpenInputStream(data);
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InJustDecodeBounds = true;
            BitmapFactory.DecodeStream(stream);

            //Calculate InSamplesize
            options.InSampleSize = CalculateInSampleSize(options, requestedWidth, requestedHeight);

            //Decode bitmap with InSampleSize set
            stream = ContentResolver.OpenInputStream(data); //Must read again
            options.InJustDecodeBounds = false;
            Bitmap bitmap = BitmapFactory.DecodeStream(stream, null, options);
            return bitmap;
        }


        private int CalculateInSampleSize(BitmapFactory.Options options, int requestedWidth, int requestedHeight)
        {
            //Raw height and widht of image
            int height = options.OutHeight;
            int width = options.OutWidth;
            int inSampleSize = 1;

            if (height > requestedHeight || width > requestedWidth)
            {
                //the image is bigger than we want it to be
                int halfHeight = height / 2;
                int halfWidth = width / 2;

                while ((halfHeight / inSampleSize) > requestedHeight && (halfWidth / inSampleSize) > requestedWidth)
                {
                    inSampleSize *= 2;
                }

            }

            return inSampleSize;
        }




        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add:

                    CreateUserDialog dialog = new CreateUserDialog();
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();

                    //Subscribe to event
                    dialog.OnCreateUser += dialog_OnCreateUser;
                    dialog.Show(transaction, "Create a user");
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }

        void dialog_OnCreateUser(object sender, CreateUserEventArgs e)
        {
            mUsers.Add(new User() {ID = e.ID, Name = e.Name, Number = e.Number, CreateUserEmail = e.CreateUserEmail });
            mAdapter.NotifyDataSetChanged();
        }
    }
}
