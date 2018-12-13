using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class RoomViewModel
    {
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int capacity { get; set; }

        public bool any_projector { get; set; }

        [StringLength(500)]
        public string notes { get; set; }

        public long office_id { get; set; }

        [Required]
        [StringLength(50)]
        public string office_name { get; set; }

        public bool active { get; set; }
    }
}
