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

using Web;
using static web.Common;

namespace VoVanNghia_2120110017.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        public ActionResult Index()
        {
            var listProduct = objQLBHEntities2.Products.ToList();
            return View(listProduct);
        }
        void LoadData()
        {
            Common objCommon = new Common();  
            // lấy dữ liệu dưới db
            var lstCat = objQLBHEntities2.Categories.ToList();
            //convert  sang select list dạng value,text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
             ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");
            // lấy dữ diệu thương hiệu dưới db
            var lstBrand = objQLBHEntities2.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //convert sang select list dang value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");
            //typeoid
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");


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
        public ActionResult Create(Product objProduct)
        {

            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    objQLBHEntities2.Products.Add(objProduct);
                    objQLBHEntities2.SaveChanges();
                 
                   
                    return RedirectToAction("Index");

                }
                catch
                {
                    return View(objProduct);
                }
            }
            return View(objProduct);
        }

        [HttpGet]
        public ActionResult Details(int Id)   
        {
            var obproduct = objQLBHEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(obproduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
         
            var obproduct = objQLBHEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
            
            return View(obproduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objproduct)
        {
       
            var obproduct = objQLBHEntities2.Products.Where(n => n.Id == objproduct.Id).FirstOrDefault();
            objQLBHEntities2.Products.Remove(obproduct);
            objQLBHEntities2.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.LoadData();
            var product = objQLBHEntities2.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Product objProduct)
        {
           
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
            }
            objQLBHEntities2.Entry(objProduct).State = EntityState.Modified;
            objProduct.UpdatedOnUtc = DateTime.Now;
            objQLBHEntities2.SaveChanges();
          

            return RedirectToAction("Index");
        }
    }
    }
