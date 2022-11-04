using System.Collections.Generic;

namespace Dotnet_UnitTest
{
    public class Calculator
    {
        public List<int> FiboNumbers => new List<int>{1,2,2,3,5,8,13};
        public int Add (int x, int y){
            return x+y;
        }

        public int substract(int x, int y){
            return x-y;
        }

        public double AddDouble(double x, double y){
            return x+y;
        }
    
    }
}