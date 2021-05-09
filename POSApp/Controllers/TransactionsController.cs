using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POSApp.Models;

namespace POSApp.Controllers
{
    public class TransactionsController : Controller
    {
        private POSAppEntities db = new POSAppEntities();

        // GET: Transactions
        public ActionResult Index()
        {
            ViewCreateModel viewCreateModel = new ViewCreateModel();
            viewCreateModel.FoodView = db.Foods.ToList();
            viewCreateModel.TransactionView = db.Transactions.ToList();
            return View(viewCreateModel);
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form, Transaction transaction)
        {
            string foodName = form["foodName"];
            string foodQuantity = form["foodQuantity"];
            string foodPrice = form["foodPrice"];

            Transaction obj = new Transaction();
            obj.foodName = foodName;
            obj.foodQuantity = Int32.Parse(foodQuantity);
            obj.foodPrice = Int32.Parse(foodPrice);

            db.Transactions.Add(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "transactionId,customerName,foodName,foodQuantity,foodPrice")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deleted(int id)
        {
            var res = db.Transactions.Where(x => x.transactionId == id).First();
            db.Transactions .Remove(res);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AllDeleted(Food food)
        {
            db.Transactions.RemoveRange(db.Transactions.Where(c => c.transactionId == c.transactionId));
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
