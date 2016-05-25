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
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;


namespace test2
{
    [Activity(Label = "Chat")]
    public class Chat : Activity
    {
        int val1;
        Intent intent = new Intent();
        
        View v;
        IPAddress ipAddress;
        IPEndPoint eplocal;
        Socket listenSocket = new Socket(AddressFamily.InterNetwork,
             SocketType.Stream,
             System.Net.Sockets.ProtocolType.Tcp); //instantiating New socket
        
        EndPoint epLocal, epRemote;
        byte[] buffer;
        byte[] encryptedText = null;
        TextView ChatBox;

        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        byte[] plainText;

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ipAddress = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            val1 = int.Parse(intent.GetIntExtra("key", 0).ToString());
            IPEndPoint epRemote = new IPEndPoint(ipAddress, val1);
            SetContentView(Resource.Layout.Chat);
            base.OnCreate(savedInstanceState);
            EditText message = FindViewById<EditText>(Resource.Id.message);
            Button send = FindViewById<Button>(Resource.Id.send);
            Button btn_Encrypt = FindViewById<Button>(Resource.Id.btn_Encrypt);
            Button btn_Decrypt = FindViewById<Button>(Resource.Id.btn_Decrypt);
            EditText encrypt = FindViewById<EditText>(Resource.Id.encrypt);
            EditText decrypt = FindViewById<EditText>(Resource.Id.decrypt);
            ChatBox = FindViewById<TextView>(Resource.Id.ChatBox);


            
            
            plainText = ByteConverter.GetBytes(message.Text);



            btn_Encrypt.Click += delegate
            {
                encryptedText = Encryption(plainText, RSA.ExportParameters(false), false);
                encrypt.Text = ByteConverter.GetString(encryptedText);

                
           

                //Toast.MakeText(this, "ye le", ToastLength.Long).Show();
            };

            btn_Decrypt.Click += delegate
            {
                byte[] decryptedText = Decryption(encryptedText, RSA.ExportParameters(true), false);
                decrypt.Text = ByteConverter.GetString(decryptedText);


                Toast.MakeText(this, "ye le ", ToastLength.Long).Show();

            };



            send.Click += delegate
            {
                RSASendbutton_Click(v);
            };


        }

        static public byte[] Encryption (byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
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
                decryptedData = RSA.Decrypt(Data,DoOAEPPadding);
            }
            return decryptedData;
        }


        private void RSASendbutton_Click(View  view)
        {
            eplocal = new IPEndPoint(ipAddress, val1);
            listenSocket.Connect(epRemote);
            listenSocket.Bind(eplocal);
            //Convert String into ByteArray
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            encryptedText = Encryption(plainText, RSA.ExportParameters(false), false);
            byte[] sending_message = encryptedText;
            listenSocket.Send(sending_message);

            ChatBox.Text = ByteConverter.GetString(sending_message);

    //            Toast.MakeText(this, "ye le ", ToastLength.Long).Show();
        }


    }
    }

