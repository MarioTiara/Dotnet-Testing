using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingApp.functionallity
{
    public record Product(int id, string Name, double price);

    public interface IDbService{
        bool SaveItemToShoppingCart(Product? product);
        bool RemoveItemFromShoppingCart(int? prodId);
    }
    public class ShoppingCart
    {
        private readonly IDbService _dbservice;
        public ShoppingCart(IDbService dbService){
            _dbservice=dbService;
        }

        public bool AddProduct(Product? product){
            if (product==null){
                return false;
            }
            if (product.id==0){
                return false;
            }
            _dbservice.SaveItemToShoppingCart(product);
            return true;
        }

        public bool DeleteProduct(int? id){
            if(id==null) return false;
            if (id==0) return false;
            _dbservice.RemoveItemFromShoppingCart(id);
            return true;
        }
    }
}