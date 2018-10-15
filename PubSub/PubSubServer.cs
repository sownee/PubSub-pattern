using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub
{
    public  class PubSubServer
    {

        public Queue<Message> buffer = new Queue<Message>();
        public List<Subscriber>subscribers = new List<Subscriber>();

        public void Next()
        {
            while (buffer.Count != 0)
            {
                Message tempMessage = buffer.Dequeue();
                for (int i = 0; i < subscribers.Count; i++)
                {
                    for (int j = 0; j < subscribers[i].genres.Count; j++)
                    {
                        if (tempMessage.genre == subscribers[i].genres[j])
                        {
                            subscribers[i].myMessages.Enqueue(tempMessage);
                        }
                    }
                }
            }
           
        }
    }
}
