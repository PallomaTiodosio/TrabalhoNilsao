using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Repositorio.Contrato;

namespace Projeto.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepositorio _enderecoRepositorio;
        public EnderecoController(IEnderecoRepositorio enderecoRepositorio) 
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        public IActionResult Index()
        {
            return View(_enderecoRepositorio.ObterTodosEnderecos());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepositorio.Cadastrar(endereco);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
