using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PubSub
{
    public class Subscriber : ISubscriber
    {
        public List<string> genres = new List<string>();
        public Queue<Message> myMessages = new Queue<Message>();


        public void Listen(string newGenre)
        {
            genres.Add(newGenre);
        }


        public void Print()
        {
            for (int i = 0; i < genres.Count; i++)
            {
                while (myMessages.Count != 0)
                {
                    Message newMessage = myMessages.Dequeue();
                    Console.WriteLine("Genre : " + newMessage.genre + "\n" + "Description : " + newMessage.description);
                    Console.WriteLine("");
                }
            }
        }

    }
}
