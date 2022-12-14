using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.IO;
using Dotnet_UnitTest.Models;

namespace Dotnet_UnitTest.UnitTest.calculator{

    public class CalculatorFixture
    {
        public Calculator calc=> new Calculator();
        
        
    }
    
    public class CalculatorTest: IClassFixture<CalculatorFixture>  {
        private readonly CalculatorFixture _calculatorFixture;
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly MemoryStream memoryStream;
        public CalculatorTest (CalculatorFixture calculatorFixture, ITestOutputHelper testOutputHelper){
            _calculatorFixture=calculatorFixture;
            _testOutputHelper=testOutputHelper;
            _testOutputHelper.WriteLine("Constructor");
            memoryStream = new MemoryStream();
        }

        [Fact]
        void PassingAddTest(){
            int actual=_calculatorFixture.calc.Add(3,2);
            int expected=5;
            Assert.Equal(actual,expected);
        }

        [Fact]
        void AddDouble_GivenTwoDoubleValyes_returnDouble(){
            var result = _calculatorFixture.calc.AddDouble(1.23, 3.50);
            var expected=4.73;
            Assert.Equal(expected,result,2); //2 is precission 
        }

        //Assert Collection => Check if 0 is not in "calculator.FiboNumbers"
        [Fact]
        [Trait("Category","Fibo")]
        public void FiboDoesNotIncludeZero(){
            _testOutputHelper.WriteLine("FiboDoesNotIncludeZero");
            Assert.DoesNotContain(0, _calculatorFixture.calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void FibonaciIncludes13(){
            _testOutputHelper.WriteLine("FibonaciIncludes13");
            Assert.Contains(13, _calculatorFixture.calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void FinboDoesNotContain()
        {
            Assert.DoesNotContain(4,_calculatorFixture.calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void CheckCollection()
        {
            var expectedCollection = new List<int> () {1,1,2,3,5,8,13};
            Assert.Equal(expectedCollection, _calculatorFixture.calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category","IsOdd")]
        public void IsOdd_GivenOddValue_ReturnsTrue(){
            var result = _calculatorFixture.calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        [Trait("Category","IsOdd")]
        public void IsOdd_GivenOddValue_ReturnsFalse(){
            var result=_calculatorFixture.calc.IsOdd(2);
            Assert.False(result);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(200, false)]
        [InlineData(3,true)]
        [Trait("Category","IsOdd")]
        public void IsOdd_TestOddAndEven(int value, bool expected){
            var result =_calculatorFixture.calc.IsOdd(value);
            Assert.Equal(expected,result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType=typeof(TestDataShare) )]
        public void IsOdd_TestOddAndEvenUsingDataShare(int value, bool expected){
            var result =_calculatorFixture.calc.IsOdd(value);
            Assert.Equal(expected,result);
        }

        [Theory]
        [IsOddOrEvenData]
        public void IsOdd_TestOddAndEvenUsingDataAtribute(int value, bool expected){
            var result =_calculatorFixture.calc.IsOdd(value);
            Assert.Equal(expected,result);
        }
    
    
    }
}