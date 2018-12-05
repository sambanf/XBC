﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinPro180.DataModel;
using MinPro180.ViewModel;

namespace MinPro180.Repository
{
    public class MenuRepo
    {
        public static List<MenuViewModel> All()
        {
            List<MenuViewModel> result = new List<MenuViewModel>();
            using (var db = new MinProContext())
            {
                result = (from m in db.t_menu
                          select new MenuViewModel
                          {
                              id = m.id,
                              code = m.code,
                              title = m.title,
                              description = m.description,
                              image_url = m.image_url,
                              menu_order = m.menu_order,
                              menu_parent = m.menu_parent,
                              menu_url = m.menu_url,
                              active = m.active

                          }).ToList();
            }
            return result;
        }
        public static MenuViewModel GetMenu(int id)
        {
            MenuViewModel result = new MenuViewModel();
            using (var db = new MinProContext())
            {
                result = (from m in db.t_menu
                          where m.id == id
                          select new MenuViewModel
                          {
                              id = m.id,
                              code = m.code,
                              title = m.title,
                              description = m.description,
                              image_url = m.image_url,
                              menu_order = m.menu_order,
                              menu_parent = m.menu_parent,
                              menu_url = m.menu_url,
                              active = m.active

                          }).FirstOrDefault();
            }
            return result;
        }

        public static ResponResultViewModel Update(MenuViewModel entity)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_menu menu = new t_menu();
                        menu.code = entity.code;
                        menu.title = entity.title;
                        menu.description = entity.description;
                        menu.image_url = entity.image_url;
                        menu.menu_order = entity.menu_order;
                        menu.menu_parent = entity.menu_parent;
                        menu.menu_url = entity.menu_url;
                        menu.created_by = entity.id;
                        menu.created_on = DateTime.Now;

                        db.t_menu.Add(menu);
                        db.SaveChanges();

                        result.Entity = menu;

                    }
                    else
                    {
                        t_menu menu = db.t_menu.Where(x => x.id == entity.id).FirstOrDefault();
                        if (menu != null)
                        {
                            menu.code = entity.code;
                            menu.title = entity.title;
                            menu.description = entity.description;
                            menu.image_url = entity.image_url;
                            menu.menu_order = entity.menu_order;
                            menu.menu_parent = entity.menu_parent;
                            menu.menu_url = entity.menu_url;
                            menu.created_by = entity.id;
                            menu.created_on = DateTime.Now;

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
            return result;
        }
    }
}
