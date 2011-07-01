using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SammyTest.Models;

namespace SammyTest.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Index()
        {
            Session["Pessoas"] = Session["Pessoas"] ?? new List<Pessoa>();
            var pessoas = Session["Pessoas"] as List<Pessoa>;
            return Json(new
            {
                total = pessoas.Count,
                pessoas = pessoas.Select(pessoa => new
                {
                    pessoa.Nome,
                    pessoa.Sexo,
                    Nascimento = pessoa.Nascimento.ToShortDateString()
                })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Novo(Pessoa pessoa)
        {
            Session["Pessoas"] = Session["Pessoas"] ?? new List<Pessoa>();
            var pessoas = Session["Pessoas"] as List<Pessoa>;
            pessoa.Id = pessoas.Count + 1;
            pessoas.Add(pessoa);
        }
    }
}
