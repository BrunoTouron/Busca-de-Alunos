using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Busca_de_Alunos2.Models;

namespace Busca_de_Alunos2.Controllers
{
    public class PesquisaController : Controller
    {
        private BuscaAlunosContext db = new BuscaAlunosContext();

        // GET: Pesquisa
        public async Task<ActionResult> Index()
        {
            var pesquisas = db.Pesquisas.Include(p => p.Aluno);
            return View(await pesquisas.ToListAsync());
        }

        // GET: Pesquisa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pesquisa pesquisa = await db.Pesquisas.FindAsync(id);
            if (pesquisa == null)
            {
                return HttpNotFound();
            }
            return View(pesquisa);
        }

        // GET: Pesquisa/Create
        public ActionResult Create()
        {
            ViewBag.Aluno_Id = new SelectList(db.Alunos, "Id", "Ra");
            return View();
        }

        // POST: Pesquisa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Aluno_Id")] Pesquisa pesquisa)
        {
            if (ModelState.IsValid)
            {
                db.Pesquisas.Add(pesquisa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Aluno_Id = new SelectList(db.Alunos, "Id", "Ra", pesquisa.Aluno_Id);
            return View(pesquisa);
        }

        // GET: Pesquisa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pesquisa pesquisa = await db.Pesquisas.FindAsync(id);
            if (pesquisa == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aluno_Id = new SelectList(db.Alunos, "Id", "Ra", pesquisa.Aluno_Id);
            return View(pesquisa);
        }

        // POST: Pesquisa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Aluno_Id")] Pesquisa pesquisa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesquisa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Aluno_Id = new SelectList(db.Alunos, "Id", "Ra", pesquisa.Aluno_Id);
            return View(pesquisa);
        }

        // GET: Pesquisa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pesquisa pesquisa = await db.Pesquisas.FindAsync(id);
            if (pesquisa == null)
            {
                return HttpNotFound();
            }
            return View(pesquisa);
        }

        // POST: Pesquisa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pesquisa pesquisa = await db.Pesquisas.FindAsync(id);
            db.Pesquisas.Remove(pesquisa);
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
