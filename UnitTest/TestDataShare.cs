using System.Collections.Generic;
namespace Dotnet_UnitTest.UnitTest
{
    public static class TestDataShare
    {
        public static IEnumerable<object[]> IsOddEvenData {
            get{
                yield return new object[]{1, true};
                yield return new object []{200, false};
                 yield return new object []{3, true};
            }
        }
    }
}