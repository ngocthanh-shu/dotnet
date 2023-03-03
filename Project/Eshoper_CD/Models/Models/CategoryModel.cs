using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CategoryModel
    {
        private EShoperDbContext context = null;
        public CategoryModel()
        {
            context = new EShoperDbContext();
        }

        public List<category> GetCategories()
        {
            var res = context.Database.SqlQuery<category>("category_getCategory").ToList();
            context.SaveChanges();
            return res;
        }
        public category GetCategoryByMeta(string meta)
        {
            object[] sqlParams = {
                new SqlParameter("@meta",meta),
            };
            var res = context.Database.SqlQuery<category>("category_getCategoryByMeta @meta", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
