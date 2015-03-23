using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busca_de_Alunos2.Models;

namespace Busca_de_Alunos2.Controllers
{
    public class MapaController : Controller
    {
        private BuscaAlunosContext db = new BuscaAlunosContext();

        public ActionResult Index(int? id)
        {

            if (id == null)
            {
                return View();
            }

            Aluno aluno = db.Alunos.Find(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            Pesquisa pesquisa = new Pesquisa();
            pesquisa.Aluno = aluno;
            db.Pesquisas.Add(pesquisa);
            db.SaveChanges();
            
            return View(db.Alunos.Find(id));
           
        }
    }
}