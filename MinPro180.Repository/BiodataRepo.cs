using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
	public class BiodataRepo
	{
		public static List<BiodataViewModel> All(string searchString)
		{
			List<BiodataViewModel> result = new List<BiodataViewModel>();
			using (var db = new MinProContext())
			{
				if (String.IsNullOrEmpty(searchString))
					{
					result = (from c in db.t_biodata
							  where c.active == true
							  select new BiodataViewModel
							  {
								  id = c.id,
								  name = c.name,
								  gender = c.gender,
								  last_education = c.last_education,
								  graduation_year = c.graduation_year,
								  educational_level = c.educational_level,
								  majors = c.majors,
								  gpa = c.gpa,
								  bootcamp_test_type = c.bootcamp_test_type,
								  iq = c.iq,
								  du = c.du,
								  arithmetic = c.arithmetic,
								  nested_logic = c.nested_logic,
								  join_table = c.join_table,
								  tro = c.tro,
								  notes = c.notes,
								  interviewer = c.interviewer,
								  active = c.active
							  }).ToList();
				}
				else
				{
					var bio = from d in db.t_biodata
							   where d.active == true
							   select new BiodataViewModel
							   {
								   id = d.id,
								   name = d.name,
								   gender = d.gender,
								   last_education = d.last_education,
								   graduation_year = d.graduation_year,
								   educational_level = d.educational_level,
								   majors = d.majors,
								   gpa = d.gpa,
								   bootcamp_test_type = d.bootcamp_test_type,
								   iq = d.iq,
								   du = d.du,
								   arithmetic = d.arithmetic,
								   nested_logic = d.nested_logic,
								   join_table = d.join_table,
								   tro = d.tro,
								   notes = d.notes,
								   interviewer = d.interviewer,
								   active = d.active
							   };
					bio = bio.Where(s => s.name.Contains(searchString));
					result = bio.ToList();
				}
			}
			return result;
		}
		public static ResponResultViewModel Update(BiodataViewModel entity)
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
						t_biodata bi = new t_biodata();
						bi.name= entity.name;
						bi.last_education = entity.last_education;
						bi.educational_level = entity.educational_level;
						bi.graduation_year = entity.graduation_year;
						bi.majors = entity.majors;
						bi.gpa = entity.gpa;
						bi.active = entity.active;

						bi.created_by = 1;
						bi.created_on = DateTime.Now;
						db.t_biodata.Add(bi);
						db.SaveChanges();

						result.Entity = bi;
					}
					//Edit
					else
					{
						t_biodata bi = db.t_biodata.Where(o => o.id == entity.id).FirstOrDefault();
						if (bi != null)
						{
							
							bi.name = entity.name;
							bi.last_education = entity.last_education;
							bi.educational_level = entity.educational_level;
							bi.graduation_year = entity.graduation_year;
							bi.majors = entity.majors;
							bi.gpa = entity.gpa;
							bi.active = entity.active;

							bi.modified_by = 2;
							bi.modified_on = DateTime.Now;

							db.SaveChanges();

							result.Entity = entity;
						}
						else
						{
							result.Success = false;
							result.Message = "Biodata not Found!";
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
		public static ResponResultViewModel Update2(BiodataViewModel entity)
		{
			ResponResultViewModel result = new ResponResultViewModel();
			try
			{
				using (var db = new MinProContext())
				{
					t_biodata bio = db.t_biodata.Where(o => o.id == entity.id).FirstOrDefault();
					if (bio != null)
					{
						bio.active = false;
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
		public static BiodataViewModel GetBiodata(int id)
		{
			BiodataViewModel result = new BiodataViewModel();
			using (var db = new MinProContext())
			{
				result = (from c in db.t_biodata
						  where c.id == id
						  select new BiodataViewModel
						  {
							  id = c.id,
							  name = c.name,
							  gender = c.gender,
							  last_education = c.last_education,
							  graduation_year = c.graduation_year,
							  educational_level = c.educational_level,
							  majors = c.majors,
							  gpa = c.gpa,
							  bootcamp_test_type = c.bootcamp_test_type,
							  iq = c.iq,
							  du = c.du,
							  arithmetic = c.arithmetic,
							  nested_logic = c.nested_logic,
							  join_table = c.join_table,
							  tro = c.tro,
							  notes = c.notes,
							  interviewer = c.interviewer,
							  active = c.active,
						  }).FirstOrDefault();
				if (result == null)
				{
					result = new BiodataViewModel();
				}
			}
			return result;
		}
	}
}
