using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjMVC_Aula5;

namespace ProjMVC_Aula5.Controllers
{
    public class TB_FABRICANTEController : Controller
    {
        private VendaDBEntities db = new VendaDBEntities();

        // GET: TB_FABRICANTE
        public ActionResult Index()
        {
            return View(db.TB_FABRICANTE.ToList());
        }

        // GET: TB_FABRICANTE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_FABRICANTE tB_FABRICANTE = db.TB_FABRICANTE.Find(id);
            if (tB_FABRICANTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_FABRICANTE);
        }

        // GET: TB_FABRICANTE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_FABRICANTE/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cidade")] TB_FABRICANTE tB_FABRICANTE)
        {
            if (ModelState.IsValid)
            {
                db.TB_FABRICANTE.Add(tB_FABRICANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_FABRICANTE);
        }

        // GET: TB_FABRICANTE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_FABRICANTE tB_FABRICANTE = db.TB_FABRICANTE.Find(id);
            if (tB_FABRICANTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_FABRICANTE);
        }

        // POST: TB_FABRICANTE/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cidade")] TB_FABRICANTE tB_FABRICANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_FABRICANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_FABRICANTE);
        }

        // GET: TB_FABRICANTE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_FABRICANTE tB_FABRICANTE = db.TB_FABRICANTE.Find(id);
            if (tB_FABRICANTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_FABRICANTE);
        }

        // POST: TB_FABRICANTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_FABRICANTE tB_FABRICANTE = db.TB_FABRICANTE.Find(id);
            db.TB_FABRICANTE.Remove(tB_FABRICANTE);
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
