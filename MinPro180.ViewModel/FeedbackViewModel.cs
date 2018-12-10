using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class FeedbackViewModel
    {
        public long id { get; set; }
        [Display(Name ="Test")]
        [Required]
        public long test_id { get; set; }

        public long version_id { get; set; }

        public string question { get; set; }

        [StringLength(5000)]
        public string json_feedback { get; set; }


    }
}
