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
        public static List<MenuViewModel> All(string searchString)
        {
            List<MenuViewModel> result = new List<MenuViewModel>();
            using (var db = new MinProContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    result = (from m in db.t_menu
                          where m.active == true
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
                else
                {
                    var src = from m in db.t_menu
                              where m.active == true
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

                              };
                    src = src.Where(s => s.title.Contains(searchString));
                    result = src.ToList();
                }
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

        public static ResponResultViewModel Update(MenuViewModel entity, long userid)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            entity.code = GetNewMenu();
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
                        menu.created_by = userid;
                        menu.created_on = DateTime.Now;
                        menu.active = entity.active;

                        db.t_menu.Add(menu);
                        db.SaveChanges();

                        result.Entity = menu;

                    }
                    else
                    {
                        t_menu menu = db.t_menu.Where(x => x.id == entity.id).FirstOrDefault();
                        if (menu != null)
                        {
                            menu.title = entity.title;
                            menu.description = entity.description;
                            menu.image_url = entity.image_url;
                            menu.menu_order = entity.menu_order;
                            menu.menu_parent = entity.menu_parent;
                            menu.menu_url = entity.menu_url;
                            menu.created_by = userid;
                            menu.created_on = DateTime.Now;
                            menu.active = entity.active;

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
        public static ResponResultViewModel Deactive(MenuViewModel entity, long userid)
        {
            //untuk deactive
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_menu menu = db.t_menu.Where(x => x.id == entity.id).FirstOrDefault();
                    if (menu != null)
                    {
                        menu.active = false;
                        menu.modified_by = userid;
                        menu.modified_on = DateTime.Now;
                        db.SaveChanges();
                        result.Entity = entity;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "user not found!";
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

        public static string GetNewMenu()
        {
            string newMenu = String.Format("M");

            using (var db = new MinProContext())
            {
                var result = (from m in db.t_menu
                              where m.code.Contains(newMenu) //contains: check newRev ada atau tidak pada bulan dan tahun itu
                              select new { Code = m.code }).OrderByDescending(x => x.Code).FirstOrDefault();
                if (result != null)
                {
                    string[] lastRef = result.Code.Split('M');
                    newMenu += (int.Parse(lastRef[1]) + 1).ToString("D4");
                }
                else
                {
                    newMenu += "0001";
                }
            }
            return newMenu;
        }
    }
}
