using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class SlideModel
    {
        private EShoperDbContext context = null;
        public SlideModel()
        {
            context = new EShoperDbContext();
        }
        public List<slide> ShowSlide()
        {
            var res = context.Database.SqlQuery<slide>("slide_getSlide").ToList();
            context.SaveChanges();
            return res;
        }
    }
}
