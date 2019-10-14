using AutoMapper;
using JulioRivero.Tesis.Entities;
using JulioRivero.Tesis.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JulioRivero.Tesis.WebMVC.Controllers
{
    public class IntoPreventionController : BaseController
    {
        public static string temporal = string.Empty;
        public IntoPreventionController()
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

        // GET: IntoPrevention
        public ActionResult Index()
        {
            ViewBag.LastNameUser = lastName;
            var intoPreventions = Mapper.Map<IList<IntoPrevention>, IList<IntoPreventionViewModel>>(intoPreventionManager.GetAllIntoPreventions()).ToList();

            string describ, prevent;
            int start = 0, sizeString = 100;
            foreach (var item in intoPreventions)
            {
                if (item.Description.Length > sizeString)
                {
                    describ = item.Description.Substring(start, sizeString);
                    item.Description = string.Format(describ + "...");
                }
                if (item.Prevention.Length > sizeString)
                {
                    prevent = item.Prevention.Substring(start, sizeString);
                    item.Prevention = string.Format(prevent + "...");
                }
            }

            return View(intoPreventions);
        }

        // GET: IntoPrevention/Details/5
        public ActionResult Details(int id)
        {
            var model = Mapper.Map<IntoPreventionViewModel>(intoPreventionManager.GetById(id));
            return View(model);
        }

        // GET: IntoPrevention/Create
        public ActionResult Create()
        {
            ViewBag.LastNameUser = lastName;
            var model = new IntoPreventionViewModel();
            return View(model);
        }

        // POST: IntoPrevention/Create
        [HttpPost]
        public ActionResult Create(IntoPreventionViewModel model, HttpPostedFileBase fileImg)
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
                        string archivo = (ReducirEspaciado(model.Title)).ToLower();
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
                var intoPrevention = Mapper.Map<IntoPreventionViewModel, IntoPrevention>(model);
                intoPreventionManager.StoreIntoPrevention(intoPrevention);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: IntoPrevention/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<IntoPrevention, IntoPreventionViewModel>(intoPreventionManager.GetById(id));
            temporal = model.FileImage.ToString();
            return View(model);
        }

        // POST: IntoPrevention/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IntoPreventionViewModel model, HttpPostedFileBase fileImg)
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
                        string archivo = (ReducirEspaciado(model.Title)).ToLower();
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
                var intoPrevention = Mapper.Map<IntoPreventionViewModel, IntoPrevention>(model);
                intoPreventionManager.StoreIntoPrevention(intoPrevention);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: IntoPrevention/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.LastNameUser = lastName;
            var model = Mapper.Map<IntoPrevention, IntoPreventionViewModel>(intoPreventionManager.GetById(id));
            return View(model);
        }

        // POST: IntoPrevention/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IntoPreventionViewModel model)
        {
            ViewBag.LastNameUser = lastName;
            try
            {
                intoPreventionManager.DeleteIntoPrevention(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}