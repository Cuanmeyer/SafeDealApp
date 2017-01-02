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
using Java.IO;
using Android.Provider;
using SafeDeal.Android.Utility;
using Android.Graphics;

namespace SafeDeal.Android
{
    [Activity(Label = "TakePictureActivity")]
    public class TakePictureActivity : Activity
    {

        private ImageView safeDealPictureImageView;
        private Button takePictureButton;
        private Button createUserBtn;
        private Button ViewSlidingTabBtn;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.TakePictureView);

            FindViews();

            HandleEvents();

            imageDirectory = new File(global::Android.OS.Environment.GetExternalStoragePublicDirectory(
                global::Android.OS.Environment.DirectoryPictures), "SafeDeals");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }
        }

        private void FindViews()
        {
            safeDealPictureImageView = FindViewById<ImageView>(Resource.Id.safeDealPictureImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
            ViewSlidingTabBtn = FindViewById<Button>(Resource.Id.tabBtn);
            createUserBtn = FindViewById<Button>(Resource.Id.createUserBtn);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
            ViewSlidingTabBtn.Click += ViewSlidingTabBtn_Click;
            createUserBtn.Click += createUserBtn_Click;
        }

        private void createUserBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CreateUserActivity));
            StartActivity(intent);
        }

        private void ViewSlidingTabBtn_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SlidingTabActivity));
            StartActivity(intent);
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, String.Format("PhotoForSafeDeal_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, global::Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            int height = safeDealPictureImageView.Height;
            int width = safeDealPictureImageView.Width;
            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

            if (imageBitmap != null)
            {
                safeDealPictureImageView.SetImageBitmap(imageBitmap);
                imageBitmap = null;
            }

            //required to avoid memory leaks!
            GC.Collect();
        }
    }
    }
