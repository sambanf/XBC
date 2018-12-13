using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class QuestionViewModel
    {
        [Display(Name = "Question")]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Questions")]
        public string question { get; set; }        
    }
}
