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
    public class TB_PRODUTOController : Controller
    {
        private VendaDBEntities db = new VendaDBEntities();

        // GET: TB_PRODUTO
        public ActionResult Index()
        {
            var tB_PRODUTO = db.TB_PRODUTO.Include(t => t.TB_FABRICANTE);
            return View(tB_PRODUTO.ToList());
        }

        // GET: TB_PRODUTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PRODUTO tB_PRODUTO = db.TB_PRODUTO.Find(id);
            if (tB_PRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_PRODUTO);
        }

        // GET: TB_PRODUTO/Create
        public ActionResult Create()
        {
            ViewBag.IdFabricante = new SelectList(db.TB_FABRICANTE, "Id", "Nome");
            return View();
        }

        // POST: TB_PRODUTO/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Preco,IdFabricante")] TB_PRODUTO tB_PRODUTO)
        {
            if (ModelState.IsValid)
            {
                db.TB_PRODUTO.Add(tB_PRODUTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFabricante = new SelectList(db.TB_FABRICANTE, "Id", "Nome", tB_PRODUTO.IdFabricante);
            return View(tB_PRODUTO);
        }

        // GET: TB_PRODUTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PRODUTO tB_PRODUTO = db.TB_PRODUTO.Find(id);
            if (tB_PRODUTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFabricante = new SelectList(db.TB_FABRICANTE, "Id", "Nome", tB_PRODUTO.IdFabricante);
            return View(tB_PRODUTO);
        }

        // POST: TB_PRODUTO/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Preco,IdFabricante")] TB_PRODUTO tB_PRODUTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PRODUTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFabricante = new SelectList(db.TB_FABRICANTE, "Id", "Nome", tB_PRODUTO.IdFabricante);
            return View(tB_PRODUTO);
        }

        // GET: TB_PRODUTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PRODUTO tB_PRODUTO = db.TB_PRODUTO.Find(id);
            if (tB_PRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_PRODUTO);
        }

        // POST: TB_PRODUTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_PRODUTO tB_PRODUTO = db.TB_PRODUTO.Find(id);
            db.TB_PRODUTO.Remove(tB_PRODUTO);
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
