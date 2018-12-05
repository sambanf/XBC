using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            active = true;
        }
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [Required]
        [StringLength(100)]
        public string image_url { get; set; }

        public int menu_order { get; set; }

        public long? menu_parent { get; set; }

        [Required]
        [StringLength(100)]
        public string menu_url { get; set; }

        public bool active { get; set; }
    }
}
