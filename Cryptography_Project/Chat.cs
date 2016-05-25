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
using System.Net.Sockets;
using System.Net;

namespace Cryptography_Project
{
    [Activity(Label = "Chat")]
    public class Chat : Activity
    {
        //TextView f1;
        //TextView f2;
        //Button btn_test;
        //int count = 0;


        string input_key1;
        Socket sck;
        //EndPoints
        EndPoint epLocal, epRemote;
        //Buffer used for reciving and sending messages
        byte[] buffer;

        View v;
        IPHostEntry host;



        EditText message;
        Button send;
        Button btn_encrypt;
        EditText et_Encrypt;
        Button btn_decrypt;
        EditText et_Decrypt;
        TextView ChatBox;

        Button Pre_Connect;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Chat);
            base.OnCreate(savedInstanceState);


            string text = Intent.GetIntExtra("MyData", 0).ToString();
            string text2 = Intent.GetStringExtra("MyData") ?? "Data not available";

            // Create your application here

            message = FindViewById<EditText>(Resource.Id.et_message);
            send = FindViewById<Button>(Resource.Id.btn_send);
            btn_encrypt = FindViewById<Button>(Resource.Id.btn_Encrypt);
            btn_decrypt = FindViewById<Button>(Resource.Id.btn_Decrypt);
            et_Encrypt = FindViewById<EditText>(Resource.Id.et_Encrypt);
            et_Decrypt = FindViewById<EditText>(Resource.Id.et_Decrypt);
            ChatBox = FindViewById<TextView>(Resource.Id.Chat);
            Pre_Connect = FindViewById<Button>(Resource.Id.Pre_Connect);



            Pre_Connect.Click += delegate
            {

            };


            //btn_test = FindViewById<Button>(Resource.Id.btn_test);
            //f1 = FindViewById<TextView>(Resource.Id.textView2);
            //f2 = FindViewById<TextView>(Resource.Id.textView3);

            //f2.Visibility =ViewStates.Invisible;

            //btn_test.Click += delegate
            //{
            //    btn_Click();

            //};
        }

        //public void btn_Click()
        //{
        //    if(count == 0)
        //    {
        //        f1.Visibility = ViewStates.Visible;
        //        f2.Visibility = ViewStates.Invisible;
        //        count++;

        //    }
        //    else if (count == 1)
        //    {
        //        f1.Visibility = ViewStates.Invisible;
        //        f2.Visibility = ViewStates.Visible;
        //        count = 0;
        //    }

        //}



        //private void buttonConnect_Click(View view)
        //{

        //    if (port_local.Text != "" && port_friend.Text != "")
        //    {
        //        if (port_local.Text != port_friend.Text)
        //        {
        //            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //instantiating New socket
        //            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

        //            //Binding Socket
        //            epLocal = new IPEndPoint(IPAddress.Parse(ip_local.Text), Convert.ToInt32(port_local.Text));
        //            sck.Bind(epLocal);
        //            //Connecting to Remote IP
        //            epRemote = new IPEndPoint(IPAddress.Parse(ip_friend.Text), Convert.ToInt32(port_friend.Text));
        //            sck.Connect(epRemote);
        //            //MessageBox.Show("Connected succssfully. Click ok to proceed further.");

        //            // Connect_panel.Hide();
        //            //Listening the Specific Port
        //            buffer = new byte[1500];
        //            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

        //            var Chat = new Intent(this, typeof(Chat));
        //            Chat.PutExtra("MyData", "Data from IP");
        //            StartActivity(Chat);

        //            //  sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);



        //        }
        //        else
        //        {
        //            // MessageBox.Show("You can't enter same ports. Try again. ");
        //            Toast.MakeText(this, "You can't enter same ports", ToastLength.Long).Show();
        //            port_local.Text = "";
        //            port_friend.Text = "";
        //        }
        //    }
        //    else
        //    {
        //        Toast.MakeText(this, "Ports are Empty", ToastLength.Long).Show();
        //    }
        //}



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
        //        if (receivedmessage != null)
        //        {
        //           // CHAT_HISTORY.Items.Add("Friend: " + receivedmessage);
        //            //MessageBox.Show("Message Received Successfully.");
        //        }
        //        else
        //        {
        //            // CHAT_HISTORY.Items.Add("Freind: Server not responding check your connection.");
        //        }
        //        //Again Calling Function "MessageCallback"
        //        buffer = new byte[1500];
        //        sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(" Error 1: " + ex.ToString());

        //    }
        //}
    }
}
 