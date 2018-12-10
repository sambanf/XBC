using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class VersionViewModel
    {

        public long id { get; set; }
        [Display(Name = "Version")]
        public int version { get; set; }

        public List<QuestionViewModel> questions { get; set; }
    }
}
