using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class BootcampTypeViewModel
    {
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name="Nama")]
        public string name { get; set; }

        [StringLength(255)]
        public string notes { get; set; }
        [Display(Name ="Create By")]
        public long created_by { get; set; }

        public DateTime created_on { get; set; }

        public long? modified_by { get; set; }

        public DateTime? modified_on { get; set; }

        public bool active { get; set; }
        [Display(Name = "Active")]
        public string actv { get; set; }
    }
}
