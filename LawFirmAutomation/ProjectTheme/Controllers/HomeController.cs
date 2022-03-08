using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Sql;
using Continued;
using Continued.DAO;
using Continued.Entity;
using Continued.Transaction;
using System.Net;
using PagedList;
using System.Threading.Tasks;

namespace ProjectTheme.Controllers
{
    public class HomeController : Controller
    {
        FoyKartiDAO dAO = new FoyKartiDAO();
        FoyKarti users = new FoyKarti();
        FoyKartiTransaction transaction = new FoyKartiTransaction();

        public ActionResult Index()
        {
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            //foreach ile db.Categories deki kategorileri listemize ekliyoruz
            foreach (var item in transaction.List(users))
            {   //Text = Görünen kısımdır. Kategori ismini yazdıyoruz
                //Value = Değer kısmıdır.ID değerini atıyoruz
                kategoriler.Add(new SelectListItem { Text = item.Yetkili, Value = item.No.ToString() });
            }
            //Dinamik bir yapı oluşturup kategoriler list mizi view mize göndereceğiz
            //bunun için viewbag kullanıyorum
            ViewBag.Kategoriler = kategoriler;
            return View();
        }
        

        public ActionResult GetPaggedData(int pageNumber = 1, int pageSize = 10)
        {
            List<FoyKarti> listData = transaction.List(users);
            var pagedData = Helper.Pagination.PagedResult(listData, pageNumber, pageSize);
            return Json(pagedData, JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult Detail(int? no)
        {
            string sqlquery = "Select * from FoyKarti Where No = " + no + "";
            if (no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (transaction.Select(sqlquery, users) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Query = transaction.Select(sqlquery, users);
            return View();
        }

       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FoyKarti user, string Sonuc)
        {
            if (ModelState.IsValid)
            {
                transaction.Add(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Update(int? no)
        {
            if (no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string sqlquery = "Select * from FoyKarti Where No = " + no + " ";
            ViewBag.Query = transaction.Select(sqlquery, users);
            if (transaction.Select(sqlquery, users) == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost, ActionName("Update")]
        public ActionResult UpdateContunied(FoyKarti user, int no)
        {
            if (ModelState.IsValid)
            {
                transaction.Update(user, no);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Delete(int? no)
        {
            string sqlquery = "Select * from FoyKarti Where No = " + no + "";
            if (no == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (transaction.Select(sqlquery, users) == null)
            {
                return HttpNotFound();
            }
            ViewBag.Query = transaction.Select(sqlquery, users);
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(FoyKarti user, int no)
        {
            transaction.Delete(user, no);
            return RedirectToAction("Index");
        }

        public ActionResult FoyKartları()
        {
            return View();
        }

        public ActionResult FoyDetay()
        {
            return View();
        }
    }
}