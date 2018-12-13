using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class RoomRepo
    {
        // mengakses semua RoomViewModel dan dijadikan List 
        public static List<RoomViewModel> All()
        {
            List<RoomViewModel> result = new List<RoomViewModel>();
            using (var db = new MinProContext())
            {
                result = (from roomItem in db.t_room
                          join officeItem in db.t_office
                          on roomItem.office_id equals officeItem.id
                          //where roomItem.id == id
                          select new RoomViewModel
                          {
                              id = roomItem.id,
                              code = roomItem.code,
                              name = roomItem.name,
                              capacity = roomItem.capacity,
                              any_projector = roomItem.any_projector,
                              notes = roomItem.notes,
                              office_id = roomItem.office_id,
                              office_name = officeItem.name,
                              active = roomItem.active
                          }).ToList();
            }

            return result;
        }

        // mengakses item individual dari Room
        public static RoomViewModel GetRoom(int id)
        {
            RoomViewModel result = new RoomViewModel();
            using (var db = new MinProContext())
            {
                result = (from roomItem in db.t_room
                          join officeItem in db.t_office
                          on roomItem.office_id equals officeItem.id
                          where roomItem.id == id
                          select new RoomViewModel
                          {
                              id = roomItem.id,
                              code = roomItem.code,
                              name = roomItem.name,
                              capacity = roomItem.capacity,
                              any_projector = roomItem.any_projector,
                              notes = roomItem.notes,
                              office_id = roomItem.office_id,
                              office_name = officeItem.name,
                              active = roomItem.active
                          }).FirstOrDefault();
            }

            return result != null ? result : new RoomViewModel();
        }

        // Untuk melakukan pembuatan item baru dan perubahan item yang sudah ada
        public static ResponResultViewModel Update(RoomViewModel entity)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    // membuat item baru
                    if (entity.id == 0)
                    {
                        t_room room = new t_room();
                        room.id = entity.id;
                        room.code = entity.code;
                        room.name = entity.name;
                        room.capacity = entity.capacity;
                        room.any_projector = entity.any_projector;
                        room.notes = entity.notes;
                        room.office_id = entity.office_id;

                        // user yang membuat data
                        room.created_by = 1;
                        room.created_on = DateTime.Now;

                        // simpan ke result
                        result.Entity = entity;

                        // menyimpan ke obyek DbContext dan menyimpan perubahan data
                        db.t_room.Add(room);
                        db.SaveChanges();
                    }
                    // merubah item lama
                    else
                    {
                        t_room room = db.t_room.Where(item => item.id == entity.id).FirstOrDefault();
                        if (room != null)
                        {
                            room.id = entity.id;
                            room.code = entity.code;
                            room.name = entity.name;
                            room.capacity = entity.capacity;
                            room.any_projector = entity.any_projector;
                            room.notes = entity.notes;
                            room.office_id = entity.office_id;

                            // user yang merubah data
                            room.modified_by = 1;
                            room.modified_on = DateTime.Now;

                            // simpan ke obyek result
                            result.Entity = entity;

                            // simpan perubahan data di database
                            db.SaveChanges();
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Item not found";
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

        // Untuk melakukan deaktivasi item
        public static ResponResultViewModel Deactivate(RoomViewModel entity)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_room room = db.t_room.Where(item => item.id == entity.id).FirstOrDefault();
                    if (room != null)
                    {
                        room.active = false;

                        // user yang merubah
                        room.modified_by = 1;
                        room.modified_on = DateTime.Now;

                        result.Entity = entity;

                        db.SaveChanges();
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Item not found";
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
