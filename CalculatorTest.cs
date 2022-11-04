using Xunit;
using System.Collections.Generic;

namespace Dotnet_UnitTest{
    
    public class CalculatorTest{
        Calculator calculator= new Calculator();

        [Fact]
        void PassingAddTest(){
            int actual=calculator.Add(3,2);
            int expected=5;
            Assert.Equal(actual,expected);
        }

        [Fact]
        void AddDouble_GivenTwoDoubleValyes_returnDouble(){
            var result = calculator.AddDouble(1.23, 3.50);
            var expected=4.73;
            Assert.Equal(expected,result,2); //2 is precission 
        }

        //Assert Collection => Check if 0 is not in "calculator.FiboNumbers"
        [Fact]
        public void FiboDoesNotIncludeZero(){
            Assert.All(calculator.FiboNumbers, n=>Assert.NotEqual(0,n));
        }

        [Fact]
        public void FibonaciIncludes13(){
            Assert.Contains(13, calculator.FiboNumbers);
        }

        [Fact]
        public void FinboDoesNotContain()
        {
            Assert.DoesNotContain(4,calculator.FiboNumbers);
        }

        [Fact]
        public void CheckCollection()
        {
            var expectedCollection = new List<int> () {1,1,2,3,5,8,13};
            Assert.Equal(expectedCollection, calculator.FiboNumbers);
            
        }
    }
}