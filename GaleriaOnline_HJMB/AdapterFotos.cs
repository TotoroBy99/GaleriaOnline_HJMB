using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using GaleriaOnline_HJMB.com.somee.albumwebharvin;
using Java.Lang;

namespace GaleriaOnline_HJMB
{
    internal class AdapterFotos : BaseAdapter
    {
        List<SWPhoto> imagenes = new List<SWPhoto>();
        Activity Context;

        public AdapterFotos(List<SWPhoto> photos, Activity galeria_Activity)
        {
            imagenes = photos;
            Context = galeria_Activity;
        }

        public override int Count => imagenes.Count();

        public override Object GetItem(int position)
        {
            throw new System.NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = imagenes[position];
            Bitmap bitmap = BitmapFactory.DecodeByteArray(item.Img, 0, item.Img.Length);
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
            view = Context.LayoutInflater.Inflate(Resource.Layout.ItemGallery_Layout, null);
            view.FindViewById<ImageView>(Resource.Id.imageView).SetImageBitmap(bitmap);
            return view;
        }
    }
}