using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace test2
{
    [Activity(Label = "test2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        View v;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            
            Button button = FindViewById<Button>(Resource.Id.btn);
           
            // calling required function using delegate
            button.Click += delegate {
                
                btnClick(v); 
               
            };          
        }

        private void Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        

        public void btnClick(View view)
        {
            var ET = FindViewById<EditText>(Resource.Id.et1).Text;
            var ET2 = FindViewById<EditText>(Resource.Id.et2).Text;
            string et_Username = ET.ToString();
            string et_Password = ET2.ToString();
           
            string Username = "Aqib";
            string Password = "123";
            if (Username.Equals(et_Username)&& Password.Equals(et_Password))
            {
                var Login = new Intent(this, typeof(Login));
                Login.PutExtra("MyData", "Data from Login");
                StartActivity(Login);
            }
            else
            {
                Toast.MakeText(this,"login failed", ToastLength.Long).Show();
            }

        }
    }
}

