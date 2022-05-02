#nullable disable
using ControleFuncionarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFuncionarios.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly Contexto _contexto;

        public FuncionarioController(Contexto context)
        {
            _contexto = context;
        }


        //PESQUISA --------------------------------------------------------------
        public IActionResult Index() //Carrega na Tela
        {
            var lista = _contexto.Funcionarios.ToList();
            return View(lista);
        }
         
		//INCLUI --------------------------------------------------------------
		[HttpGet]
		public IActionResult Create() //Carrega na Tela
		{
			var usuario = new Funcionario();
			return View(usuario);
		}

		[HttpPost]
		public IActionResult Create(Funcionario pFuncionario) //Manda para o banco
		{
			if (ModelState.IsValid)
			{ //se os dados foram preenchidos corretamente na tela
				_contexto.Funcionarios.Add(pFuncionario);
				_contexto.SaveChanges();

				return RedirectToAction("Index");
			}
			else
			{
				return View(pFuncionario);
			}
		}

		//EDITA --------------------------------------------------------------
		[HttpGet]
		public IActionResult Edit(int id) //Carrega na tela
		{
			var lFuncionario = _contexto.Funcionarios.Find(id);

			if (lFuncionario != null)
			{				
                return View(lFuncionario);
            }
			else
			{
                return NotFound();
            }
		}

        //[HttpPost]
        public IActionResult Edit(Funcionario pFuncionario) //Manda para o banco
        { 
            if (ModelState.IsValid)
            {
                _contexto.Funcionarios.Update(pFuncionario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(pFuncionario);
            }
        }

        ////EXCLUI --------------------------------------------------------------
        [HttpGet]
        public IActionResult Delete(int id) //Carrega na tela
        {
            var lFuncionario = _contexto.Funcionarios.Find(id);
            return View(lFuncionario);
        }

        [HttpPost]
        public IActionResult Delete(Funcionario pFuncionario) //Manda para o banco
        {
            var lFuncionario = _contexto.Funcionarios.Find(pFuncionario.Codigo);

            if (lFuncionario != null)
            {
                _contexto.Funcionarios.Remove(lFuncionario);
                _contexto.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(lFuncionario);
            }
        }

        ////DETALHES --------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id) //Carrega na tela
        {
            var lFuncionario = _contexto.Funcionarios.Find(id);
            return View(lFuncionario);

        }
    }
}
