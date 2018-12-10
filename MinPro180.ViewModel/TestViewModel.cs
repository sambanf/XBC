using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class TestViewModel
    {
        public long id { get; set; }

        [Required]
        [Display(Name ="NAME") ,StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string notes { get; set; }

        [Display(Name ="CREATED BY")]
        public long created_by { get; set; }

        [Display(Name="STATUS")]
        public bool active { get; set; }

        public string status { get
            {
                if(active==true)
                {
                    return "Active";
                }
                else
                {
                    return "Deactive";
                }
            }
        }
    }
}
