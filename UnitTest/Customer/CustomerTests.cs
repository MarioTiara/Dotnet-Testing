using Xunit;
using System;
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
        [Fact]
        public void CheckAgeIsInrange(){
            Assert.InRange(customer.Age, 25,40);
        }

        [Fact]
        public void CheckAgeIsNotInrange(){
            Assert.NotInRange(customer.Age, 40,50);
        }
        
        [Fact]
        public void GetOrdersBynNameNotNull(){
           var exceptionDetails= Assert.Throws<ArgumentException>(()=>customer.GetOrdersByName(null));
           Assert.Equal("String is null or empty", exceptionDetails.Message);
        }

        [Fact]
        public void LoyalCustomerForOrdersG100(){
            var customer =CustomerFactory.CreateCustomerInstance(102);
            var loyalCustomer=Assert.IsType<LoyalCustomer>(customer);
            Assert.Equal(10, loyalCustomer.Discount);
        }
    }
}