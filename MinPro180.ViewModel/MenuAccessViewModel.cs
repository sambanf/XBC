using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class MenuAccessViewModel
    {
        public long id { get; set; }
        [Display(Name = "Menu")]
        public long menu_id { get; set; }
        
        public string title { get; set; }
        [Display(Name = "Role")]
        public long role_id { get; set; }
        
        public string name { get; set; }

        public long created_by { get; set; }

        public DateTime created_on { get; set; }

        //public string rolename { get; set; }

    }
}
