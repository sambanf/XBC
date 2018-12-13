using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
	public class AssignmentRepo
	{
		public static List<AssignmentViewModel> All(string searchString)
		{
			List<AssignmentViewModel> result = new List<AssignmentViewModel>();
			using (var db = new MinProContext())
			{
				if (String.IsNullOrEmpty(searchString))
				{
					result = (from c in db.t_assignment
							  join d in db.t_biodata on
							  c.biodata_id equals d.id
							  where c.is_delete == false
							  select new AssignmentViewModel
							  {
								  id = c.id,
								  bio_name = d.name,
								  biodata_id = c.biodata_id,
								  title = c.title,
								  start_date = c.start_date,
								  end_date = c.end_date,
								  description = c.description,
								  realization_date = c.realization_date,
								  notes = c.notes,
								  is_hold = c.is_hold,
								  is_done = c.is_done,
								  is_delete = c.is_delete,

							  }).ToList();
				}
				else
				{
					var asg = from c in db.t_assignment
							  join d in db.t_biodata on
							  c.biodata_id equals d.id
							  where c.is_delete == false
							  select new AssignmentViewModel
							  {
								  id = c.id,
								  bio_name = d.name,
								  biodata_id = c.biodata_id,
								  title = c.title,
								  start_date = c.start_date,
								  end_date = c.end_date,
								  description = c.description,
								  realization_date = c.realization_date,
								  notes = c.notes,
								  is_hold = c.is_hold,
								  is_done = c.is_done,
								  is_delete = c.is_delete,

							  };
					asg = asg.Where(o => o.bio_name.Contains(searchString));
					result = asg.ToList();
				}
			}
			return result;
		}
		public static ResponResultViewModel Update(AssignmentViewModel entity)
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
						t_assignment asn = new t_assignment();
						asn.biodata_id = entity.biodata_id;
						asn.title = entity.title;
						asn.start_date = entity.start_date;
						asn.end_date = entity.end_date;
						asn.description = entity.description;
						asn.is_delete = entity.is_delete;
						asn.is_done = entity.is_done;
						asn.is_hold = entity.is_hold;

						asn.created_by = 1;
						asn.created_on = DateTime.Now;

						db.t_assignment.Add(asn);
						db.SaveChanges();

						result.Entity = asn;
					}
					//Edit
					else
					{
						t_assignment asn = db.t_assignment.Where(o => o.id == entity.id).FirstOrDefault();
						if (asn != null)
						{

							asn.biodata_id = entity.biodata_id;
							asn.title = entity.title;
							asn.start_date = entity.start_date;
							asn.end_date = entity.end_date;
							asn.description = entity.description;
							asn.is_delete = entity.is_delete;
							asn.is_done = entity.is_done;
							asn.is_hold = entity.is_hold;

							asn.modified_by = 2;
							asn.modified_on = DateTime.Now;

							db.SaveChanges();

							result.Entity = entity;
						}
						else
						{
							result.Success = false;
							result.Message = "Assignment not Found!";
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
		public static ResponResultViewModel CreateDone(AssignmentViewModel entity)
		{
			//Untuk placement
			ResponResultViewModel result = new ResponResultViewModel();
			try
			{
				using (var db = new MinProContext())

				{
					t_assignment asg = db.t_assignment.Where(o => o.id == entity.id).FirstOrDefault();
					if (asg != null)
					{

						asg.biodata_id = entity.biodata_id;
						asg.realization_date = entity.realization_date;
						asg.notes = entity.notes;
						asg.is_done = true;

						asg.modified_by = 2;
						asg.modified_on = DateTime.Now;

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
		public static ResponResultViewModel CreateHold(AssignmentViewModel entity)
		{
			//Untuk placement
			ResponResultViewModel result = new ResponResultViewModel();
			try
			{
				using (var db = new MinProContext())

				{
					t_assignment asg = db.t_assignment.Where(o => o.id == entity.id).FirstOrDefault();
					if (asg != null)
					{

						asg.biodata_id = entity.biodata_id;			
						asg.is_hold = true;

						asg.modified_by = 2;
						asg.modified_on = DateTime.Now;

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
		public static AssignmentViewModel GetAssignment(int id)
		{
			AssignmentViewModel result = new AssignmentViewModel();
			using (var db = new MinProContext())
			{
				result = (from c in db.t_assignment
						  join d in db.t_biodata on
						  c.biodata_id equals d.id
						  select new AssignmentViewModel
						  {
							  id = c.id,
							  bio_name = d.name,
							  biodata_id = c.biodata_id,
							  title = c.title,
							  start_date = c.start_date,
							  end_date = c.end_date,
							  description = c.description,
							  realization_date = c.realization_date,
							  notes = c.notes,
							  is_hold = c.is_hold,
							  is_done = c.is_done,
							  is_delete = c.is_delete,
						  }).FirstOrDefault();
				if (result == null)
				{
					result = new AssignmentViewModel();
				}
			}
			return result;
		}
		public static ResponResultViewModel is_delete(AssignmentViewModel entity)
		{

			ResponResultViewModel result = new ResponResultViewModel();
			try
			{
				using (var db = new MinProContext())
				{
					t_assignment asn = db.t_assignment.Where(o => o.id == entity.id).FirstOrDefault();
					if (asn != null)
					{
						asn.is_delete = true;
						asn.deleted_by = 1;
						asn.deleted_on = DateTime.Now;
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
	}
}