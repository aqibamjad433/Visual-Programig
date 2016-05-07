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
            byte[] decryptedText;
            plainText = ByteConverter.GetBytes(message.Text);



            RSA_CB.Click += delegate
            {
                encryptedText = Encryption(plainText, RSA.ExportParameters(false), false);
                encrypt.Text = ByteConverter.GetString(encryptedText);

                //decryptedText = Decryption(encryptedText, RSA.ExportParameters(true), false);
                //decrypt.Text = ByteConverter.GetString(decryptedText);
            

                //Toast.MakeText(this, "ye le", ToastLength.Long).Show();
            };

           

            //send.Click += delegate
            //{
            //    Send_Button_Click(v);
            //};


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


        private void RSASendbutton_Click(object sender, EventArgs e)
        {
            //Convert String into ByteArray
            ASCIIEncoding aEncoding = new ASCIIEncoding();
            byte[] sending_message = new byte[1500];
        }


    }
    }

