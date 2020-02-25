using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSMSWebPortal.DbModel;

namespace CSMSWebPortal.Controllers
{
    public class eApplicationController : Controller
    {
        private CSMS_DBEntities db = new CSMS_DBEntities();

        // GET: eApplication
        public async Task<ActionResult> Index()
        {
            return View(await db.E_Application.ToListAsync());
        }

        // GET: eApplication/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Application e_Application = await db.E_Application.FindAsync(id);
            if (e_Application == null)
            {
                return HttpNotFound();
            }
            return View(e_Application);
        }

        // GET: eApplication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eApplication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Appl_ID,Appl_Course,Appl_Img,Appl_Name,Appl_Email,Appl_DOB,Appl_Contact,Appl_Fname,Appl_Mname,Appl_Address,Appl_City,Appl_State,Appl_Pin,Appl_ParentEmail,Appl_Qualification1,Appl_Qualification2,Appl_Qualification3,Appl_Lang1,Appl_Lang2,Appl_Lang3,Appl_Lang4,Appl_Relation1,Appl_Relation2,Appl_Relation3,Appl_Relation4,Appl_ExtraActivity,Appl_ExtraInfo,Appl_Date")] E_Application e_Application)
        {
            if (ModelState.IsValid)
            {
                db.E_Application.Add(e_Application);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(e_Application);
        }

        // GET: eApplication/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Application e_Application = await db.E_Application.FindAsync(id);
            if (e_Application == null)
            {
                return HttpNotFound();
            }
            return View(e_Application);
        }

        // POST: eApplication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Appl_ID,Appl_Course,Appl_Img,Appl_Name,Appl_Email,Appl_DOB,Appl_Contact,Appl_Fname,Appl_Mname,Appl_Address,Appl_City,Appl_State,Appl_Pin,Appl_ParentEmail,Appl_Qualification1,Appl_Qualification2,Appl_Qualification3,Appl_Lang1,Appl_Lang2,Appl_Lang3,Appl_Lang4,Appl_Relation1,Appl_Relation2,Appl_Relation3,Appl_Relation4,Appl_ExtraActivity,Appl_ExtraInfo,Appl_Date")] E_Application e_Application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e_Application).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(e_Application);
        }

        // GET: eApplication/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            E_Application e_Application = await db.E_Application.FindAsync(id);
            if (e_Application == null)
            {
                return HttpNotFound();
            }
            return View(e_Application);
        }

        // POST: eApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            E_Application e_Application = await db.E_Application.FindAsync(id);
            db.E_Application.Remove(e_Application);
            await db.SaveChangesAsync();
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
