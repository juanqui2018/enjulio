﻿using AutoMapper;
using JulioRivero.Tesis.Entities;
using JulioRivero.Tesis.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JulioRivero.Tesis.WebMVC.Controllers
{
    public class UserController : BaseController
    {
        
        // GET: User
        public ActionResult Index()
        {
            var users = Mapper.Map<IList<User>, IList<UserViewModel>>(userManager.GetAllUsers()).ToList();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var model = Mapper.Map<UserViewModel>(userManager.GetById(id));
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var model = new UserViewModel();
            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            try
            {
                var user = Mapper.Map<UserViewModel, User>(model);
                userManager.StoreUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<User, UserViewModel>(userManager.GetById(id));
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel model)
        {
            try
            {
                var user = Mapper.Map<UserViewModel, User>(model);
                userManager.StoreUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Mapper.Map<User, UserViewModel>(userManager.GetById(id));
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserViewModel model)
        {
            try
            {
                userManager.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}