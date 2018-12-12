using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MinPro180.Repository
{
    public class QuestionRepo
    {
        public static List<QuestionViewModel> All(string searchString)
        {
            
            List<QuestionViewModel> result = new List<QuestionViewModel>();
            using (var db = new MinProContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    result = (from c in db.t_question
                              where c.is_delete == false
                              select new QuestionViewModel
                              {
                                  id = c.id,
                                  question = c.question
                              }).ToList();
                }
                else
                {
                    var hi = from s in db.t_question
                             where s.is_delete == false
                             select new QuestionViewModel
                             {
                                 id = s.id,
                                 question = s.question
                             };
                    hi = hi.Where(s => s.question.Contains(searchString));
                    result = hi.ToList();
                }
            }
            return result;
        }


        public static ResponResultViewModel Update(QuestionViewModel entity, long userid)
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
                        t_question question = new t_question();

                        question.question = entity.question;

                        question.created_by = userid;
                        question.created_on = DateTime.Now;

                        question.is_delete = false;

                        db.t_question.Add(question);
                        db.SaveChanges();

                        result.Entity = question;
                    }
                    //Delete
                    else
                    {
                        t_question question = db.t_question.Where(o => o.id == entity.id).FirstOrDefault();
                        if (question != null)
                        {
                            question.question = entity.question;
                            question.deleted_by = userid;
                            question.deleted_on = DateTime.Now;

                            question.is_delete = true;

                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Category not Found!";
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

        public static QuestionViewModel GetQuestion(int id)
        {
            QuestionViewModel result = new QuestionViewModel();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_question
                          where c.id == id
                          select new QuestionViewModel
                          {
                              id = c.id,
                              question = c.question

                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new QuestionViewModel();
                }
            }
            return result;
        }

    }
}
