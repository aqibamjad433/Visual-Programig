using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Cryptography_Project
{
    [Activity(Label = "Cryptography_Project", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // 8080  9090
        

        Button btn_Login1;

        View v;


        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btn_Login1 = FindViewById<Button>(Resource.Id.btn_Login1);
           


            btn_Login1.Click += delegate
            {
                button_Click(v);
            };
            
        }

        public void button_Click(View view)
        {
            var Username = FindViewById<EditText>(Resource.Id.Username).Text;
            var Password = FindViewById<EditText>(Resource.Id.Password).Text;
            string ET = Username.ToString();
            string ET2 = Password.ToString();

            string et_Username = "Aqib";
            string et_Passowrd = "123";

            if(et_Username.Equals(ET) && et_Passowrd.Equals(ET2))
            {
                var IP = new Intent(this, typeof(IP));
                IP.PutExtra("MyData", "Data from Main");
                StartActivity(IP);
            }
            else
            {
                Toast.MakeText(this, "Login Failed", ToastLength.Long).Show();
                //DisplayAlert("Alert", "You have been alerted", "OK");
            }
        }

    }
}

