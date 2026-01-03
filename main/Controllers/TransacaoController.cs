using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet.Models;
using service.Interfaces;
using domain.Entities;


namespace myfinance_web_dotnet.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;
        private readonly IPlanoContaService _planoContaService;
        public TransacaoController(
            ILogger<TransacaoController> logger,
            ITransacaoService transacaoService,
            IPlanoContaService planoContaService
        )
        {
            _logger = logger;
            _transacaoService = transacaoService;
            _planoContaService = planoContaService;

        }
        public IActionResult Index()
        {
            var listaTransacao = _transacaoService.ListarRegistros();
            List<TransacaoModel> listaTransacaoModel = new List<TransacaoModel>();
            foreach (var item in listaTransacao)
            {
                var itemTransacao = new TransacaoModel()
                {
                    ID = item.ID,
                    Historico = item.Historico,
                    Data = item.Data,
                    Valor = item.Valor,
                    Tipo = item.PlanoConta.Tipo,
                    PlanoContaID = item.PlanoContaID,
                };
                listaTransacaoModel.Add(itemTransacao);
            }
            ViewBag.ListaTransacao = listaTransacaoModel;
            return View();
        }
        public IActionResult Cadastrar(int? ID)
        {
            var listaPlanoContas = new SelectList(_planoContaService.ListarRegistros(), "ID", "Descricao");

            var transacaoModel = new TransacaoModel(){
                Data = DateTime.Now,
                ListaPlanoContas = listaPlanoContas
            };
            if (ID != null)
            {
                var transacao = _transacaoService.RetornarRegistro((int)ID);
                transacaoModel.ID = transacao.ID;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.Data = transacao.Data;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.Tipo = transacao.PlanoConta.Tipo;
                transacaoModel.PlanoContaID = transacao.PlanoContaID;
            }

            return View(transacaoModel);
            
        }
        [HttpPost]
        public IActionResult Cadastrar(TransacaoModel model)
        {
            var transacao = new Transacao()
            {
                ID = model.ID,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaID = model.PlanoContaID,
            };
            _transacaoService.Cadastrar(transacao);
            return RedirectToAction("Index");
        }
        public IActionResult Excluir(int ID)
        {
            _transacaoService.Excluir(ID);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}