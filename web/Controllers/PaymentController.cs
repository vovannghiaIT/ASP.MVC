using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Context;

namespace web.Models
{
    public class PaymentController : Controller
    {
        QLBHEntities2 objQLBHEntities2 = new QLBHEntities2();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                //gan du lieu cho Order
                Order  objOrder = new Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("ddMMyyyyHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objQLBHEntities2.Orders.Add(objOrder);
                //luu vao bang Order
                objQLBHEntities2.SaveChanges();
                //Lay OrderId vua tao luu vao bang OrderDetail
                int intOrderId = objOrder.Id;

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objQLBHEntities2.OrderDetails.AddRange(lstOrderDetail);
                objQLBHEntities2.SaveChanges();
            }
            return View();
        }
    }
}