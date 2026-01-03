using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using service.Interfaces;
using domain.Entities;


namespace myfinance_web_dotnet.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;
        public PlanoContaController(
            ILogger<PlanoContaController> logger,
            IPlanoContaService planoContaService
        )
        {
            _logger = logger;
            _planoContaService = planoContaService;

        }
        public IActionResult Index()
        {
            var listaPlanoContas = _planoContaService.ListarRegistros();
            List<PlanoContaModel> listaPlanoContaModel = new List<PlanoContaModel>();
            foreach (var item in listaPlanoContas)
            {
                var itemPlanoConta = new PlanoContaModel()
                {
                    ID = item.ID,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };
                listaPlanoContaModel.Add(itemPlanoConta);
            }
            ViewBag.ListaPlanoConta = listaPlanoContaModel;
            return View();
        }
        public IActionResult Cadastrar(int? ID)
        {
            if (ID != null)
            {
                var planoConta = _planoContaService.RetornarRegistro((int)ID);
                var planoContaModel = new PlanoContaModel()
                {
                    ID = planoConta.ID,
                    Descricao = planoConta.Descricao,
                    Tipo = planoConta.Tipo
                };
                return View(planoContaModel);   
            }
            return View();
            
        }
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(PlanoContaModel model)
        {
            var planoConta = new PlanoConta()
            {
                ID = model.ID,
                Descricao = model.Descricao,
                Tipo = model.Tipo,
            };
            _planoContaService.Cadastrar(planoConta);
            return RedirectToAction("Index");
        }
        public IActionResult Excluir(int ID)
        {
            _planoContaService.Excluir(ID);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}