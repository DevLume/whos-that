using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Whos_that
{
    public class GuiMessageManager
    {
        public delegate void TransmitMessage(HttpResponseMessage m, Context con);

        public void TransmitHttpMessage(HttpResponseMessage mesg, Context contxt)
        {
            var tmesg = mesg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1]
                        {
                        '"'
                        });
            Toast.MakeText(contxt, tmesg, ToastLength.Long).Show();
        }
    }
}