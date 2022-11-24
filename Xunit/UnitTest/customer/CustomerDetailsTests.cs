using Dotnet_UnitTest.Models;
using Xunit;
using Xunit.Abstractions;
namespace Dotnet_UnitTest.UnitTest.customer
{
    [Collection("Customer")]
    public class CustomerDetailsTests
    {
        private readonly CustomerFixture _customerFixture;
        public CustomerDetailsTests(CustomerFixture customerFixture){
            _customerFixture=customerFixture;
        }
        [Fact]
        [Trait("Category", "CustomerDetails")]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName(){
            Assert.Equal("Mario Pratama",_customerFixture.customer.GetFullName("Mario", "Pratama"));
        }
    }
}