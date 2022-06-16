using PhoneBook.Application.Contacts;
using PhoneBook.Domain.Contacts.Exceptions;
using PhoneBook.Domain.Helpers;
using Xunit;

namespace PhoneBookTest
{

    public class PhoneValidatorTest : IClassFixture<PhoneValidator>
    {
        private readonly PhoneValidator _phoneValidator;

        public PhoneValidatorTest(PhoneValidator phoneValidator)
        {
            _phoneValidator = phoneValidator;

        }
        
        [Theory]
        [InlineData("+98 (914) 123")]
        [InlineData("+98 (914) 1234")]
        [InlineData("+98 (914) 12345")]
        [InlineData("+98 (914) 123456")]
        [InlineData("+98 (914) 1234567")]
        [InlineData("+98 (914) 12345678")]
        [InlineData("+98 (914) 123456789")]
        [InlineData("+98 (914) 12345678901")]
        [InlineData("+98 (914) 123456789012")]
        [InlineData("+98 (914) 1234567890123")]
        [InlineData("+98 (914) 12345678901234")]
        [InlineData("+98 (914) 123456789012345")]
        [InlineData("+98 914 123")]
        [InlineData("+98 914 1234")]
        [InlineData("+98 914 12345")]
        [InlineData("+98 914 123456")]
        [InlineData("+98 914 1234567")]
        [InlineData("+98 914 12345678")]
        [InlineData("+98 914 123456789")]
        [InlineData("+98 914 12345678901")]
        [InlineData("+98 914 123456789012")]
        [InlineData("+98 914 1234567890123")]
        [InlineData("+98 914 12345678901234")]
        [InlineData("+98 914 123456789012345")]
        [InlineData("+98 914 123 456789012345")]
        [InlineData("+98 914 1234 56789012345")]
        [InlineData("+98 914 12345 6789012345")]
        [InlineData("+98 914 123456 789012345")]
        [InlineData("+98 914 1234567 89012345")]
        [InlineData("+98 914 12345678 9012345")]
        [InlineData("+98 914 123456789 012345")]
        [InlineData("+98 914 1234567890 12345")]
        [InlineData("+98 914 12345678901 2345")]
        [InlineData("+98 914 123456789012 345")]
        [InlineData("+98 914 1234567890123 45")]
        [InlineData("+98 914 12345678901234 5")]
        [InlineData("+98 914 123-456789012345")]
        [InlineData("+98 914 1234-56789012345")]
        [InlineData("+98 914 12345-6789012345")]
        [InlineData("+98 914 123456-789012345")]
        [InlineData("+98 914 1234567-89012345")]
        [InlineData("+98 914 12345678-9012345")]
        [InlineData("+98 914 123456789-012345")]
        [InlineData("+98 914 1234567890-12345")]
        [InlineData("+98 914 12345678901-2345")]
        [InlineData("+98 914 123456789012-345")]
        [InlineData("+98 914 1234567890123-45")]
        [InlineData("+98 914 12345678901234-5")]
        [InlineData("+98 (913) 8767876-545")]
        [InlineData("+1 (923) 745466 987")]
        [InlineData("+98 91435 125-456789012345")]
        




        public void ShouldAcceptValidPhone(string phoneNumber)
        {
            ///Act
            var exception = Record.Exception(() => _phoneValidator.ValidatePhoneNumber(phoneNumber));

            //Assert
            Assert.Null(exception);

        }

        [Theory]
        [InlineData("98 (914) 123")]
        [InlineData("+98 (914)1234")]
        [InlineData("+98(914) 12345")]
        [InlineData("+9812 (914) 123456")]
        [InlineData("+98123 (914) 123456")]
        [InlineData("+981234 (914) 1234567")]
        [InlineData("+98 (914 123456789")]
        [InlineData("+98 914) 12345678901")]
        [InlineData("+98 914 1 23456789012345")]
        [InlineData("+98 914 12 3456789012345")]
        [InlineData("+98 914 1-23456789012345")]
        [InlineData("+98 914 12-3456789012345")]
        [InlineData("+98 914355 12-3456789012345")]
        [InlineData("+ 914355 12-3456789012345")]



        public void ShouldThrowException(string phoneNumber)
        {
            // Act & Assert
            Assert.Throws<PhoneNumberFormatIsNotValidException>(() => _phoneValidator.ValidatePhoneNumber(phoneNumber));

            

        }
    }
}