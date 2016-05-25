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
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;

namespace Cryptography_Project
{
    [Activity(Label = "IP")]
    public class IP : Activity
    {

        Button Connect;
        EditText ip_local;
        EditText port_local;

        EditText ip_friend;
        EditText port_friend;

        TextView T_ME;
        TextView T_IP;
        TextView T_Port;
        TextView T_IP2;
        TextView T_Port2;

        //Thread newThread = new Thread(new ThreadStart(M));



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

        byte[] plaintext;
        byte[] encryptedtext;






        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.IP);
            base.OnCreate(savedInstanceState);

            string text = Intent.GetIntExtra("MyData", 0).ToString();

            // Create your application here

            Connect = FindViewById<Button>(Resource.Id.btn_Connect);

            ip_local = FindViewById<EditText>(Resource.Id.IP_Local);
            port_local = FindViewById<EditText>(Resource.Id.Port_Local);

            ip_friend = FindViewById<EditText>(Resource.Id.IP_Remote);
            port_friend = FindViewById<EditText>(Resource.Id.Port_Remote);

            T_ME = FindViewById<TextView>(Resource.Id.T_ME);
            T_IP = FindViewById<TextView>(Resource.Id.T_IP);
            T_Port = FindViewById<TextView>(Resource.Id.T_Port);
            T_IP2 = FindViewById<TextView>(Resource.Id.T_IP2);
            T_Port2 = FindViewById<TextView>(Resource.Id.T_Port2);

            //sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //instantiating New socket
            //sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            message = FindViewById<EditText>(Resource.Id.et_message);
            send = FindViewById<Button>(Resource.Id.btn_send);
            btn_encrypt = FindViewById<Button>(Resource.Id.btn_Encrypt);
            btn_decrypt = FindViewById<Button>(Resource.Id.btn_Decrypt);
            et_Encrypt = FindViewById<EditText>(Resource.Id.et_Encrypt);
            et_Decrypt = FindViewById<EditText>(Resource.Id.et_Decrypt);
            ChatBox = FindViewById<TextView>(Resource.Id.Chat);



            ip_local.Text = get_local_IP();
            ip_friend.Text = get_local_IP();

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();


            plaintext = ByteConverter.GetBytes(message.Text);

            Connect.Click += delegate
            {
                buttonConnect_Click(v);
                Toast.MakeText(this, "Bind Successfull", ToastLength.Long).Show();

                //var Chat = new Intent(this, typeof(Chat));
                //Chat.PutExtra("MyData","Data from IP");
                //StartActivity(Chat);
            };

            send.Click += delegate
            {
                buttonSend_Click(v);
            };


            btn_encrypt.Click += delegate
            {
                encryptedtext = Encryption(plaintext, RSA.ExportParameters(false), false);
                et_Encrypt.Text = ByteConverter.GetString(encryptedtext);

                //Toast.MakeText(this, "ye le", ToastLength.Long).Show();
            };


            btn_decrypt.Click += delegate
            {
                byte[] decryptedText = Decryption(encryptedtext, RSA.ExportParameters(true), false);
                et_Decrypt.Text = ByteConverter.GetString(decryptedText);
                Toast.MakeText(this, "decrypted ", ToastLength.Long).Show();

            };


        }

        private string get_local_IP()
        {

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress IP in host.AddressList)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    return IP.ToString();
                }
            }
            return "127.0.0.1";
        }





        private void buttonConnect_Click(View view)
        {

            if (port_local.Text != "" && port_friend.Text != "")
            {
                if (port_local.Text != port_friend.Text)
                {
                    sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp); //instantiating New socket
                    sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                    //Binding Socket
                    epLocal = new IPEndPoint(IPAddress.Parse(ip_local.Text), Convert.ToInt32(port_local.Text));
                    sck.Bind(epLocal);
                    //Connecting to Remote IP
                    epRemote = new IPEndPoint(IPAddress.Parse(ip_friend.Text), Convert.ToInt32(port_friend.Text));
                    sck.Connect(epRemote);
                    //MessageBox.Show("Connected succssfully. Click ok to proceed further.");

                    // Connect_panel.Hide();
                    //Listening the Specific Port
                    buffer = new byte[1500];
                    sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

                    //var Chat = new Intent(this, typeof(Chat));
                    //Chat.PutExtra("MyData", "Data from IP");

                    //StartActivity(Chat);

                    //  sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);


                }
                else
                {
                    // MessageBox.Show("You can't enter same ports. Try again. ");
                    Toast.MakeText(this, "You can't enter same ports", ToastLength.Long).Show();
                    port_local.Text = "";
                    port_friend.Text = "";
                }
            }
            else
            {
                Toast.MakeText(this, "Ports are Empty", ToastLength.Long).Show();
            }
        }



        private void MessageCallBack(IAsyncResult aResult)
        {

            try
            {


                byte[] receiveddata = new byte[1500];
                receiveddata = ((byte[])aResult.AsyncState);
                //Converting Byte Array to string
                ASCIIEncoding aEncoding = new ASCIIEncoding();
                string receivedmessage = aEncoding.GetString(receiveddata);
                //Adding message to list-of-messages
                if (receivedmessage != null)
                {
                    // ChatBox.Items.Add("Friend: " + receivedmessage);
                    ChatBox.Text = string.Format(" " + ChatBox.Text + " Me : " + message.Text);
                    //MessageBox.Show("Message Received Successfully.");
                }
                else
                {
                    // ChatBox.Items.Add("Freind: Server not responding check your connection.");
                }
                //Again Calling Function "MessageCallback"
                buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);


            }
            catch (Android.Util.AndroidRuntimeException tht)
            {
                //Toast.MakeText(this, "" + tht.Source, ToastLength.Short).Show();
            }
            catch (Exception ee)
            {
                //Toast.MakeText(this, "" + ee.Source, ToastLength.Short).Show();

            }
    }


        private void buttonSend_Click(View view)
        {
            //Convert String into ByteArray
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingmessage = new byte[1500];
            //Sending Message
            sck.Send(sendingmessage);
            if (message.Text != null)
            {
                //Adding to list-box
                ChatBox.Text += string.Format("Me : " + message.Text);

                // MessageBox.Show("Message sent successfully.");
                message.Text = "";
            }
            else
            {
                //MessageBox.Show("You can't send an empty message. You must write something in the message textbox.");
            }
        }

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKey);
                encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
            }
            return encryptedData;
        }


        static public byte[] Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKey);
                decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
            }
            return decryptedData;
        }



        private void RSASendbutton_Click(object sender, EventArgs e)
        {
            //Convert String into ByteArray
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sendingmessage = new byte[1500];

            sendingmessage = aEncoding.GetBytes(et_Decrypt.Text);
            //Sending Message
            sck.Send(sendingmessage);
            //Adding to list-box
            ChatBox.Text += string.Format("Me : " + message.Text);
            //message.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

            //    ChatBox.Text = e.Text.ToString();

            //};
            message.Text = "";
            et_Encrypt.Text = "";
            et_Decrypt.Text = "";
            
        }



    }
}

