using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class ClassViewModel
    {
        public long id { get; set; }
        
        public long batch_id { get; set; }
        
        public string batchname { get; set; }

        public string techname { get; set; }

        [Display(Name = "BATCH")]
        public string batchtech { get
            {
                return techname + " " + batchname;
            }
        }

        [Required, Display(Name = "PARTICIPANT")]
        public long biodata_id { get; set; }

        [Display(Name = "NAME")]
        public string bioname { get; set; }
    }
}
