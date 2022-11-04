using Xunit;


namespace Dotnet_UnitTest{
    
    public class CalculatorTest{
        Calculator calculator= new Calculator();

        [Fact]
        void PassingAddTest(){
            int actual=calculator.Add(3,2);
            int expected=5;
            Assert.Equal(actual,expected);
        }
    }
}