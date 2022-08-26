using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;
using static web.Common;

namespace web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        void LoadData()
        {
            Common objCommon = new Common();
            // lấy dữ liệu dưới db
            var lstCat = objQLBHEntities2.Categories.ToList();
            //convert  sang select list dạng value,text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
         
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
        public ActionResult Detail(int Id)
        {
            this.LoadData();
            var objProduct = objQLBHEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
      




    }
}