using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class VDetailViewModel
    {
        public long id { get; set; }

        public long question_id { get; set; }

        [Display(Name ="Questions")]
        public string question { get; set; }

        public long version_id { get; set; }
    }
}
