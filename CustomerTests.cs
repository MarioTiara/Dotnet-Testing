using Xunit;
namespace Dotnet_UnitTest
{
    public class CustomerTests
    {
        Customer customer => new Customer();
        [Fact]
        public void CheckNameNotEmpty(){
            Assert.NotNull(customer.Name);
            Assert.False(string.IsNullOrEmpty(customer.Name));
        }

        
    }
}