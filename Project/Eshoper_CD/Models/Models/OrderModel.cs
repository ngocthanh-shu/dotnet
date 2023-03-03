using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class OrderModel
    {
        private EShoperDbContext context = null;
        public OrderModel()
        {
            context = new EShoperDbContext();
        }

        public bool AddOrder(int cartId, string fullname, string address, string phone, string message)
        {
            object[] sqlParams =
            {
                new SqlParameter("@cartId",cartId),
                new SqlParameter("@fullname",fullname),
                new SqlParameter("@address", address),
                new SqlParameter("@phone", phone),
                new SqlParameter("@message",message),
            };
            var res = context.Database.SqlQuery<Checkout>("checkout_addOrder @cartId,@fullname,@address,@phone,@message", sqlParams).SingleOrDefault();
            if (res == null)
                return false;
            return true;
        }

        public List<Checkout> GetOrderList()
        {
            var res = context.Database.SqlQuery<Checkout>("checkout_getList").ToList();
            return res;
        }
        public Checkout GetOrderDetail(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
            };
            var res = context.Database.SqlQuery<Checkout>("checkout_getOrderDetail @id",sqlParams).SingleOrDefault();
            return res;
        }
        public bool ApproveOrder(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
            };
            var res = context.Database.SqlQuery<Checkout>("checkout_Approve @id",sqlParams).SingleOrDefault();
            if (res == null)
                return false;
            return true;
        }
        public bool RejectOrder(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
            };
            var res = context.Database.SqlQuery<Checkout>("checkout_Reject @id", sqlParams).SingleOrDefault();
            if (res == null)
                return false;
            return true;
        }
    }
}
