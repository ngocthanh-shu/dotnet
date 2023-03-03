using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class FeatureItemModel
    {
        private EShoperDbContext context = null;
        public FeatureItemModel()
        {
            context = new EShoperDbContext();
        }
        public List<product> getFeature()
        {
            var res = context.Database.SqlQuery<product>("product_getFeature").ToList();
            context.SaveChanges();
            return res;
        }
    }
}
