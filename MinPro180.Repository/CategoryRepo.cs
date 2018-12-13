using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class CategoryRepo
    {
        public static List<CategoryViewModel> All()
        {
            List<CategoryViewModel> result = new List<CategoryViewModel>();
            using(var db = new MinProContext())
            {
                result = (from c in db.t_category
                          select new CategoryViewModel
                          {
                              id = c.id,
                              code = c.code,
                              name = c.name
                          }).ToList();
            }
            return result;
        }
        
    }
}
