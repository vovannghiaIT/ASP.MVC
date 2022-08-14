using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using web;
using web.Context;
using static web.Common;

namespace VoVanNghia_2120110017.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        public ActionResult Index()
        {
            var listUser = objQLBHEntities2.Users.ToList();
            return View(listUser);
        }
        void LoadData()
        {
            Common objCommon = new Common();
            var lstUser = objQLBHEntities2.Users.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtUser = converter.ToDataTable(lstUser);
            ViewBag.ListUser = objCommon.ToSelectList(dtUser, "Id", "IsAdmin");


            List<UserType> lstUserType = new List<UserType>();
            UserType objUserType = new UserType();
            objUserType.Id = 1;
            objUserType.IsAdmin = "Admin";
            lstUserType.Add(objUserType);

            objUserType = new UserType();
            objUserType.Id = 2;
            objUserType.IsAdmin = "Khách hàng";
            lstUserType.Add(objUserType);

            DataTable dtUserType = converter.ToDataTable(lstUserType);
            ViewBag.UserType = objCommon.ToSelectList(dtUserType, "Id", "IsAdmin");

        }
        //[ValidateInput(false)]
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    this.LoadData();
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(User User)
        //{
        //    this.LoadData();


        //    return View(User);
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            var User = objQLBHEntities2.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(User);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var User = objQLBHEntities2.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(User);
        }
        [HttpPost]
        public ActionResult Delete(User objuser)
        {
            var objUser = objQLBHEntities2.Users.Where(n => n.Id == objuser.Id).FirstOrDefault();
            objQLBHEntities2.Users.Remove(objUser);
            objQLBHEntities2.SaveChanges();
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            this.LoadData();

            var User = objQLBHEntities2.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(User);
        }
        // mã hóa pass word
        //public static string GetMD5(string str)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = Encoding.UTF8.GetBytes(str);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;
        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x2");
        //    }
        //    return byte2String;

        //}

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, User objUser)
        {
            objQLBHEntities2.Entry(objUser).State = EntityState.Modified;
            objQLBHEntities2.SaveChanges();
           
            return RedirectToAction("Index");
        }


    }
}