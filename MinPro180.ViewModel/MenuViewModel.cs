﻿using System;
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

        [Display(Name ="CODE")]
        [StringLength(50)]
        public string code { get; set; }

        [Display(Name = "TITLE")]
        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Display(Name = "DESCRIPTION")]
        [StringLength(255)]
        public string description { get; set; }

        [Display(Name = "IMAGE URL")]
        [Required]
        [StringLength(100)]
        public string image_url { get; set; }

        [Display(Name = "MENU ORDER")]
        public int menu_order { get; set; }

        [Display(Name = "PARENT")]
        public long? menu_parent { get; set; }

        [Display(Name = "MENU URL")]
        [Required]
        [StringLength(100)]
        public string menu_url { get; set; }

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
