using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class TestimonyViewModel
    {
        public TestimonyViewModel()
        {
            is_delete = false;
        }
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "TITLE")]
        public string title { get; set; }

        [StringLength(5000)]
        [Display(Name = "CONTENT")]
        public string content { get; set; }

        public long created_by { get; set; }

        public DateTime created_on { get; set; }

        public bool is_delete { get; set; }
    }
}
