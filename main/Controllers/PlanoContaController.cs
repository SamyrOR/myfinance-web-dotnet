using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using service.Interfaces;


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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}