using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub
{
    interface IPublisher
    {
         void Send(Message newMessage, PubSubServer myServer);
    }
}
