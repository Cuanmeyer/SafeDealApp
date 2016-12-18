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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace SafeDeal.Android
{
    [Activity(Label = "Hook up on the Deal Map")]
    public class DealMapActivity : Activity
    {

        private Button externalMapButton;
        private FrameLayout mapFrameLayout;
        private MapFragment mapFragment;
        private GoogleMap googleMap;
        private LatLng dealLocation;
        private LatLng dealLocation2;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            dealLocation = new LatLng(-33.567055, 18.494389);
            dealLocation2 = new LatLng(-33.567198, 18.491621);

            SetContentView(Resource.Layout.DealMapView);

            FindViews();

            HandleEvents();

            CreateMapFragment();

            UpdateMapView();
        }

        private void HandleEvents()
        {
            externalMapButton.Click += ExternalMapButton_Click;
        }

        private void ExternalMapButton_Click(object sender, EventArgs e)
        {
            global::Android.Net.Uri dealLocationUri = global::Android.Net.Uri.Parse("geo:-33.567055,18.494389");
            Intent mapIntent = new Intent(Intent.ActionView, dealLocationUri);
            StartActivity(mapIntent);
        }

        private void FindViews()
        {
            externalMapButton = FindViewById<Button>(Resource.Id.externalMapButton);
            mapFrameLayout = FindViewById<FrameLayout>(Resource.Id.mapFrameLayout);
        }

        private void UpdateMapView()
        {
            var mapReadyCallback = new LocalMapReady();

            mapReadyCallback.MapReady += (sender, args) =>
            {
                googleMap = (sender as LocalMapReady).Map;

                if (googleMap != null)
                {
                    MarkerOptions markerOptions = new MarkerOptions();
                    markerOptions.SetPosition(dealLocation);
                    markerOptions.SetTitle("Deals in Your Areaa");
                    markerOptions.SetSnippet("This dealer is available in your area");
                    googleMap.AddMarker(markerOptions);
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(dealLocation, 15);
                    googleMap.MoveCamera(cameraUpdate);


                    MarkerOptions markerOptions2 = new MarkerOptions();
                    markerOptions2.SetPosition(dealLocation2);
                    markerOptions2.SetTitle("othaer chiiiibbps");
                    googleMap.AddMarker(markerOptions2);
                    CameraUpdate cameraUpdate2 = CameraUpdateFactory.NewLatLngZoom(dealLocation2, 15);
                    googleMap.MoveCamera(cameraUpdate2);
                  
                }
            };

            mapFragment.GetMapAsync(mapReadyCallback);
        }

        private void CreateMapFragment()
        {
            mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

            if (mapFragment == null)
            {
                var googleMapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
                mapFragment = MapFragment.NewInstance(googleMapOptions);
                fragmentTransaction.Add(Resource.Id.mapFrameLayout, mapFragment, "map");
                fragmentTransaction.Commit();
            }
        }

        private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
        {
            public GoogleMap Map { get; private set; }

            public event EventHandler MapReady;

            public void OnMapReady(GoogleMap googleMap)
            {
               

                Map = googleMap;
                var handler = MapReady;
                if (handler != null)
                    handler(this, EventArgs.Empty);


            }
        }
    }
}