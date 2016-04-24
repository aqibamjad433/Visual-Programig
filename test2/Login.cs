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

namespace test2
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        View v;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login_Success);
            base.OnCreate(savedInstanceState);
            string text = Intent.GetIntExtra("MyData",0).ToString();

            // Create your application here

            Button bLogout = FindViewById<Button>(Resource.Id.btn_Logout);

            bLogout.Click += delegate
            {
                BtnClick(v);
            };
        }

        public void BtnClick(View v)
        {
            var logout = new Intent(this, typeof(MainActivity));
            logout.PutExtra("Logging Out", "Going back to Login");
            StartActivity(logout);

        }
    }
}