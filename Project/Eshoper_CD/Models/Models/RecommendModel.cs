using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class RecommendModel
    {
        private EShoperDbContext context = null;
        public RecommendModel()
        {
            context = new EShoperDbContext();
        }
        public List<product> GetRecommendList()
        {
            var res = context.Database.SqlQuery<product>("product_getRecommend").ToList();
            return res;
        }
    }
}
