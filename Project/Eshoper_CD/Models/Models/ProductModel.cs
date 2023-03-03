using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ProductModel
    {
        private EShoperDbContext context = null;
        public ProductModel()
        {
            context = new EShoperDbContext();
        }
        public List<product> GetCategoryTab(int categoryId)
        {
            object[] sqlParams = 
            {
                new SqlParameter("@categoryId",categoryId),
            };
            var res = context.Database.SqlQuery<product>("product_getCategoryTab @categoryId", sqlParams).ToList();
            return res;
        }
        public List<product> GetProductList()
        {
            var res = context.Database.SqlQuery<product>("product_getProduct").ToList();
            return res;
        }
        public product GetProductDetail(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
            };
            var res = context.Database.SqlQuery<product>("product_getProductDetail @id", sqlParams).FirstOrDefault();
            return res;
        }
        public product AddProduct(string name, float price, string img, string description, DateTime datebegin, int quantity, int categoryId)
        {
            object[] sqlParams =
            {
                new SqlParameter("@name", name),
                new SqlParameter("@price", price),
                new SqlParameter("@img", img),
                new SqlParameter("@description", description),
                new SqlParameter("@datebegin",datebegin),
                new SqlParameter("@quantity",quantity),
                new SqlParameter("@categoryId",categoryId),
            };
            var res = context.Database.SqlQuery<product>("product_addProduct @name,@price,@img,@description,@datebegin,@quantity,@categoryId", sqlParams).SingleOrDefault();
            return res;
        }
        public product UpdateProduct(int id ,string name, float price, string description, int quantity, int categoryId)
        {
            object[] sqlParams =
            {
                new SqlParameter("@id",id),
                new SqlParameter("@name",name),
                new SqlParameter("@price",price),
                new SqlParameter("@description",description),
                new SqlParameter("@quantity",quantity),
                new SqlParameter("@categoryId",categoryId),
            };
            var res = context.Database.SqlQuery<product>("product_updateProduct @id,@name,@price,@description,@quantity,@categoryId",sqlParams).SingleOrDefault();
            return res;
        }
        public product DeleteProduct(string img)
        {
            object[] sqlParams =
            {
                new SqlParameter("@img",img),
            };
            var res = context.Database.SqlQuery<product>("product_deleteProduct @img", sqlParams).SingleOrDefault();
            return res;
        }
        public List<product> GetProductsByCategory(int id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@categoryId",id),
            };
            var res = context.Database.SqlQuery<product>("product_getProductByCategory @categoryId", sqlParams).ToList();
            return res;
        }
    }
}
