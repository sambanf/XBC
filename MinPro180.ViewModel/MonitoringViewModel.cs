using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.ViewModel
{
	public class MonitoringViewModel
	{
		public MonitoringViewModel()
		{
			is_delete = false;
		}
		public long id { get; set; }

		[Display(Name = "Name")]
		public long biodata_id { get; set; }

		public string bio_name  { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Idle Date")]
		public DateTime idle_date { get; set; }

		[StringLength(50)]
		public string last_project { get; set; }

		[StringLength(255)]
		public string idle_reason { get; set; }

		[DataType(DataType.Date)]	
		[Display(Name = "Placement Date")]
		public DateTime placement_date { get; set; }

		
		[StringLength(50)]
		public string placement_at { get; set; }

		[StringLength(255)]
		public string notes { get; set; }
		

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
