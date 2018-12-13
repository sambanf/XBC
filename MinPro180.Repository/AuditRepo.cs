using MinPro180.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    class AuditRepo
    {
        public static void Insert(string json_insert, long userid)
        {
            //Untuk create dan Insert ke database
            try
            {
                using (var db = new MinProContext())
                {

                    t_audit_log log = new t_audit_log();
                    log.type = "CREATE";
                    log.json_insert = json_insert;
                    log.created_by = userid;
                    log.created_on = DateTime.Now;

                    db.t_audit_log.Add(log);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void Modify(string json_after, string json_before, long userid)
        {
            //Untuk Update, Deactivate,isDelete
            try
            {
                using (var db = new MinProContext())
                {
                    t_audit_log log = new t_audit_log();
                    log.type = "MODIFY";
                    log.json_after = json_after;
                    log.json_before = json_before;
                    log.created_by = userid;
                    log.created_on = DateTime.Now;
                    db.t_audit_log.Add(log);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void Delete(string json_insert, long userid)
        {
            //Delete fisik DATABASE
            try
            {
                using (var db = new MinProContext())
                {
                    t_audit_log log = new t_audit_log();
                    log.type = "DELETE";
                    log.json_insert = json_insert;
                    log.created_by = userid;
                    log.created_on = DateTime.Now;
                    db.t_audit_log.Add(log);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
