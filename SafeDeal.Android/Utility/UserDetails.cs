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

namespace SafeDeal.Android.Utility
{
    public static class UserDetails
    {
        public static  string Name { get; set; }
        public static  string Number { get; set; }
        public static  string Email { get; set; }
    }
}