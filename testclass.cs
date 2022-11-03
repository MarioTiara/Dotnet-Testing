using Xunit;

namespace Dotnet_UnitTest
{
    
public class testcass {
    Calculator calculator= new Calculator();
    [Fact]
    public void PassingAddTest(){
        Assert.Equal(4, calculator.Add(2,2));
    }

    [Fact]
    public void FailingTest(){
        Assert.NotEqual(5, calculator.Add(2,4));
    }
}
}