using Xunit;
using System;

namespace Dotnet_UnitTest.UnitTest.customer
{
    [CollectionDefinition("Customer")]
    public class CustomerFixtureCollection:ICollectionFixture<CustomerFixture>
    {
        
        
    }
}