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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        public ActionResult Index()
        {
            var listCategory = objQLBHEntities2.Categories.ToList();
            return View(listCategory);
        }
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();

        }
        // sua loi sckeditorjs
        [ValidateInput(false)]
        //end
        [HttpPost]
            public ActionResult Create(Category category)
            {
                this.LoadData();
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (category.ImageUpload != null)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(category.ImageUpload.FileName);
                            string extension = Path.GetExtension(category.ImageUpload.FileName);
                            fileName = fileName + extension;
                            category.Avatar = fileName;
                            category.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category"), fileName));
                        }
                        category.CreatedOnUtc = DateTime.Now;
                        objQLBHEntities2.Categories.Add(category);
                        objQLBHEntities2.SaveChanges();
                      

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(category);
            }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = objQLBHEntities2.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = objQLBHEntities2.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Category objCat)
        {
            var objCategory = objQLBHEntities2.Categories.Where(n => n.Id == objCat.Id).FirstOrDefault();
            objQLBHEntities2.Categories.Remove(objCategory);
            objQLBHEntities2.SaveChanges();
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
         
            this.LoadData();    

            var category = objQLBHEntities2.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, Category objCategory)
        {
            
            if (objCategory.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objCategory.Avatar = fileName;
                objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/category"), fileName));
            }
            objCategory.UpdatedOnUtc = DateTime.Now;
            objQLBHEntities2.Entry(objCategory).State = EntityState.Modified;
            objQLBHEntities2.SaveChanges();
        

            return RedirectToAction("Index");
        }
        void LoadData()
        {

            Common objCommon = new Common();

            var lstCat = objQLBHEntities2.Categories.ToList();

            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            List<CategoryType> lstCategoryType = new List<CategoryType>();
            CategoryType objCategoryType = new CategoryType();
            objCategoryType.Id = 1;
            objCategoryType.Name = "Danh mục phổ biến";
            lstCategoryType.Add(objCategoryType);



            DataTable dtCategoryType = converter.ToDataTable(lstCategoryType);
            ViewBag.CategoryType = objCommon.ToSelectList(dtCategoryType, "Id", "Name");


        }
    }
}