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
    public class UltimasPesquisasController : Controller
    {
        private BuscaAlunosContext db = new BuscaAlunosContext();
        
        // GET: UltimasPesquisas
        public async Task<ActionResult> Index()
        {
            var pesquisas = db.Pesquisas.Include(p => p.Aluno).OrderByDescending(p => p.Id).Take(10);
            return View(await pesquisas.ToListAsync());
        }
    }
}