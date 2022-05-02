#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleFuncionarios.Models;

namespace ControleFuncionarios.Controllers
{
    public class HorarioTrabalhoesController : Controller
    {
        private readonly Contexto _context;

        public HorarioTrabalhoesController(Contexto context)
        {
            _context = context;
        }

        //PESQUISA --------------------------------------------------------------
        public IActionResult Index() //Carrega na Tela
        {
            CarregarFuncionarios(); 

            var lista = _context.HorarioTrabalhos.ToList();
            return View(lista);
        }

        //INCLUI --------------------------------------------------------------
        [HttpGet]
        public IActionResult Create() //Carrega na Tela
        {
            //Coisas a carregar quando o evento Incluir for disparado
            CarregarFuncionarios();
            CarregarDiasDaSemana();

            var local = new HorarioTrabalho();
            return View(local);
        }

        [HttpPost]
        public IActionResult Create(HorarioTrabalho pLocal) //Manda para o banco
        {
            if (ModelState.IsValid)
            { //se os dados foram preenchidos corretamente na tela
                _context.HorarioTrabalhos.Add(pLocal);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(pLocal);
            }
        }

        //EDITA --------------------------------------------------------------
        [HttpGet]
        public IActionResult Edit(int id) //Carrega na tela
        {
            //Carregar funções
            CarregarNomeFuncionario(id);
            CarregarDiasDaSemana();

            //Continuação
            var lLocal = _context.HorarioTrabalhos.Find(id);

            if (lLocal != null)
            {
                return View(lLocal);
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPost]
        public IActionResult Edit(HorarioTrabalho pLocal) //Manda para o banco
        {
            if (ModelState.IsValid)
            {
                _context.HorarioTrabalhos.Update(pLocal);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(pLocal);
            }
        }

        ////EXCLUI --------------------------------------------------------------
        [HttpGet]
        public IActionResult Delete(int id) //Carrega na tela
        {
            //Carregar funções
            CarregarNomeFuncionario(id);


            //Continuar
            var lLocal = _context.HorarioTrabalhos.Find(id);
            return View(lLocal);
        }

        [HttpPost]
        public IActionResult Delete(Funcionario pLocal) //Manda para o banco
        {
            var lLocal = _context.HorarioTrabalhos.Find(pLocal.Codigo);

            if (lLocal != null)
            {
                _context.HorarioTrabalhos.Remove(lLocal);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(lLocal);
            }
        }

        ////DETALHES --------------------------------------------------------------
        [HttpGet]
        public IActionResult Details(int id) //Carrega na tela
        {
            //Carregar
            CarregarNomeFuncionario(id);

            //Continuar
            var Llocal = _context.HorarioTrabalhos.Find(id);
            return View(Llocal);

        }


        //CRIANDO VIEW-BAGS DE APOIO
        public void CarregarFuncionarios()
        {
            var lista = _context.Funcionarios.ToList();

            List<SelectListItem> lLista = new List<SelectListItem>();
            SelectListItem lItem;
            foreach (var item in lista)
            {
                lItem = new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Nome };

                lLista.Add(lItem);
            }



            ViewBag.Funcionarios = lLista;
        }

        public void CarregarDiasDaSemana()
        {
            List<SelectListItem> lLista = new List<SelectListItem>()
            {
                new SelectListItem() { Value ="1", Text="Domingo"},
                new SelectListItem() { Value ="2", Text="Segunda"},
                new SelectListItem() { Value ="3", Text="Terça"},
                new SelectListItem() { Value ="4", Text="Quarta"},
                new SelectListItem() { Value ="5", Text="Quinta"},
                new SelectListItem() { Value ="6", Text="Sexta"},
                new SelectListItem() { Value ="7", Text="Sábado"}
            };

            ViewBag.DiasDaSemana = lLista;
        }

        public void CarregarNomeFuncionario(int id)
        {
            var lFuncionario = _context.Funcionarios.Find(id);

            ViewBag.NomeFuncionario = lFuncionario.Nome;
        }

    }
}