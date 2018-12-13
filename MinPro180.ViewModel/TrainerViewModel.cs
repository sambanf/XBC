using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class TrainerViewModel
    {
        public TrainerViewModel()
        {
            active = true;
        }
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string notes { get; set; }

        [Display(Name = "Status")]
        public bool active { get; set; }

        public long created_by { get; set; }

        public DateTime created_on { get; set; }

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
