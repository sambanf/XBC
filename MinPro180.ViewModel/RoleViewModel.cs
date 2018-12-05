using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            active = true;
        }
        public long id { get; set; }

        [Display(Name = "CODE")]
        [Required]
        [StringLength(50)]
        public string code { get; set; }

        [Display(Name = "NAME")]
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Display(Name = "DESCRIPTION")]
        [Required]
        [StringLength(255)]
        public string description { get; set; }

        [Display(Name = "STATUS")]
        public bool active { get; set; }
    }
}
