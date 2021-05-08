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
    public class InventoriesController : Controller
    {
        private POSAppEntities db = new POSAppEntities();

        // GET: Inventories
        public ActionResult Index()
        {
            ViewCreateModel viewCreateModel = new ViewCreateModel();
            viewCreateModel.InventoryView = db.Inventories.ToList();
            return View(viewCreateModel);
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form, Inventory inventory)
        {
            string inventoryName = form["inventoryName"];
            string inventoryQuantity = form["inventoryQuantity"];
            string inventoryWeight = form["inventoryWeight"];
            string inventoryPrice = form["inventoryPrice"];
            string inventoryTotalPrice = form["inventoryTotalPrice"];

            Inventory obj = new Inventory();
            obj.inventoryName = inventoryName;
            obj.inventoryQuantity = Int16.Parse(inventoryQuantity);
            obj.inventoryWeight = inventoryWeight;
            obj.inventoryPrice = Int16.Parse(inventoryPrice);
            obj.inventoryTotalPrice = Int16.Parse(inventoryTotalPrice);

            db.Inventories.Add(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form, Inventory inventory)
        {
            string inventoryId = form["inventoryId"];
            string inventoryName = form["inventoryName"];
            string inventoryQuantity = form["inventoryQuantity"];
            string inventoryWeight = form["inventoryWeight"];
            string inventoryPrice = form["inventoryPrice"];
            string inventoryTotalPrice = form["inventoryTotalPrice"];

            Inventory obj = new Inventory();
            obj.inventoryId = Int16.Parse(inventoryId);
            obj.inventoryName = inventoryName;
            obj.inventoryQuantity = Int16.Parse(inventoryQuantity);
            obj.inventoryWeight = inventoryWeight;
            obj.inventoryPrice = Int16.Parse(inventoryPrice);
            obj.inventoryTotalPrice = Int16.Parse(inventoryTotalPrice);

            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Deleted(int id)
        {
            var res = db.Inventories.Where(x => x.inventoryId == id).First();
            db.Inventories.Remove(res);
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
