using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;

namespace DemoLibrary.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4,3,7)]
        [InlineData(21,5.25,26.25)]
        [InlineData(double.MaxValue,5, double.MaxValue)]
        public void Add_SimpleValueShouldCalculated(double x, double y, double expected)
        {
            //Arrange
            
            //Act
            double actual = Calculator.Add(x,y);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8,4,2)]
        public void Divide_SimpleValueShouldCalculatd(double x, double y, double expected)
        {
            //arrange
            double actual = Calculator.Divide(x, y);

            Assert.Equal(expected, actual);
        }
    }
}
