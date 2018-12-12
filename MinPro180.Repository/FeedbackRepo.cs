using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class FeedbackRepo
    {
        //POST TO VIEW
        public static List<VDetailViewModel> All()
        {
            List<VDetailViewModel> result = new List<VDetailViewModel>();
            using (var db = new MinProContext())
            {

                var hi = from d in db.t_version_detail
                         join q in db.t_question on d.question_id equals q.id
                         join v in db.t_version on d.version_id equals v.id
                         orderby v.version descending
                         select new VDetailViewModel
                         {

                             question_id = d.question_id,
                             version_id = d.version_id,
                             question = q.question

                         };
                long a = GetLastVersionId();
                hi = hi.Where(o => o.version_id.Equals(a));
                result = hi.ToList();


            }
            return result;
        }

        //GET FROM VIEW
        public static long GetLastVersionId()
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
            }
            return result.id;
        }

        //SET TO DB
        public static ResponResultViewModel Save(FeedbackViewModel entity, long userid)
        {
            ResponResultViewModel res = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_feedback feedback = new t_feedback();
                        feedback.version_id = entity.version_id;
                        feedback.test_id = entity.test_id;
                        feedback.json_feedback = entity.json_feedback;

                        feedback.created_by = userid;
                        feedback.created_on = DateTime.Now;
                        feedback.is_delete = false;

                        db.t_feedback.Add(feedback);
                        db.SaveChanges();

                        res.Entity = feedback;
                    }
                    else
                    {
                        res.Success = false;
                        res.Message = "Feedback Not Found";
                    }
                }
            }
            catch (Exception e)
            {
                res.Success = false;
                res.Message = e.Message;
            }
            return res;
        }

    }
}
