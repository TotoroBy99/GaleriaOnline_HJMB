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
    [Activity(Label = "MenuPrincipal_Activity")]
    public class MenuPrincipal_Activity : Activity
    {
        string email;
        Button camara, galeria;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.MenuPrincipal_Layout);

            email = GaleriaOnline_HJMB.MainActivity.email.Text;
            camara = FindViewById<Button>(Resource.Id.button1);
            galeria = FindViewById<Button>(Resource.Id.button2);

            camara.Click += Camara_Click;
            galeria.Click += Galeria_Click;
        }

        private void Galeria_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Galeria_Activity));
            StartActivity(i);
        }

        private void Camara_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Camara_Activity));
            StartActivity(i);
        }
    }
}