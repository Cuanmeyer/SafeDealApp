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
    class CreateUserEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public CreateUserEventArgs(string name, string number)
        {
            Name = name;
            Number = number;
        }
    }

    class CreateUserDialog : DialogFragment
    {
        private Button mButtonCreateUser;
        private EditText txtName;
        private EditText txtNumber;

        public event EventHandler<CreateUserEventArgs> OnCreateUser;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_create_user, container, false);
            mButtonCreateUser = view.FindViewById<Button>(Resource.Id.btnCreateUser);
            txtName = view.FindViewById<EditText>(Resource.Id.txtName);
            txtNumber = view.FindViewById<EditText>(Resource.Id.txtNumber);

            mButtonCreateUser.Click += mButtonCreateUser_Click;
            return view;

        }

        void mButtonCreateUser_Click(object sender, EventArgs e)
        {
            if (OnCreateUser != null)
            {
                //Broadcast event
                OnCreateUser.Invoke(this, new CreateUserEventArgs(txtName.Text, txtNumber.Text));
            }

            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}