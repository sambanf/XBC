using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
	public class BiodataViewModel
	{
		public BiodataViewModel()
		{
			active = true;
		}
		public long id { get; set; }

		[Required]
		[StringLength(255)]
		
		[Display (Name ="Name")]
		public string name { get; set; }

		[StringLength(255)]
		[Display(Name = "Gender")]
		public string gender { get; set; }

		[Required]
		[StringLength(100)]
		public string last_education { get; set; }

		[Required]
		[StringLength(5)]
		public string graduation_year { get; set; }

		[Required]
		[StringLength(5)]
		public string educational_level { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name = "Majors")]
		public string majors { get; set; }

		[Required]
		[StringLength(5)]
		[Display(Name = "GPA")]
		public string gpa { get; set; }

		public long? bootcamp_test_type { get; set; }

		public int? iq { get; set; }

		[StringLength(10)]
		public string du { get; set; }

		public int? arithmetic { get; set; }

		public int? nested_logic { get; set; }

		public int? join_table { get; set; }

		[StringLength(50)]
		public string tro { get; set; }

		[StringLength(100)]
		public string notes { get; set; }

		[StringLength(100)]
		public string interviewer { get; set; }

		public bool active { get; set; }

	}
}
