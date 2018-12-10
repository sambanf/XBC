using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class VersionRepo
    {
        public static List<VersionViewModel> All()
        {
            List<VersionViewModel> result = new List<VersionViewModel>();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_version
                          where c.is_delete == false
                          orderby c.version descending
                          select new VersionViewModel
                          {
                              id = c.id,
                              version = c.version
                          }).Take(1).ToList();
                if (result.Count == 0)
                {
                    t_version version = new t_version();

                    version.version = 1;

                    version.created_by = 1;
                    version.created_on = DateTime.Now;

                    version.is_delete = false;

                    db.t_version.Add(version);
                    db.SaveChanges();
                    result = (from c in db.t_version
                              where c.is_delete == false
                              select new VersionViewModel
                              {
                                  id = c.id,
                                  version = c.version
                              }).ToList();
                }

            }
            return result;
        }

        public static VersionViewModel GetLastVersion()
        {
            VersionViewModel result = new VersionViewModel();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_version
                          where c.is_delete == false
                          orderby c.version descending
                          select new VersionViewModel
                          {
                              id = c.id,
                              version = c.version + 1
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new VersionViewModel();
                }
            }
            return result;
        }

        public static ResponResultViewModel Create(VersionViewModel entity)
        {
            //Create n Version + 1
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_version version = new t_version();

                    version.version = entity.version;

                    version.created_by = 1;
                    version.created_on = DateTime.Now;

                    version.is_delete = false;

                    
                    foreach (var quiz in entity.questions)
                    {
                        t_version_detail vd = new t_version_detail();
                        vd.version_id = version.id;
                        vd.question_id = quiz.id;

                        vd.created_by = 1;
                        vd.created_on = DateTime.Now;

                        db.t_version_detail.Add(vd);
                    }

                    db.t_version.Add(version);
                    db.SaveChanges();



                    result.Entity = entity;
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static VersionViewModel GetCurrentVersion()
        {
            VersionViewModel result = new VersionViewModel();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_version
                          where c.is_delete == false
                          orderby c.version descending
                          select new VersionViewModel
                          {
                              id = c.id,
                              version = c.version
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new VersionViewModel();
                }
            }
            return result;
        }

        public static ResponResultViewModel Delete(VersionViewModel entity)
        {
            //Delete Version
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_version version = db.t_version.Where(o => o.id == entity.id).FirstOrDefault();
                    if (version != null)
                    {
                        version.version = entity.version;
                        version.deleted_by = 1;
                        version.deleted_on = DateTime.Now;

                        version.is_delete = true;

                        db.SaveChanges();

                        result.Entity = entity;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Version not Found!";
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

        public static List<VDetailViewModel> Detail()
        {
            List<VDetailViewModel> result = new List<VDetailViewModel>();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_version_detail
                          join q in db.t_question on c.question_id equals q.id
                          select new VDetailViewModel
                          {

                              id = c.id,
                              version_id = c.version_id,
                              question_id = c.question_id,
                              question = q.question

                          }).ToList();
            }
            return result;
        }

        public static QuestionViewModel Detailitem(int id)
        {
            QuestionViewModel result = new QuestionViewModel();
            using (var db = new MinProContext())
            {
                result = (from q in db.t_question
                          where q.id == id
                          select new QuestionViewModel
                          {
                              id = q.id,
                              question = q.question

                          }).FirstOrDefault();
            }
            return result == null ? new QuestionViewModel() : result;
        }


    }
}