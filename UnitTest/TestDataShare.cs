using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static IEnumerable<object[]> IsOddOrEvenExternalData
        {
            get{
                var allines=System.IO.File.ReadAllLines("IsOddOrEvenTestData.txt");
                return allines.Select(x=>{
                    var linesplit=x.Split(',');
                   return new object[] {int.Parse(linesplit[0]), bool.Parse(linesplit[1])};
                });
            }
        }
    }
}