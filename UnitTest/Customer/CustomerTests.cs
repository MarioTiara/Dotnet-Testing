using Xunit;
using System;
using Dotnet_UnitTest.Models;
using Dotnet_UnitTest.UnitTest.customer;

namespace Dotnet_UnitTest
{
    [Collection("Customer")]
    public class CustomerTests:IClassFixture<CustomerFixture>
    {
        private readonly  CustomerFixture  _customerFixture;
        public CustomerTests(CustomerFixture  customerFixture){
            _customerFixture=customerFixture;
        }

        [Fact]
        public void CheckNameNotEmpty(){
            Assert.NotNull(_customerFixture.customer.Name);
            Assert.False(string.IsNullOrEmpty(_customerFixture.customer.Name));
        }
        [Fact]
        public void CheckAgeIsInrange(){
            Assert.InRange(_customerFixture.customer.Age, 25,40);
        }

        [Fact]
        public void CheckAgeIsNotInrange(){
            Assert.NotInRange(_customerFixture.customer.Age, 40,50);
        }
        
        [Fact]
        public void GetOrdersBynNameNotNull(){
           var exceptionDetails= Assert.Throws<ArgumentException>(()=>_customerFixture.customer.GetOrdersByName(null));
           Assert.Equal("String is null or empty", exceptionDetails.Message);
        }

        [Fact]
        public void LoyalCustomerForOrdersG100(){
            var customer =CustomerFactory.CreateCustomerInstance(102);
            var loyalCustomer=Assert.IsType<LoyalCustomer>(_customerFixture.customer);
            Assert.Equal(10, loyalCustomer.Discount);
        }
    }
}