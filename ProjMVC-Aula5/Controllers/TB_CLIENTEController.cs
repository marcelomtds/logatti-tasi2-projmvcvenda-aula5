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
    public class TB_CLIENTEController : Controller
    {
        private VendaDBEntities db = new VendaDBEntities();

        // GET: TB_CLIENTE
        public ActionResult Index()
        {
            return View(db.TB_CLIENTE.ToList());
        }

        // GET: TB_CLIENTE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CLIENTE tB_CLIENTE = db.TB_CLIENTE.Find(id);
            if (tB_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_CLIENTE);
        }

        // GET: TB_CLIENTE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_CLIENTE/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,Endereco,Email")] TB_CLIENTE tB_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.TB_CLIENTE.Add(tB_CLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_CLIENTE);
        }

        // GET: TB_CLIENTE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CLIENTE tB_CLIENTE = db.TB_CLIENTE.Find(id);
            if (tB_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_CLIENTE);
        }

        // POST: TB_CLIENTE/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,Endereco,Email")] TB_CLIENTE tB_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_CLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_CLIENTE);
        }

        // GET: TB_CLIENTE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_CLIENTE tB_CLIENTE = db.TB_CLIENTE.Find(id);
            if (tB_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_CLIENTE);
        }

        // POST: TB_CLIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_CLIENTE tB_CLIENTE = db.TB_CLIENTE.Find(id);
            db.TB_CLIENTE.Remove(tB_CLIENTE);
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
