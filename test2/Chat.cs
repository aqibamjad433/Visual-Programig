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
        View v;
        Socket sck;
        EndPoint epLocal, epRemote;
        byte[] buffer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Chat);
            base.OnCreate(savedInstanceState);
            EditText message = FindViewById<EditText>(Resource.Id.message);
            Button send = FindViewById<Button>(Resource.Id.send);
            CheckBox RSA_CB = FindViewById<CheckBox>(Resource.Id.RSA);
            EditText encrypt = FindViewById<EditText>(Resource.Id.encrypt);
            EditText decrypt = FindViewById<EditText>(Resource.Id.decrypt);
            TextView Chat_Box = FindViewById<TextView>(Resource.Id.ChatBox);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            byte[] plainText;
            byte[] encryptedText;
            plainText = ByteConverter.GetBytes(message.Text);


            RSA_CB.Click += delegate
            {
                encryptedText = Encryption(plainText, RSA.ExportParameters(false), false);
                encrypt.Text = ByteConverter.GetString(encryptedText);
            };
            
            
        }

        static public byte[] Encryption (byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(RSAKey); encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
            }
            return encryptedData;
        }
          


            
        }
    }

