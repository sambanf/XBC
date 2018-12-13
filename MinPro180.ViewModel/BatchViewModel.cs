using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class BatchViewModel
    {
        public long id { get; set; }

        [Required]
        [Display(Name ="TECHNOLOGY")]
        public long technology_id { get; set; }

        [Display(Name = "TECHNOLOGY")]
        public string techname { get; set; }

        [Required]
        [Display(Name = "TRAINER")]
        public long trainer_id { get; set; }

        [Display(Name = "TRAINER")]
        public string trainername { get; set; }

        [Required]
        [StringLength(255), Display(Name = "NAME")]
        public string name { get; set; }

        [Required]
        [Display(Name = "PERIOD FROM")]
        public DateTime? period_from { get; set; }

        [Required]
        [Display(Name = "PERIOD TO")]
        public DateTime? period_to { get; set; }

        [Required]
        [Display(Name = "ROOM")]
        public long? room_id { get; set; }

        [Required]
        [Display(Name = "BOOTCAMP TYPE")]
        public long? bootcamp_type_id { get; set; }

        [StringLength(255), Display(Name ="NOTES")]
        public string notes { get; set; }

        public bool is_delete { get; set; }

        public string status
        {
            get
            {
                if (is_delete == false)
                {
                    return "Active";
                }
                else
                {
                    return "Deactive";
                }
            }
        }

        public long created_by { get; set; }

        public List<ClassViewModel> PartList { get; set; }
    }
}
