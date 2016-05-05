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
        byte[] buffer;
        IPAddress ipAddress;
        EditText et1, et2;
        IPEndPoint eplocal;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login_Success);
            base.OnCreate(savedInstanceState);

            string text = Intent.GetIntExtra("MyData", 0).ToString();
            EditText et1 = FindViewById<EditText>(Resource.Id.IP);
            EditText et2 = FindViewById<EditText>(Resource.Id.IP2);
            Button b_Connect = FindViewById<Button>(Resource.Id.btn_Connect);
            ipAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0];

            //Create your application here

            et1.Text = ipAddress.ToString();
            et2.Text = ipAddress.ToString();





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
            eplocal = new IPEndPoint(ipAddress, val1);
            listenSocket.Bind(eplocal);



            IPEndPoint epRemote = new IPEndPoint(ipAddress, val2);
            listenSocket.Connect(epRemote);
            Toast.MakeText(this, "Bind successfully", ToastLength.Long).Show();
           // listenSocket.Connect(eplocal);
           // buffer = new byte[1500];
            //listenSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref eplocal, new AsyncCallback(MessageCallBack), buffer);

            var Connect = new Intent(this, typeof(Chat));
            Connect.PutExtra("MyData", "Data from Login");
            StartActivity(Connect);


        }

        //private void MessageCallBack(IAsyncResult aResult)
        //{

        //    try
        //    {

        //        byte[] receiveddata = new byte[1500];
        //        receiveddata = ((byte[])aResult.AsyncState);
        //        //Converting Byte Array to string
        //        ASCIIEncoding aEncoding = new ASCIIEncoding();
        //        string receivedmessage = aEncoding.GetString(receiveddata);
        //        //Adding message to list-of-messages

        //        //Again Calling Function "MessageCallback"
        //        buffer = new byte[1500];
        //        sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
        //    }
        //    catch (Exception ex)
        //    {
        //        // MessageBox.Show(" Error 1: " + ex.ToString());
        //        throw;
        //    }
        //}


    }
}
