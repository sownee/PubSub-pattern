
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PubSub.Tests
{
    [TestClass()]
    public class SubscriberTests
    {
        [TestMethod()]
        public void SubscriberTest()
        {
            //Arrange
            Publisher danceGenrePublisher = new Publisher();
            Publisher rockGenrePublisher = new Publisher();
      
            Subscriber allGenreSubscriber = new Subscriber();
            Subscriber danceGenreSubscriber = new Subscriber();

            PubSubServer server = new PubSubServer();

            Message danceGenreMessage = new Message();
            danceGenreMessage.genre = "Dance";
            danceGenreMessage.description = "Dance music is popular in clubs.";

            Message rockGenreMessage = new Message();
            rockGenreMessage.genre = "Rock";
            rockGenreMessage.description = "Rock music was very popular in the 90's";


            //Act
            danceGenrePublisher.Send(danceGenreMessage, server);
            rockGenrePublisher.Send(rockGenreMessage, server);

            allGenreSubscriber.Listen("Dance");
            allGenreSubscriber.Listen("Rock");
            allGenreSubscriber.Listen("Country");

            danceGenreSubscriber.Listen("Dance");

            server.subscribers.Add(allGenreSubscriber);
            server.subscribers.Add(danceGenreSubscriber);

            server.Next();

            //Assert
            Assert.IsNotNull(server.subscribers);
            CollectionAssert.AllItemsAreNotNull(server.subscribers);
            Assert.IsTrue(server.subscribers.Any());
        }

       
    }
}
