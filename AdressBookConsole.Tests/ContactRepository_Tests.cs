using Moq;
using Xunit;
using SharedCode;
using SharedCode.Models;
namespace AddressBookTests
{
    public class ContactRepositoryTests
    {
        [Fact]
        public void AddingContactShouldIncreaseContactList()
        {
            // Arrange
            var fileServiceMock = new Mock<IFileService>();
            var initialContacts = new List<Contact>();
            fileServiceMock.Setup(fs => fs.ReadFromFile(It.IsAny<string>())).Returns(initialContacts);

            var contactRepository = new ContactRepository(fileServiceMock.Object);
            var newContact = new Contact();

            // Act
            contactRepository.AddContact(newContact);

            // Assert
            var updatedContacts = contactRepository.GetAllContacts();
            Assert.Single(updatedContacts); 
            fileServiceMock.Verify(fs => fs.WriteToFile(It.IsAny<string>(), It.IsAny<List<Contact>>()), Times.Once);
        }

        [Fact]
        public void RemovingContactShouldDecreaseContactList()
        {
            // Arrange
            var fileServiceMock = new Mock<IFileService>();
            var initialContacts = new List<Contact> { new Contact() };
            fileServiceMock.Setup(fs => fs.ReadFromFile(It.IsAny<string>())).Returns(initialContacts);

            var contactRepository = new ContactRepository(fileServiceMock.Object);

            // Act
            contactRepository.RemoveContact("any@example.com");

            // Assert
            var updatedContacts = contactRepository.GetAllContacts();
            Assert.Empty(updatedContacts); 
            fileServiceMock.Verify(fs => fs.WriteToFile(It.IsAny<string>(), It.IsAny<List<Contact>>()), Times.Once);
        }
    }
}