using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Droid.Core.Services
{
    public class GuiMessageManager
    {
        public delegate bool TransmitMessage(HttpResponseMessage m, out string message);

        public bool TransmitHttpMessage(HttpResponseMessage mesg, out string message)
        {
            var tmesg = mesg.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1]
                        {
                        '"'
                        });
            message = tmesg;
            if (mesg.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}