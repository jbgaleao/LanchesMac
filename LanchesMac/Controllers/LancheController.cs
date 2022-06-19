using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository) => _lancheRepository = lancheRepository;

        public IActionResult List()
        {
            //var lanches = _lancheRepository.Lanches;

            //ViewData["titulo"] = "TODOS OS LANCHES";
            //ViewData["datahora"] = DateTime.Now;

            //TempData["nome"] = "JBGaleao";

            //ViewBag.texto = "Total de lanches listados: ";
            //ViewBag.total = lanches.Count();
            LancheListViewModel lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.Categoria = "Categoria Atual";

            return View(lanchesListViewModel);
        }
    }
}
