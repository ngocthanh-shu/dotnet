using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CartDetailModel
    {
        private EShoperDbContext context = null;
        public CartDetailModel()
        {
            context = new EShoperDbContext();
        }
        public bool AddProductIntoCartDetail(int productId, int cartId)
        {
            bool rs;
            if(IsExistsProduct(productId, cartId))
            {
                rs = AddProductQuantity(productId, cartId);
            }
            else
            {
                rs = AddProduct(productId, cartId);
            }
            var update = new CartModel().UpdateCart(cartId, GetTotalQuantity(cartId), GetTotalPrice(cartId));
            return rs;
        }

        public bool AddProduct(int productId, int cartId)
        {
            var product = new ProductModel().GetProductDetail(productId);
            object[] sqlPrams =
            {
                new SqlParameter("@productId",productId),
                new SqlParameter("@cartId",cartId),
                new SqlParameter("@price", product.price)
            };
            var res = context.Database.SqlQuery<CartDetail>("cartdetail_addProduct @productId,@cartId,@price", sqlPrams).SingleOrDefault();
            if (res == null)
                return false;
            return true;
        }

        public bool AddProductQuantity(int productId, int cartId)
        {
            object[] sqlPrams =
            {
                new SqlParameter("@productId",productId),
                new SqlParameter("@cartId",cartId)
            };
            var res = context.Database.SqlQuery<CartDetail>("cartdetail_addProductQuantity @productId,@cartId", sqlPrams).SingleOrDefault();
            var update = new CartModel().UpdateCart(cartId, GetTotalQuantity(cartId), GetTotalPrice(cartId));
            if (res == null)
                return false;
            return true;
        }
        
        public bool ReduceProductQuantity(int productId, int cartId)
        {
            object[] sqlPrams =
            {
                new SqlParameter("@productId",productId),
                new SqlParameter("@cartId",cartId)
            };
            var res = context.Database.SqlQuery<CartDetail>("cartdetail_reduceProductQuantity @productId,@cartId", sqlPrams).SingleOrDefault();
            var update = new CartModel().UpdateCart(cartId, GetTotalQuantity(cartId), GetTotalPrice(cartId));
            if (res == null)
                return false;
            return true;
        }

        public bool IsExistsProduct(int productId, int cartId)
        {
            object[] sqlPrams =
            {
                new SqlParameter("@productId",productId),
                new SqlParameter("@cartId",cartId)
            };
            var res = context.Database.SqlQuery<CartDetail>("cartdetail_checkExistsProduct @productId,@cartId", sqlPrams).SingleOrDefault();
            if(res == null)
                return false;
            return true;
        }

        public double GetTotalPrice(int cartId)
        {
            object[] sqlPrams =
            {
                new SqlParameter("@cartId",cartId)
            };
            var res = context.Database.SqlQuery<double>("cartdetail_getTotalPrice @cartId",sqlPrams).SingleOrDefault();
            return res;
        }
        public int GetTotalQuantity(int cartId)
        {
            object[] sqlPrams =
            {
                new SqlParameter("@cartId",cartId)
            };
            var res = context.Database.SqlQuery<int>("cartdetail_getTotalQuantity @cartId", sqlPrams).SingleOrDefault();
            return res;
        }

        public List<CartDetail> GetProductList(int cartId)
        {
            object[] sqlPrams =
            {
                new SqlParameter("@cartId",cartId)
            };
            var res = context.Database.SqlQuery<CartDetail>("cartdetail_getProducts @cartId",sqlPrams).ToList();
            return res;
        }

        public bool DeleteProduct(int productId, int cartId)
        {
            object[] sqlPrams =
            {
                new SqlParameter("@productId",productId),
                new SqlParameter("@cartId",cartId)
            };
            var res = context.Database.SqlQuery<CartDetail>("cartdetail_deleteProduct @productId,@cartId", sqlPrams).SingleOrDefault();
            var update = new CartModel().UpdateCart(cartId, GetTotalQuantity(cartId), GetTotalPrice(cartId));
            if (res == null)
                return true;
            else
                return false;
        }
    }
}