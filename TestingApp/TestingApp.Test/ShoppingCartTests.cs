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
            return ProcessResult;
        }

        public bool SaveItemToShoppingCart(Product? product)
        {
            if (product==null) return false;

            ProductBeingProcessed=product;
            return ProcessResult;
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
            Assert.Equal(result, dbMock.ProcessResult);
            Assert.Equal("Shoes", dbMock.ProductBeingProcessed.Name);

        }

        [Fact]
        public void AddProduct_Failure_DueToInvalidPayLoad(){
            var dbMock= new DbServiceMock();
            dbMock.ProcessResult=true;
            var shoppingCart= new ShoppingCart(dbMock);

            
            var result= shoppingCart.AddProduct(null);
            Assert.False(result);
        }

        [Fact]
        public void DeleteProduct_InpuIdtNull_ReturnFalse(){
            var dbMock= new DbServiceMock();
            dbMock.ProcessResult= true;
            var shoppingCart = new ShoppingCart(dbMock);

            var result= shoppingCart.DeleteProduct(null);

            Assert.False(result);
        }

        [Fact]
        public void DeleteProduct_InputId0_ResturnFalse(){
            var dbMock = new DbServiceMock();
            dbMock.ProcessResult= true;
            var shoppingCart = new ShoppingCart(dbMock);
            var product = new Product(1, "Shoes", 23.5);
            shoppingCart.AddProduct(product);
            Assert.False(shoppingCart.DeleteProduct(0));
        }

        [Fact]
        public void DeleteProduct_InputId1_ReturnTrue(){
             var dbMock = new DbServiceMock();
            dbMock.ProcessResult= true;
            var shoppingCart = new ShoppingCart(dbMock);
            var product = new Product(1, "Shoes", 23.5);
            shoppingCart.AddProduct(product);
            Assert.True(shoppingCart.DeleteProduct(1));
        }
        
    }
}