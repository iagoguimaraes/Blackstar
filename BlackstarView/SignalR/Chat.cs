using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BlackstarView.SignalR
{
    public class Chat : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}