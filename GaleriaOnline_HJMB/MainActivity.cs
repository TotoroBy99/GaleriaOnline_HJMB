using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

using Android.Content;

namespace GaleriaOnline_HJMB
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static public EditText email;
        EditText contra;
        Button btnlogin, btnadd;
        com.somee.albumwebharvin.AlbumOnlineWS servicio = new com.somee.albumwebharvin.AlbumOnlineWS();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            email = (EditText)FindViewById(Resource.Id.editText1);
            contra = (EditText)FindViewById(Resource.Id.editText2);
            btnlogin = (Button)FindViewById(Resource.Id.button1);
            btnadd = (Button)FindViewById(Resource.Id.button2);

            btnlogin.Click += Btnlogin_Click;
            btnadd.Click += Btnadd_Click;

        }

        private void Btnadd_Click(object sender, System.EventArgs e)
        {
            if(servicio.IniciarSesion(email.Text, contra.Text))
            {
                Toast.MakeText(this, "Usuario ya existente", ToastLength.Short).Show();
            }
            else
            {
                servicio.CrearUsuario(email.Text, contra.Text);
                if(servicio.IniciarSesion(email.Text, contra.Text))
                {
                    Toast.MakeText(this, "Usuario creado exitosamente", ToastLength.Short).Show();
                }
                else
                    Toast.MakeText(this, "Error al crear usuario", ToastLength.Short).Show();
            }
        }

        private void Btnlogin_Click(object sender, System.EventArgs e)
        {
            if (servicio.IniciarSesion(email.Text, contra.Text))
            {
                Intent i = new Intent(this, typeof(MenuPrincipal_Activity));
                StartActivity(i);
            }
            else
            {
                Toast.MakeText(this, "Usuario no valido", ToastLength.Short).Show();
            }
        }
    }
}