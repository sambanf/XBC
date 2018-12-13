using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class IdleViewModel
    {
        public IdleViewModel()
        {
            is_delete = false;
            is_publish = false;
        }
        public long id { get; set; }
        public long category_id { get; set; }
        [Display(Name = "Category ID")]
        public string category { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name ="Title")]
        public string title { get; set; }

        [StringLength(5000)]
        public string content { get; set; }

        public bool is_publish { get; set; }
        public long created_by { get; set; }

        public DateTime created_on { get; set; }

        public long? modified_by { get; set; }

        public DateTime? modified_on { get; set; }

        public long? deleted_by { get; set; }

        public DateTime? deleted_on { get; set; }
        public bool is_delete { get; set; }
    }
}
