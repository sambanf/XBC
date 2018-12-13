using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
	public class AssignmentViewModel
	{
		public AssignmentViewModel()
		{
			is_delete = false;
			is_hold = false;
			is_done = false;
		}
		public long id { get; set; }

		[Display(Name = "Name")]
		public long biodata_id { get; set; }

		public string bio_name { get; set; }

		[Required]
		[StringLength(255)]
		public string title { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Start Date")]
		public DateTime start_date { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "End Date")]
		public DateTime end_date { get; set; }

		[StringLength(255)]
		public string description { get; set; }

		public DateTime? realization_date { get; set; }

		[StringLength(255)]
		public string notes { get; set; }

		public bool? is_hold { get; set; }

		public bool? is_done { get; set; }


		public long? deleted_by { get; set; }

		public DateTime? deleted_on { get; set; }

		public bool is_delete { get; set; }

		public string delete_name
		{
			get
			{
				if (is_delete == false)
				{
					return "False";
				}
				else
				{
					return "True";
				}
			}
		}
	}
}
