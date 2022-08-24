using Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;
using System.Security.Cryptography;
using System.Text;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();
        public ActionResult Index()
        {
            HomeModel objHomeModel= new HomeModel();
             objHomeModel.ListProduct = objQLBHEntities2.Products.ToList();
            objHomeModel.ListCategory = objQLBHEntities2.Categories.ToList();
            return View(objHomeModel);
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application descriptin page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = objQLBHEntities2.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    _user.IsAdmin = false; //IsAdmin = false = người dùng
                    objQLBHEntities2.Configuration.ValidateOnSaveEnabled = false;
                    // add user
                    objQLBHEntities2.Users.Add(_user);
                    //lưu thông tin lại
                    objQLBHEntities2.SaveChanges();
                   // trả về trang chủ
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại";
                   

                    return View();
                }

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = objQLBHEntities2.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().LastName + " " + data.FirstOrDefault().FirstName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().Id;
                    
                   
                    return RedirectToAction("Index");
                }
                else
                {
                  
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
         //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        // hàm mã hóa Password
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;

        }
       


    }
}