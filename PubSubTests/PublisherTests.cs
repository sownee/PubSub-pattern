using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PubSub.Tests
{
    [TestClass()]
    public class PublisherTests
    {
        [TestMethod()]
        public void PublisherTest()
        {
            //Arrange
            Publisher danceGenrePublisher = new Publisher();
            Publisher rockGenrePublisher = new Publisher();
       
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

 
            //Assert
            Assert.IsNotNull(server.buffer);
            CollectionAssert.AllItemsAreNotNull(server.buffer);
            Assert.IsTrue(server.buffer.Any());

        }

       
    }
}
