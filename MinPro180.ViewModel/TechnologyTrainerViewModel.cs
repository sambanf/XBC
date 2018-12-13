using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class TechnologyTrainerViewModel
    {
        public long id { get; set; }

        public long technology_id { get; set; }

        [Display(Name = "NAME")]
        public long trainer_id { get; set; }

        [Display(Name = "NAME")]
        public string name { get; set; }

        [Display(Name = "NOTES")]
        public string notes { get; set; }

        [Display(Name = "CREATE BY")]
        public long created_by { get; set; }

        public DateTime created_on { get; set; }

        [Display(Name = "STATUS")]
        public bool active { get; set; }
        public string status
        {
            get
            {
                if (active == true)
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
