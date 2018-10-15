using System;


namespace PubSub
{
    class Program
    {
        static void Main(string[] args)
        {

            Publisher danceGenrePublisher = new Publisher();
            Publisher rockGenrePublisher = new Publisher();
            Publisher countryGenrePublisher = new Publisher();

            Subscriber allGenreSubscriber = new Subscriber();
            Subscriber danceGenreSubscriber = new Subscriber();
            Subscriber rockGenreSubscriber = new Subscriber();
            


            PubSubServer server = new PubSubServer();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ******  Data Input is Genre of Music   ********");
            Console.WriteLine(" ******        DANCE, ROCK, COUNTRY     ********");
            Console.WriteLine(" ***** Subscribers will receive description ****");
            Console.WriteLine(" ***** of music Genre they subscribe too    ****");
            Console.ResetColor();
            Console.WriteLine(""); 
            Console.WriteLine("");


            //INPUT DATA
            Message danceGenreMessage = new Message();
            danceGenreMessage.genre = "Dance";
            danceGenreMessage.description = "Dance music is popular in clubs.";

            Message rockGenreMessage = new Message();
            rockGenreMessage.genre = "Rock";
            rockGenreMessage.description = "Rock music was very popular in the 90's";

            Message countryGenreMessage = new Message();
            countryGenreMessage.genre = "Country";
            countryGenreMessage.description = "You can line dance with country music";

            //Sender
            danceGenrePublisher.Send(danceGenreMessage, server);
            rockGenrePublisher.Send(rockGenreMessage, server);
            countryGenrePublisher.Send(countryGenreMessage, server);
          

            //receiver
            allGenreSubscriber.Listen("Dance");
            allGenreSubscriber.Listen("Rock");
            allGenreSubscriber.Listen("Country");


            danceGenreSubscriber.Listen("Dance");
            rockGenreSubscriber.Listen("Rock");


            server.subscribers.Add(allGenreSubscriber);
            server.subscribers.Add(danceGenreSubscriber);
            server.subscribers.Add(rockGenreSubscriber);


            server.Next();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The all Genre Subscriber has subscribed to the following");
            Console.ResetColor();
            //receiver print 
            allGenreSubscriber.Print();

            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Dance Genre Subscriber has subscribed to the following");
            Console.ResetColor();
            danceGenreSubscriber.Print();

            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Rock Genre Subscriber has subscribed to the following"); 
            Console.ResetColor();
            rockGenreSubscriber.Print();


            Console.ReadKey();

        }
    }
}
