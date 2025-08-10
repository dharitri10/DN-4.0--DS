using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerCommTests
{
    public class CustomerCommTests
    {
        [Test]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailIsSent()
        {
            // Arrange
            var mockMailSender = new Mock<IMailSender>();
            mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var customerComm = new CustomerComm(mockMailSender.Object);

            // Act
            var result = customerComm.SendMailToCustomer();

            // Assert
            Assert.IsTrue(result);  // ✅ Now this will work
        }
    }
}
