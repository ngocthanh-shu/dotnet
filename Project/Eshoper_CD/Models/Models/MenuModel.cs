using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class MenuModel
    {
        private EShoperDbContext context = null;
        public MenuModel()
        {
            context = new EShoperDbContext();
        }
        public List<menu> ShowMenu()
        {
            var res = context.Database.SqlQuery<menu>("menu_getMenu").ToList();
            context.SaveChanges();
            return res;
        }
    }
}
