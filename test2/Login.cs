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
using System.Net.Sockets;

namespace test2
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        View v;
        Socket sck;
        
        IPAddress ipAddress;
        EditText et1, et2;
        
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login_Success);
            base.OnCreate(savedInstanceState);
           
            string text = Intent.GetIntExtra("MyData",0).ToString();
            EditText et1 = FindViewById<EditText>(Resource.Id.IP);
            EditText et2 = FindViewById<EditText>(Resource.Id.IP2);
            Button b_Connect = FindViewById<Button>(Resource.Id.btn_Connect);
            ipAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0];
           
            //Create your application here
           
            et1.Text = ipAddress.ToString();
            et2.Text = ipAddress.ToString();


         

            // IPHostEntry host;
            // host = Dns.GetHostEntry(Dns.GetHostName());
            // foreach (IPAddress IP in host.AddressList)
            // {
            //     if (IP.AddressFamily == AddressFamily.InterNetwork)
            //     {
            //         et1.Text = IP.ToString();
            //     }
            // }
            //// et1.Text = "127.0.0.1";

            b_Connect.Click += delegate
            {
               btn_Click(v);
            };

        }

        public void btn_Click(View view)
        {
            var p1 = FindViewById<EditText>(Resource.Id.port1).Text;
            var p2 = FindViewById<EditText>(Resource.Id.port2).Text;

            // EditText et2 = FindViewById<EditText>(Resource.Id.port2);
            int val1 = Convert.ToInt32(p1);
            int val2 = Convert.ToInt32(p2);
          
            Socket listenSocket = new Socket(AddressFamily.InterNetwork,
                 SocketType.Stream,
                 System.Net.Sockets.ProtocolType.Tcp); //instantiating New socket
            IPEndPoint eplocal = new IPEndPoint(ipAddress, val1);
            listenSocket.Bind(eplocal);

            IPEndPoint epRemote = new IPEndPoint(ipAddress, val2);
            listenSocket.Connect(epRemote);
            Toast.MakeText(this, "Bind successfully", ToastLength.Long).Show();





        }
        

        }


    }
