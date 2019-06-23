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
            fillMenu();
            ViewBag.LastNameUser = lastName;
           
            var users = Mapper.Map<IList<User>, IList<UserViewModel>>(userManager.GetAllUsers()).ToList();
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<UserViewModel>(userManager.GetById(id));
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var model = new UserViewModel();
            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
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
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<User, UserViewModel>(userManager.GetById(id));
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel model)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
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
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<User, UserViewModel>(userManager.GetById(id));
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserViewModel model)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
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
        //
        public ActionResult CreateLogin(UserViewModel model)
        {
            fillMenu();
            return View();
        }

        [HttpPost]
        public ActionResult CreateLogin(string usr, string pwd)
        {
            fillMenu();
            var model = Mapper.Map<User, UserViewModel>(userManager.GetByCi(pwd));
            if (model != null)
            {
                if (pwd.CompareTo(model.Ci) == 0  && usr.ToUpper().CompareTo(model.SecondName.ToUpper()) == 0)
                {
                    lastName = model.SecondName;
                    ViewBag.LastNameUser = model.SecondName;
                    //return View("Contact", "_LayoutAdmin", model);
                    return RedirectToAction("Index","Impairment");
                }
                else
                {
                    ViewBag.messageLogin = "Verifique las credenciales.";
                }
            }
            else
            {
                ViewBag.messageLogin = "Verifique las credenciales.";
            }
            
            return View();
        }
        public ActionResult Contact(UserViewModel model)
        {
            fillMenu();
            ViewBag.LastNameUser = model.SecondName;
            return View();
        }
        //
    }
}