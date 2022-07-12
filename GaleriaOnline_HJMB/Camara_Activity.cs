using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GaleriaOnline_HJMB
{
    [Activity(Label = "Camara_Activity")]
    public class Camara_Activity : Activity
    {
        com.somee.albumwebharvin.AlbumOnlineWS servicio = new com.somee.albumwebharvin.AlbumOnlineWS();
        string email;
        Button btnphoto, btnsave;
        ImageView image;
        Bitmap bitmap;
        const int TAKE_PHOTO_REQUEST_CODE = 100;
        bool Setomounafotojeje = false;

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {            
            base.OnActivityResult(requestCode, resultCode, data);

            // We check if the user did not cancel taking the picture and if our result code is the same
            if (resultCode == Result.Ok && requestCode == TAKE_PHOTO_REQUEST_CODE)
            {
                bitmap = (Bitmap)data.Extras.Get("data") as Bitmap;
                image.SetImageBitmap(bitmap);
                Setomounafotojeje = true;
            }            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Camara_Layout);

            email = GaleriaOnline_HJMB.MainActivity.email.Text;            
            image = FindViewById<ImageView>(Resource.Id.imagencamara);

            btnphoto = FindViewById<Button>(Resource.Id.btnccamara);
            btnphoto.Click += Btnphoto_Click; ;

            btnsave = FindViewById<Button>(Resource.Id.btncguardar);
            btnsave.Click += Btnsave_Click;
            

        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            if(Setomounafotojeje == false)
            {
                Toast.MakeText(this, "No se ha tomado ninguna foto para almacenar", ToastLength.Short).Show();
            }
            else
            {
                using (var stream = new MemoryStream())
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                    var bitmapData = stream.ToArray();
                    if (servicio.AddImg(bitmapData, 1, email))
                    {
                        Toast.MakeText(this, "La imagen se almaceno correctamente", ToastLength.Short).Show();
                    }
                }
            }
        }

        private void Btnphoto_Click(object sender, EventArgs e)
        {            
            //Create an intent to start the camera app
            var intent = new Intent(MediaStore.ActionImageCapture);
            //Check if they are apps to handle taking photos
            if (intent.ResolveActivity(PackageManager) != null)
            {
                //Start the activity so that it will return a result
                StartActivityForResult(intent, TAKE_PHOTO_REQUEST_CODE);
            }

            //Intent intent = new Intent(MediaStore.ActionImageCapture);
            //StartActivityForResult(intent, 0);
        }
    }
}