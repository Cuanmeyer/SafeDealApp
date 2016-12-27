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
using Android.Locations;
using Android.Util;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;


namespace SafeDeal.Android
{
    [Activity(Label = "Close To You ")]
    public class CloseToYouActivity : Activity, IOnMapReadyCallback, global::Android.Gms.Maps.GoogleMap.IInfoWindowAdapter, global::Android.Gms.Maps.GoogleMap.IOnInfoWindowClickListener
    {
        LocationManager locMgr;
        private GoogleMap mMap;
        private MapFragment mapFragment;
        string tag = "CloseToYouActivity";
        Button button;
        TextView latitude;
        TextView longitude;
        TextView provider;
        private Button btnNormal;
        private Button btnHybrid;
        private Button btnSat;
        private Button btnTerrain;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
           // Log.Debug(tag, "OnCreate called");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.CloseToYouView);
            btnNormal = FindViewById<Button>(Resource.Id.btnNormal);
            btnHybrid = FindViewById<Button>(Resource.Id.btnHybrid);
            btnSat = FindViewById<Button>(Resource.Id.btnSat);
            btnTerrain = FindViewById<Button>(Resource.Id.btnTerrain);
            CreateMapFragment();
            btnNormal.Click += btnNormal_Click;
            btnHybrid.Click += btnHybrid_Click;
            btnSat.Click += btnSat_Click;
            btnTerrain.Click += btnTerrain_Click;


        }

        private void btnTerrain_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeTerrain;
        }

        private void btnSat_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeSatellite;
        }

        private void btnHybrid_Click(object sender, EventArgs e)
        {
            mMap.MapType = GoogleMap.MapTypeHybrid;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            //var googleMapOptions = new GoogleMapOptions()
            //         .InvokeMapType(GoogleMap.MapTypeNormal)
            //         .InvokeZoomControlsEnabled(true)
            //         .InvokeCompassEnabled(true);

            mMap.MapType = GoogleMap.MapTypeNormal;
        }

        private void CreateMapFragment()
        {
            //mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

            if (mMap == null)
            {
                var googleMapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.mapFrameLayout).GetMapAsync(this);
                //FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                //mapFragment = MapFragment.NewInstance(googleMapOptions);
                //fragmentTransaction.Add(Resource.Id.mapFrameLayout, mapFragment, "map");
                //fragmentTransaction.Commit();
            }
        }

    //    protected override void OnStart()
    //    {
    //        base.OnStart();
    //        Log.Debug(tag, "OnStart called");
    //    }

    //    // OnResume gets called every time the activity starts, so we'll put our RequestLocationUpdates
    //    // code here, so that 
    //    protected override void OnResume()
    //    {
    //        base.OnResume();
    //        Log.Debug(tag, "OnResume called");

    //        // initialize location manager
    //        locMgr = GetSystemService(Context.LocationService) as LocationManager;

    //        button.Click += delegate {
    //            button.Text = "Location Service Running";

    //            // pass in the provider (GPS), 
    //            // the minimum time between updates (in seconds), 
    //            // the minimum distance the user needs to move to generate an update (in meters),
    //            // and an ILocationListener (recall that this class impletents the ILocationListener interface)
    //            if (locMgr.AllProviders.Contains(LocationManager.NetworkProvider)
    //                && locMgr.IsProviderEnabled(LocationManager.NetworkProvider))
    //            {
    //                locMgr.RequestLocationUpdates(LocationManager.NetworkProvider, 2000, 1, this);
    //            }
    //            else
    //            {
    //                Toast.MakeText(this, "The Network Provider does not exist or is not enabled!", ToastLength.Long).Show();
    //            }


    //            // Comment the line above, and uncomment the following, to test 
    //            // the GetBestProvider option. This will determine the best provider
    //            // at application launch. Note that once the provide has been set
    //            // it will stay the same until the next time this method is called

    //            /*var locationCriteria = new Criteria();

				//locationCriteria.Accuracy = Accuracy.Coarse;
				//locationCriteria.PowerRequirement = Power.Medium;

				//string locationProvider = locMgr.GetBestProvider(locationCriteria, true);

				//Log.Debug(tag, "Starting location updates with " + locationProvider.ToString());
				//locMgr.RequestLocationUpdates (locationProvider, 2000, 1, this);*/
    //        };
    //    }

    //    protected override void OnPause()
    //    {
    //        base.OnPause();

    //        // stop sending location updates when the application goes into the background
    //        // to learn about updating location in the background, refer to the Backgrounding guide
    //        // http://docs.xamarin.com/guides/cross-platform/application_fundamentals/backgrounding/


    //        // RemoveUpdates takes a pending intent - here, we pass the current Activity
    //        locMgr.RemoveUpdates(this);
    //        Log.Debug(tag, "Location updates paused because application is entering the background");
    //    }

    //    protected override void OnStop()
    //    {
    //        base.OnStop();
    //        Log.Debug(tag, "OnStop called");
    //    }

    //    public void OnLocationChanged(global::Android.Locations.Location location)
    //    {
    //        Log.Debug(tag, "Location changed");
    //        latitude.Text = "Latitude: " + location.Latitude.ToString();
    //        longitude.Text = "Longitude: " + location.Longitude.ToString();
    //        provider.Text = "Provider: " + location.Provider.ToString();
    //    }
    //    public void OnProviderDisabled(string provider)
    //    {
    //        Log.Debug(tag, provider + " disabled by user");
    //    }
    //    public void OnProviderEnabled(string provider)
    //    {
    //        Log.Debug(tag, provider + " enabled by user");
    //    }
    //    public void OnStatusChanged(string provider, Availability status, Bundle extras)
    //    {
    //        Log.Debug(tag, provider + " availability has changed to " + status.ToString());
    //    }

        //private class LocalMapReady : Java.Lang.Object
        //{
        //    public GoogleMap Map { get; private set; }

        //    public event EventHandler MapReady;

        //    public void OnMapReady(GoogleMap googleMap)
        //    {


        //        Map = googleMap;
        //        var handler = MapReady;
        //        if (handler != null)
        //            handler(this, EventArgs.Empty);


        //    }
        //}

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            LatLng latlng = new LatLng(-33.567055, 18.494389);
            LatLng latlng1 = new LatLng(-33.36883518850191, 18.3829141035676);
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng,10);
            mMap.MoveCamera(camera);
         





            MarkerOptions options = new MarkerOptions()
            .SetPosition(latlng)
            .SetTitle("Atlantis")
            .SetSnippet("Check out Users Close To You")
            .Draggable(true);
            mMap.AddMarker(options);


            mMap.AddMarker(new MarkerOptions()
                .SetPosition(latlng1)
                .SetTitle("View User details"));

            //mMap.MarkerClick += mMap_MarkerClick;

            mMap.MarkerDragEnd += MMap_MarkerDragEnd;

            mMap.SetInfoWindowAdapter(this);
            mMap.SetOnInfoWindowClickListener(this);

        }

        //private void mMap_MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        //{
        //    LatLng pos = e.Marker.Position;
        //    mMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(pos, 10));
        //}

        private void MMap_MarkerDragEnd(object sender, GoogleMap.MarkerDragEndEventArgs e)
        {
            LatLng pos = e.Marker.Position;
            Console.WriteLine(pos.ToString());
        }

        public View GetInfoContents(Marker marker)
        {
            return null;
        }

        public View GetInfoWindow(Marker marker)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.info_window, null, false);
            view.FindViewById<TextView>(Resource.Id.txtName).Text = "Goza";
            view.FindViewById<TextView>(Resource.Id.txtAddress).Text = "39 Doffadil Street";
            view.FindViewById<TextView>(Resource.Id.txtHours).Text = "11:00am - 20:00pm";
            return view;
        }

        public void OnInfoWindowClick(Marker marker)
        {
            Console.WriteLine("window was clicked");
        }
    }
}