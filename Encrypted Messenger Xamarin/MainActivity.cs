using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Encrypted_Messenger_Xamarin
{
    [Activity(Label = "Encrypted_Messenger_Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        string Username = "Aqib";
        string Password = "123";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btn);
            TextView TV = FindViewById<TextView>(Resource.Id.Username);
            TextView TV2 = FindViewById<TextView>(Resource.Id.Password);
            EditText ET = FindViewById<EditText>(Resource.Id.et1);
            EditText ET2 = FindViewById<EditText>(Resource.Id.et2);

            if(Username == "Aqib" && Password == "123")
            {
               Inten
            }


            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        
    }
}

