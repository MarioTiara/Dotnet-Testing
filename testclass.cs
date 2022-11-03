using Xunit;

namespace Dotnet_UnitTest
{
    
public class testcass {
    [Fact]
    public void PassingAddTest(){
        Assert.Equal(5, Program.Add(2,2));
    }
}
}