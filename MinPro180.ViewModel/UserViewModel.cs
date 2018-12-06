﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            active = true;
        }
        public long id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "USERNAME")]
        public string username { get; set; }

        [Required]
        [Display(Name = "PASSWORD")]
        [StringLength(50)]
        public string password { get; set; }

        [Display(Name = "Retype Password")]
        public string Retype_password { get; set; }

        [Display(Name = "ROLE")]
        public long role_id { get; set; }

        public string role_name { get; set; }

        [Display(Name = "Mobile Flag")]
        public bool mobile_flag { get; set; }

        [Display(Name = "Mobile Flag")]
        public long? mobile_token { get; set; }

        [Display(Name = "STATUS")]
        public bool active { get; set; }

        public string status
        {
            get
            {
                if (active == true)
                {
                    return "Active";
                }
                else
                {
                    return "Deactive";
                }
            }
        }

    }
}
