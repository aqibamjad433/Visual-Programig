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
using Android.Net.Wifi;
using System.Net;

namespace test2
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login_Success);
            base.OnCreate(savedInstanceState);
           
            string text = Intent.GetIntExtra("MyData",0).ToString();
            EditText et1 = FindViewById<EditText>(Resource.Id.IP);
            EditText et2 = FindViewById<EditText>(Resource.Id.IP2);
           // EditText et2 = FindViewById<EditText>(Resource.Id.port2);

            
            // Create your application here
            string hostname = Dns.GetHostName();
            string IP = Dns.GetHostByName(hostname).AddressList[0].ToString();
            et1.Text = IP;

            string hostname2 = Dns.GetHostName();
            string IP2 = Dns.GetHostByName(hostname).AddressList[0].ToString();
            et2.Text = IP2;
            


        }

      
    }
}