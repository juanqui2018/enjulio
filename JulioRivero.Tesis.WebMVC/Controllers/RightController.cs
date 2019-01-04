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
    public class RightController : BaseController
    {
        // GET: Right
        public ActionResult Index()
        {
            var rights = Mapper.Map<IList<Right>, IList<RightViewModel>>(rightManager.GetAllRights()).ToList();
            return View(rights);
        }

        // GET: Right/Details/5
        public ActionResult Details(int id)
        {
            var model = Mapper.Map<RightViewModel>(rightManager.GetById(id));
            return View(model);
        }

        // GET: Right/Create
        public ActionResult Create()
        {
            var model = new RightViewModel();
            return View(model);
        }

        // POST: Right/Create
        [HttpPost]
        public ActionResult Create(RightViewModel model)
        {
            try
            {
                var right = Mapper.Map<RightViewModel, Right>(model);
                rightManager.StoreRight(right);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Right/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Mapper.Map<Right, RightViewModel>(rightManager.GetById(id));
            return View(model);
        }

        // POST: Right/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RightViewModel model)
        {
            try
            {
                var right = Mapper.Map<RightViewModel, Right>(model);
                rightManager.StoreRight(right);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Right/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Mapper.Map<Right, RightViewModel>(rightManager.GetById(id));
            return View(model);
        }

        // POST: Right/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RightViewModel model)
        {
            try
            {
                rightManager.DeleteRight(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}