using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CartModel
    {
        private EShoperDbContext context = null;
        public CartModel()
        {
            context = new EShoperDbContext();
        }
        public bool AddCart(string username)
        {
            object[] sqlParams =
            {
                new SqlParameter("@username",username)
            };
            var res = context.Database.SqlQuery<Cart>("cart_addNewCart @username",sqlParams).SingleOrDefault();
            if(res == null)
                return false;
            return true;
        }
        public bool AddProductIntoCart(int productId, string username)
        {
            var id = GetCartId(username);
            if(id == 0)
            {
                var newCart = AddCart(username);
                id = GetCartId(username);
            }
            var rs = new CartDetailModel().AddProductIntoCartDetail(productId, id);
            return rs;
        }
        public int GetCartId(string username)
        {
            object[] sqlParams =
            {
                new SqlParameter("@username",username)
            };
            var res = context.Database.SqlQuery<int>("cart_getId @username", sqlParams).SingleOrDefault();
            return res;
        }
        public string GetUsername(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
            };
            var res = context.Database.SqlQuery<string>("cart_getUsername @id", sqlParams).SingleOrDefault();
            return res;
        }
        public bool UpdateCart(int id, int quantity, double price)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
                new SqlParameter("@quantity", quantity),
                new SqlParameter("@price", price),
            };
            var res = context.Database.SqlQuery<Cart>("cart_update @id,@quantity,@price",sqlParams).SingleOrDefault();
            if(res  == null)
                return false;
            return true;
        }
        public Cart GetCart(string username)
        {
            object[] sqlParams =
            {
                new SqlParameter("@username",username)
            };
            var res = context.Database.SqlQuery<Cart>("cart_getCart @username", sqlParams).SingleOrDefault();
            return res;
        }
        public Cart GetCartById(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id)
            };
            var res = context.Database.SqlQuery<Cart>("cart_getCartById @id", sqlParams).SingleOrDefault();
            return res;
        }
        public bool OrderClosing(int cartId)
        {
            object[] sqlParams =
            {
                new SqlParameter("@cartId",cartId),
            };
            var res = context.Database.SqlQuery<Cart>("cart_orderClosing @cartId", sqlParams).SingleOrDefault();
            if(res == null)
                return false;
            return true;
        }
    }
}
