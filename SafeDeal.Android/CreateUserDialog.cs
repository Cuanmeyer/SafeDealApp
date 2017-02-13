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
using System.Net;
using System.Collections.Specialized;

namespace SafeDeal.Android
{
    public class CreateUserEventArgs : EventArgs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string CreateUserEmail { get; set; }

        public CreateUserEventArgs(int id, string name, string number, string createUserEmail)
        {
            ID = id;
            Name = name;
            Number = number;
            CreateUserEmail = createUserEmail;
        }
    }

    class CreateUserDialog : DialogFragment
    {
        private Button mButtonCreateUser;
        private EditText txtName;
        private EditText txtNumber;
        private EditText txtCreateUserEmail;

        public event EventHandler<CreateUserEventArgs> OnCreateUser;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_create_user, container, false);
            mButtonCreateUser = view.FindViewById<Button>(Resource.Id.btnCreateUser);
            txtName = view.FindViewById<EditText>(Resource.Id.txtName);
            txtNumber = view.FindViewById<EditText>(Resource.Id.txtNumber);
            txtCreateUserEmail = view.FindViewById<EditText>(Resource.Id.txtCreateUserEmail);

            mButtonCreateUser.Click += mButtonCreateUser_Click;
            return view;

        }

        void mButtonCreateUser_Click(object sender, EventArgs e)
        {

            WebClient client = new WebClient();
            Uri uri = new Uri("https://safedeal.scm.azurewebsites.net/api/triggeredwebjobs/createUser/run");
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Name", txtName.Text);
            parameters.Add("Number", txtNumber.Text);
            parameters.Add("CreateUserEmail", txtCreateUserEmail.Text);
            client.UploadValuesCompleted += Client_UploadValuesCompleted;
            client.UploadValuesAsync(uri, parameters);

         
        }

         void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            Activity.RunOnUiThread(() =>
            {
                string id = Encoding.UTF8.GetString(e.Result);
                int newID = 0;
                int.TryParse(id, out newID);

                if (OnCreateUser != null)
                {
                    //Broadcast event
                    OnCreateUser.Invoke(this, new CreateUserEventArgs(newID, txtName.Text, txtNumber.Text, txtCreateUserEmail.Text));
                }

                this.Dismiss();
            });
          
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}