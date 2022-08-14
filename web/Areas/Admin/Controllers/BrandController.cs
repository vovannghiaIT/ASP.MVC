using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web;
using web.Context;
using static web.Common;

namespace VoVanNghia_2120110017.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        public ActionResult Index()
        {
            var listBrand = objQLBHEntities2.Brands.ToList();
            return View(listBrand);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = objQLBHEntities2.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = objQLBHEntities2.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Brand  objCat)
        {
            var objBrand = objQLBHEntities2.Brands.Where(n => n.Id == objCat.Id).FirstOrDefault();
            objQLBHEntities2.Brands.Remove(objBrand);
            objQLBHEntities2.SaveChanges();
           

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (brand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(brand.ImageUpload.FileName);
                        string extension = Path.GetExtension(brand.ImageUpload.FileName);
                        fileName = fileName + extension;
                        brand.Avatar = fileName;
                        brand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }
                    brand.CreatedOnUtc = DateTime.Now;
                    objQLBHEntities2.Brands.Add(brand);
                    objQLBHEntities2.SaveChanges();
            
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            return View(brand);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Brand = objQLBHEntities2.Brands.Where(n => n.Id == id).FirstOrDefault();
            return View(Brand);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, Brand objBrand)
        {
            if (objBrand.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
            }
            objBrand.UpdateOnUtc = DateTime.Now;
            objQLBHEntities2.Entry(objBrand).State = EntityState.Modified;
            objQLBHEntities2.SaveChanges();
          

            return RedirectToAction("Index");
        }
    }

}