using TestingApp.functionallity;
using Xunit;

namespace TestingApp.Test
{
    public class DbServiceMock : IDbService
    {
        public bool ProcessResult {get;set;}
        public Product ProductBeingProcessed {get;set;}
        public int ProductIdBeingProcessed {get;set;}
        public bool RemoveItemFromShoppingCart(int? prodId)
        {
            if (prodId==null) return false;
            ProductIdBeingProcessed=(int)prodId;
            return true;
        }

        public bool SaveItemToShoppingCart(Product? product)
        {
            if (product==null) return false;

            ProductBeingProcessed=product;
            return true;
        }
    }
    public class ShoppingCartTests
    {
        [Fact]
        public void AddProduct_Success(){
            //Given
            var dbMock = new DbServiceMock();
            dbMock.ProcessResult=true;
            var shoppingCart= new ShoppingCart(dbMock);
            //When
            var product = new Product(1, "Shoes", 150);
           var result= shoppingCart.AddProduct(product);

            //Assert
            Assert.True(result);
            Assert.Equal("Shoes", dbMock.ProductBeingProcessed.Name);

        }

    }
}