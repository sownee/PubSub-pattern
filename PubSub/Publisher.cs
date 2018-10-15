using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub
{
    public class Publisher :IPublisher
    {
        public void Send(Message newMessage, PubSubServer myServer)
        {
            myServer.buffer.Enqueue(newMessage);
        }
    }
}
