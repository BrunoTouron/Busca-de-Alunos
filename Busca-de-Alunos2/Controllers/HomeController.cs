using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Busca_de_Alunos2.Models;

namespace Busca_de_Alunos2.Controllers
{
    public class HomeController : Controller
    {
        private BuscaAlunosContext db = new BuscaAlunosContext();

        public ActionResult Index()
        {
            return View(db.Alunos.ToList());
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string sParam = form["txtPesq"];

            if (!string.IsNullOrWhiteSpace(sParam))
            {
                return View(db.Alunos.Where(x => x.Ra == sParam));
            }
            else
            {
                return View(db.Alunos.ToList());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}