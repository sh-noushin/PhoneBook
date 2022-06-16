using PhoneBook.Application.Contacts;
using Xunit;

namespace PhoneBookTest
{
    public class PhoneValidationServiceTest : IClassFixture<PhoneValidationService>
    {
        private readonly PhoneValidationService _phoneValidationService;

        public PhoneValidationServiceTest(PhoneValidationService phoneValidationService)
        {
            _phoneValidationService = phoneValidationService;
        }
        [Fact]
        public void PhoneNumberIsValid()
        {
            string phoneNumber = "+98 8666767676676";
            bool expectedRes = false;
            bool actualRes = _phoneValidationService.IsValidPhone(phoneNumber);
            Assert.Equal(expectedRes, actualRes);   

        }
    }
}