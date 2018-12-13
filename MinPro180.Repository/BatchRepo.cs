using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class BatchRepo
    {
        public static List<BatchViewModel> All()
        {
            List<BatchViewModel> result = new List<BatchViewModel>();
            using (var db = new MinProContext())
            {

                result = (from b in db.t_batch
                          join t in db.t_technology on b.technology_id equals t.id
                          join r in db.t_trainer on b.trainer_id equals r.id
                          join o in db.t_room on b.room_id equals o.id
                          join y in db.t_bootcamp_type on b.bootcamp_type_id equals y.id
                          where b.is_delete == false
                          select new BatchViewModel
                          {
                              id = b.id,
                              technology_id = b.technology_id,
                              techname = t.name,
                              name = b.name,
                              trainer_id = b.trainer_id,
                              trainername = r.name,
                              period_from = b.period_from,
                              period_to = b.period_to,
                              room_id = b.room_id,
                              bootcamp_type_id = b.bootcamp_type_id,
                              notes = b.notes,
                              is_delete = b.is_delete
                          }).ToList();
            }
            return result;
        }

        public static List<BatchViewModel> All(string code)
        {
            List<BatchViewModel> result = new List<BatchViewModel>();
            using (var db = new MinProContext())
            {

                result = (from b in db.t_batch
                          join t in db.t_technology on b.technology_id equals t.id
                          join r in db.t_trainer on b.trainer_id equals r.id
                          join o in db.t_room on b.room_id equals o.id
                          join y in db.t_bootcamp_type on b.bootcamp_type_id equals y.id
                          where b.is_delete == false
                          select new BatchViewModel
                          {
                              id = b.id,
                              technology_id = b.technology_id,
                              techname = t.name,
                              name = b.name,
                              trainer_id = b.trainer_id,
                              trainername = r.name,
                              period_from = b.period_from,
                              period_to = b.period_to,
                              room_id = b.room_id,
                              bootcamp_type_id = b.bootcamp_type_id,
                              notes = b.notes,
                              is_delete = b.is_delete
                          }).Where(x=>x.techname.Contains(code) || x.name.Contains(code)).ToList();
            }
            return result;
        }

        public static BatchViewModel Get(int id)
        {
            BatchViewModel result = new BatchViewModel();
            using (var db = new MinProContext())
            {
                result = (from b in db.t_batch
                          join t in db.t_technology on b.technology_id equals t.id
                          join r in db.t_trainer on b.trainer_id equals r.id
                          join o in db.t_room on b.room_id equals o.id
                          join y in db.t_bootcamp_type on b.bootcamp_type_id equals y.id
                          where b.id == id && b.is_delete == false
                          select new BatchViewModel
                          {
                              id = b.id,
                              technology_id = b.technology_id,
                              techname = t.name,
                              name = b.name,
                              trainer_id = b.trainer_id,
                              trainername = r.name,
                              period_from = b.period_from,
                              period_to = b.period_to,
                              room_id = b.room_id,
                              bootcamp_type_id = b.bootcamp_type_id,
                              notes = b.notes,
                              is_delete = b.is_delete
                          }).FirstOrDefault();

                //if (result == null)
                //{
                //    result = new CategoryViewModel();
                //}
            }
            return result;
        }

        public static ResponResultViewModel Update(BatchViewModel entity)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            if (entity.period_from != null && entity.period_to != null && entity.room_id != 0 && entity.bootcamp_type_id != 0)
            {
                try
                {
                    using (var db = new MinProContext())
                    {
                        if (entity.id == 0)
                        {
                            t_batch batch = new t_batch();
                            batch.technology_id = entity.technology_id;
                            batch.name = entity.name;
                            batch.trainer_id = entity.trainer_id;
                            batch.period_from = entity.period_from;
                            batch.period_to = entity.period_to;
                            batch.room_id = entity.room_id;
                            batch.bootcamp_type_id = entity.bootcamp_type_id;
                            batch.notes = entity.notes;
                            batch.is_delete = entity.is_delete;

                            batch.created_by = 1;
                            batch.created_on = DateTime.Now;

                            db.t_batch.Add(batch);
                            db.SaveChanges();

                            result.Entity = batch;
                        }
                        else
                        {
                            t_batch batch = db.t_batch.Where(x => x.id == entity.id).FirstOrDefault();
                            if (batch != null)
                            {
                                batch.technology_id = entity.technology_id;
                                batch.name = entity.name;
                                batch.trainer_id = entity.trainer_id;
                                batch.period_from = entity.period_from;
                                batch.period_to = entity.period_to;
                                batch.room_id = entity.room_id;
                                batch.bootcamp_type_id = entity.bootcamp_type_id;
                                batch.notes = entity.notes;
                                batch.is_delete = entity.is_delete;

                                batch.modified_by = 1;
                                batch.modified_on = DateTime.Now;

                                db.SaveChanges();
                                result.Entity = entity;
                            }
                        }
                    }

                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Can't save data!";
            }
            return result;
        }

        public static ResponResultViewModel Deact(BatchViewModel model)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            using (var db = new MinProContext())
            {
                t_batch batch = db.t_batch.Where(x => x.id == model.id).FirstOrDefault();
                batch.is_delete = false;
                batch.deleted_by = 1;
                batch.deleted_on = DateTime.Now;
                batch.name = model.name;

                try
                {
                    db.SaveChanges();
                    result.Entity = model;
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }
            return result;
        }

        public static List<ClassViewModel> ListParticipant()
        {
            List<ClassViewModel> result = new List<ClassViewModel>();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_clazz
                          join b in db.t_batch on c.batch_id equals b.id
                          join s in db.t_biodata on c.biodata_id equals s.id
                          join t in db.t_technology on b.technology_id equals t.id
                          select new ClassViewModel
                          {
                              id = c.id,
                              batch_id = c.batch_id,
                              batchname = b.name,
                              techname = t.name,
                              biodata_id = c.biodata_id,
                              bioname = s.name
                          }).ToList();
            }
            return result;
        }

        public static List<ClassViewModel> ListParticipant(string code)
        {
            List<ClassViewModel> result = new List<ClassViewModel>();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_clazz
                          join b in db.t_batch on c.batch_id equals b.id
                          join s in db.t_biodata on c.biodata_id equals s.id
                          join t in db.t_technology on b.technology_id equals t.id
                          //where t.name + " " + b.name == code
                          select new ClassViewModel
                          {
                              id = c.id,
                              batch_id = c.batch_id,
                              batchname = b.name,
                              techname = t.name,
                              biodata_id = c.biodata_id,
                              bioname = s.name
                          }).Where(x=>x.techname.Contains(code)||x.batchname.Contains(code)).ToList();
            }
            return result;
        }

        public static ClassViewModel GetBatch(int id)
        {
            ClassViewModel result = new ClassViewModel();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_clazz
                          join b in db.t_batch on c.batch_id equals b.id
                          join s in db.t_biodata on c.biodata_id equals s.id
                          join t in db.t_technology on b.technology_id equals t.id
                          where id == c.id
                          select new ClassViewModel
                          {
                              id = c.id,
                              batch_id = c.batch_id,
                              batchname = b.name,
                              techname = t.name,
                              biodata_id = c.biodata_id,
                              bioname = s.name
                          }).FirstOrDefault();

                //if (result == null)
                //{
                //    result = new CategoryViewModel();
                //}
            }
            return result;
        }

        public static ResponResultViewModel AddParticipant(ClassViewModel entity)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_clazz clazz = new t_clazz();
                    clazz.batch_id = entity.batch_id;
                    clazz.biodata_id = entity.biodata_id;
                    clazz.created_by = 1;
                    clazz.created_on = DateTime.Now;

                    db.t_clazz.Add(clazz);
                    db.SaveChanges();

                    result.Entity = clazz;

                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static ResponResultViewModel DeletePart(long id)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (MinProContext db = new MinProContext())
                {
                    t_clazz clazz = db.t_clazz.Where(x => x.id == id).FirstOrDefault();

                    if (clazz == null)
                    {
                        result.Success = false;
                        result.Message = "Participant not found";
                    }
                    else
                    {
                        result.Entity = clazz;
                        db.t_clazz.Remove(clazz);
                        db.SaveChanges();
                    }
                }
            }

            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        //public static ResponResultViewModel AddParticipant(ClassViewModel entity)
        //{
        //    ResponResultViewModel result = new ResponResultViewModel();
        //    try
        //    {
        //        using (var db = new MinProContext())
        //        {
        //            if (entity.id == 0)
        //            {
        //                t_clazz clazz = new t_clazz();
        //                clazz.batch_id = entity.batch_id;
        //                clazz.biodata_id = entity.biodata_id;

        //                db.t_batch.Add(clazz);
        //                db.SaveChanges();

        //                result.Entity = clazz;
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        result.Success = false;
        //        result.Message = e.Message;
        //    }
        //}
        //    return result;
    }
}
