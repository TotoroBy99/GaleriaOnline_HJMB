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

namespace GaleriaOnline_HJMB
{
    [Activity(Label = "Galeria_Activity")]
    public class Galeria_Activity : Activity
    {
        List<com.somee.albumwebharvin.SWPhoto> photos;
        GridView grid;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Galeria_Layout);
            string email = GaleriaOnline_HJMB.MainActivity.email.Text;

            com.somee.albumwebharvin.AlbumOnlineWS servicio = new com.somee.albumwebharvin.AlbumOnlineWS();
            
            photos = servicio.get_photos(email).ToList();
            grid = FindViewById<GridView>(Resource.Id.gridView1);
            grid.Adapter = new AdapterFotos(photos, this);
        }
    }
}