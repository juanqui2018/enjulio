using AutoMapper;
using JulioRivero.Tesis.Biz;
using JulioRivero.Tesis.Entities;
using JulioRivero.Tesis.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JulioRivero.Tesis.WebMVC.Controllers
{
    public class DeficiencyController : BaseController
    {
        public static string temporal = string.Empty;
        public DeficiencyController()
        {
            fillMenu();
        }

        public string ReducirEspaciado(string Cadena)
        {
            if (Cadena.Length > 3)
            {
                while (Cadena.Contains("  "))
                {
                    Cadena = Cadena.Replace("  ", " ");
                }
                while (Cadena.Contains(" "))
                {
                    Cadena = Cadena.Replace(" ", "_");
                }
            }

            return Cadena;
        }
        // GET: Deficiency
        public ActionResult Index()
        {
            ViewBag.LastNameUser = lastName;
            var deficiencys = Mapper.Map<IList<Deficiency>, IList<DeficiencyViewModel>>(deficiencyManager.GetAllDeficiencys()).ToList();

            string describ, prevent;
            int start = 0, sizeString = 100;
            foreach (var item in deficiencys)
            {
                if (item.Introduction.Length > sizeString)
                {
                    describ = item.Introduction.Substring(start, sizeString);
                    item.Introduction = string.Format(describ + "...");
                }
                if (item.Symptom.Length > sizeString)
                {
                    describ = item.Symptom.Substring(start, sizeString);
                    item.Symptom = string.Format(describ + "...");
                }
                if (item.Prevention.Length > sizeString)
                {
                    prevent = item.Prevention.Substring(start, sizeString);
                    item.Prevention = string.Format(prevent + "...");
                }
            }

            return View(deficiencys);
        }

        // GET: Deficiency/Details/5
        public ActionResult Details(int id)
        {
            var model = Mapper.Map<DeficiencyViewModel>(deficiencyManager.GetById(id));
            return View(model);
        }

        // GET: Deficiency/Create
        public ActionResult Create()
        {
            ViewBag.LastNameUser = lastName;
            var model = new DeficiencyViewModel();
            return View(model);
        }

        // POST: Deficiency/Create
        [HttpPost]
        public ActionResult Create(DeficiencyViewModel model, HttpPostedFileBase fileImg)
        {
            ViewBag.LastNameUser = lastName;
            if (fileImg != null)
            {
                if (fileImg.ContentLength > 0)
                {
                    if (Path.GetExtension(fileImg.FileName).ToLower() == ".jpg"
                        || Path.GetExtension(fileImg.FileName).ToLower() == ".png"
                        || Path.GetExtension(fileImg.FileName).ToLower() == ".gif"
                        || Path.GetExtension(fileImg.FileName).ToLower() == ".jpeg")
                    {
                        //guardar fileImg
                        string extension = Path.GetExtension(fileImg.FileName);
                        string archivo = (ReducirEspaciado(model.Name.ToString())).ToLower();
                        string pathPlusFile = string.Format("~/Uploads/" + archivo + extension);
                        fileImg.SaveAs(Server.MapPath(pathPlusFile));
                        model.FileImage = pathPlusFile;
                        // ViewBag.UploadSuccess = true;
                    }
                }
            }
            else
            {
                string pathPlusFile = string.Format("~/Uploads/" + "image_not_found.png");
                model.FileImage = pathPlusFile;
            }
            try
            {
                var deficiency = Mapper.Map<DeficiencyViewModel, Deficiency>(model);
                deficiencyManager.StoreDeficiency(deficiency);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ooops, : " + e);
                return View();
            }
        }

        // GET: Deficiency/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<Deficiency, DeficiencyViewModel>(deficiencyManager.GetById(id));
            temporal = model.FileImage;
            return View(model);
        }

        // POST: Deficiency/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DeficiencyViewModel model, HttpPostedFileBase fileImg)
        {
            ViewBag.LastNameUser = lastName;
            if (fileImg != null)
            {
                if (fileImg.ContentLength > 0)
                {
                    if (Path.GetExtension(fileImg.FileName).ToLower() == ".jpg"
                        || Path.GetExtension(fileImg.FileName).ToLower() == ".png"
                        || Path.GetExtension(fileImg.FileName).ToLower() == ".gif"
                        || Path.GetExtension(fileImg.FileName).ToLower() == ".jpeg")
                    {
                        //guardar fileImg
                        string extension = Path.GetExtension(fileImg.FileName);
                        string archivo = (ReducirEspaciado(model.Name)).ToLower();
                        string pathPlusFile = string.Format("~/Uploads/" + archivo + extension);
                        fileImg.SaveAs(Server.MapPath(pathPlusFile));
                        model.FileImage = pathPlusFile;
                        // ViewBag.UploadSuccess = true;
                    }
                }
            }
            else
            {
                model.FileImage = temporal;
            }
            try
            {
                var deficiency = Mapper.Map<DeficiencyViewModel, Deficiency>(model);
                deficiencyManager.StoreDeficiency(deficiency);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Deficiency/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<Deficiency, DeficiencyViewModel>(deficiencyManager.GetById(id));
            return View(model);
        }

        // POST: Deficiency/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DeficiencyViewModel model)
        {
            ViewBag.LastNameUser = lastName;
            try
            {
                deficiencyManager.DeleteDeficiency(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}