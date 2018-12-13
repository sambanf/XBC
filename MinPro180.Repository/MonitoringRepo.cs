using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
	public class MonitoringRepo
	{
		public static List<MonitoringViewModel> All(string searchString)
		{
			List<MonitoringViewModel> result = new List<MonitoringViewModel>();
			using (var db = new MinProContext())
			{
				if (String.IsNullOrEmpty(searchString))
				{
					result = (from c in db.t_monitoring
							  join d in db.t_biodata on
							  c.biodata_id equals d.id
							  where c.is_delete == false
							  select new MonitoringViewModel
							  {
								  id = c.id,
								  bio_name = d.name,
								  biodata_id = c.biodata_id,
								  idle_date = c.idle_date,
								  last_project = c.last_project,
								  idle_reason = c.idle_reason,
								  placement_date = c.placement_date,
								  placement_at = c.placement_at,
								  notes = c.notes,

								  is_delete = c.is_delete,

							  }).ToList();
				}
				else
				{
					var mon = from c in db.t_monitoring
							   join d in db.t_biodata on
							   c.biodata_id equals d.id
							   where c.is_delete == false
							   select new MonitoringViewModel
							   {
								   id = c.id,
								   bio_name = d.name,
								   biodata_id = c.biodata_id,
								   idle_date = c.idle_date,
								   last_project = c.last_project,
								   idle_reason = c.idle_reason,
								   placement_date = c.placement_date,
								   placement_at = c.placement_at,
								   notes = c.notes,
								   is_delete = c.is_delete

							   };
					mon = mon.Where(o => o.bio_name.Contains(searchString));
					result = mon.ToList();
				}
			}
			return result;
		}
		public static ResponResultViewModel Update(MonitoringViewModel entity)
		{
			//Untuk create dan edit
			ResponResultViewModel result = new ResponResultViewModel();
			try
			{
				using (var db = new MinProContext())
				{
					//Create
					if (entity.id == 0)
					{
						t_monitoring mn = new t_monitoring();
						mn.biodata_id = entity.biodata_id;
						mn.idle_date = entity.idle_date;
						mn.last_project = entity.last_project;
						mn.idle_reason = entity.idle_reason;
						mn.placement_date = DateTime.Now;
						mn.is_delete = entity.is_delete;

						mn.created_by = 1;
						mn.created_on = DateTime.Now;
						

						db.t_monitoring.Add(mn);
						db.SaveChanges();

						result.Entity = mn;
					}
					//Edit
					else
					{
						t_monitoring mn = db.t_monitoring.Where(o => o.id == entity.id).FirstOrDefault();
						if (mn != null)
						{
							mn.biodata_id = entity.biodata_id;
							mn.idle_date = entity.idle_date;
							mn.last_project = entity.last_project;
							mn.idle_reason = entity.idle_reason;
							mn.is_delete = entity.is_delete;

							mn.modified_by = 2;
							mn.modified_on = DateTime.Now;

							db.SaveChanges();

							result.Entity = entity;
						}
						else
						{
							result.Success = false;
							result.Message = "Idle not Found!";
						}
					}
				}
			}
			catch (Exception ex)
			{

				result.Success = false;
				result.Message = ex.Message;
			}
			return result;
		}
		public static ResponResultViewModel CreatePlacement(MonitoringViewModel entity)
		{
			//Untuk placement
			ResponResultViewModel result = new ResponResultViewModel();
			try
			{
				using (var db = new MinProContext())

				{
					t_monitoring mn = db.t_monitoring.Where(o => o.id == entity.id).FirstOrDefault();
					if (mn != null)
					{
				
						mn.placement_date =entity.placement_date;
						mn.placement_at = entity.placement_at;
						mn.notes = entity.notes;

						mn.modified_by = 2;
						mn.modified_on = DateTime.Now;

						db.SaveChanges();

						result.Entity = entity;
					}
					
				}

			}
			catch (Exception ex)
			{

				result.Success = false;
				result.Message = ex.Message;
			}
			return result;
		}
		public static ResponResultViewModel Is_Delete(MonitoringViewModel entity)
		{
			ResponResultViewModel result = new ResponResultViewModel();
			try
			{
				using (var db = new MinProContext())
				{
					t_monitoring mn = db.t_monitoring.Where(o => o.id == entity.id).FirstOrDefault();
					if (mn != null)
					{
						mn.is_delete = true;
						mn.deleted_by = 1;
						mn.deleted_on = DateTime.Now;
						db.SaveChanges();
						result.Entity = entity;
					}
				}
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
			}
			return result;
		}
		public static MonitoringViewModel GetMonitoring(long id)
		{
			MonitoringViewModel result = new MonitoringViewModel();
			using (var db = new MinProContext())
			{
				result = (from c in db.t_monitoring
						  join d in db.t_biodata on
						 c.biodata_id equals d.id
						  select new MonitoringViewModel
						  {
							  id = c.id,
							  bio_name = d.name,
							  biodata_id = c.biodata_id,
							  idle_date = c.idle_date,
							  last_project = c.last_project,
							  idle_reason = c.idle_reason,
							  placement_date = c.placement_date,
							  placement_at = c.placement_at,
							  notes = c.notes,
							  is_delete = c.is_delete,

						  }).FirstOrDefault();
				if (result == null)
				{
					result = new MonitoringViewModel();
				}
			}
			return result;
		}
		public static MonitoringViewModel GetPlacement(long id)
		{
			MonitoringViewModel result = new MonitoringViewModel();
			using (var db = new MinProContext())
			{
				result = (from c in db.t_monitoring
						  join d in db.t_biodata on
						 c.biodata_id equals d.id
						 where c.id == id
						  select new MonitoringViewModel
						  {
							  
							  placement_date = c.placement_date,
							  placement_at = c.placement_at,
							  notes = c.notes,
							  is_delete = c.is_delete,

						  }).FirstOrDefault();
				if (result == null)
				{
					result = new MonitoringViewModel();
				}
			}
			return result;
		}
	}
}
