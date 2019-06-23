﻿using AutoMapper;
using JulioRivero.Tesis.Biz;
using JulioRivero.Tesis.Entities;
using JulioRivero.Tesis.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JulioRivero.Tesis.WebMVC.Controllers
{
    public class ImpairmentController : BaseController
    {
        // GET: Imparirment
        public ActionResult Index()
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var imparirments = Mapper.Map<IList<Impairment>, IList<ImpairmentViewModel>>(ImpairmentManager.GetAllImpairments()).ToList();
            return View(imparirments);
        }
        enum Impairments  //quizas llevar esto a un lugar mas organizado
        {
            Adquiridas = 1,
            Audiovisuales = 2,
            Cognitivas = 3,
            Congénitas = 4,
            Hereditarias = 5,
            Fisicomotoras = 6
        }
        // GET: Imparirment/Details/5
        public ActionResult Details(int id)
        {
            fillMenu();
          
            var model = Mapper.Map<ImpairmentViewModel>(ImpairmentManager.GetById(id));
           // var intoPreventions = Mapper.Map<IList<IntoPrevention>, IList<IntoPreventionViewModel>>(intoPreventionManager.GetAllIntoPreventions()).ToList();

            var deficiencis = Mapper.Map<IList<Deficiency>, IList<DeficiencyViewModel>>(deficiencyManager.GetAllDeficiencys()).ToList();

            if (id == (int)Impairments.Adquiridas)
            {
                var ownList = deficiencis.ToList().Where(c => c.Kind.CompareTo(Impairments.Adquiridas.ToString()) == 0);
                ViewBag.ownData = ownList;
            }
            else if (id == (int)Impairments.Audiovisuales)
            {
                var ownList = deficiencis.ToList().Where(c => c.Kind.CompareTo(Impairments.Audiovisuales.ToString()) == 0);
                ViewBag.ownData = ownList;
            }
            else if (id == (int)Impairments.Cognitivas)
            {
                var ownList = deficiencis.ToList().Where(c => c.Kind.CompareTo(Impairments.Cognitivas.ToString()) == 0);
                ViewBag.ownData = ownList;
            }

            else if (id == (int)Impairments.Congénitas)
            {
                var ownList = deficiencis.ToList().Where(c => c.Kind.CompareTo(Impairments.Congénitas.ToString()) == 0);
                ViewBag.ownData = ownList;
            }
            else if (id == (int)Impairments.Fisicomotoras)
            {
                var ownList = deficiencis.ToList().Where(c => c.Kind.CompareTo(Impairments.Fisicomotoras.ToString()) == 0);
                ViewBag.ownData = ownList;
            }
            else if (id == (int)Impairments.Hereditarias)
            {
                var ownList = deficiencis.ToList().Where(c => c.Kind.CompareTo(Impairments.Hereditarias.ToString()) == 0);
                ViewBag.ownData = ownList;
            }
            return View(model);
        }

        // GET: Imparirment/Create
        public ActionResult Create()
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var model = new ImpairmentViewModel();
            return View(model);
        }

        // POST: Imparirment/Create
        [HttpPost]
        public ActionResult Create(ImpairmentViewModel model)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            try
            {
                var impairment = Mapper.Map<ImpairmentViewModel, Impairment>(model);
                ImpairmentManager.StoreImpairment(impairment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Imparirment/Edit/5
        public ActionResult Edit(int id)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<Impairment, ImpairmentViewModel>(ImpairmentManager.GetById(id));
            return View(model);
        }

        // POST: Imparirment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ImpairmentViewModel model)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            try
            {
                var impairment = Mapper.Map<ImpairmentViewModel, Impairment>(model);
                ImpairmentManager.StoreImpairment(impairment);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Imparirment/Delete/5
        public ActionResult Delete(int id)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<Impairment, ImpairmentViewModel>(ImpairmentManager.GetById(id));
            return View(model);
        }

        // POST: Imparirment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ImpairmentViewModel model)
        {
            fillMenu();
            ViewBag.LastNameUser = lastName;
            try
            {
                ImpairmentManager.DeleteImpairment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}