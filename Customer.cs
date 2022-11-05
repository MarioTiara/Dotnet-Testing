using System;
namespace Dotnet_UnitTest
{
    public class Customer
    {
        public string Name => "Mario";
        public int GetOrdersByNane(string name){
            if (string.IsNullOrEmpty(name)){
                throw new ArgumentException("String is null or empty");
            }

            return 100;
        }
        public int Age =>35;
    }
}