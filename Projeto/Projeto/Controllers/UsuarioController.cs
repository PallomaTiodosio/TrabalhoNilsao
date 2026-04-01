using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Repositorio;
using Projeto.Repositorio.Contrato;

namespace Projeto.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View(_usuarioRepositorio.ObterTodosUsuarios());
        }

        [HttpGet]
        public IActionResult DetalhesUsuario(int Id)
        {
            return View(_usuarioRepositorio.ObterUsuario(Id));
        }

        [HttpPost]
        public IActionResult DetalhesUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Atualizar(usuario);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult AtualizarUsuario(int Id)
        {
            return View(_usuarioRepositorio.ObterUsuario(Id));
        }

        [HttpPost]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Atualizar(usuario);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Cadastrar(usuario);
            }
            return View();
        }

        public IActionResult ExcluirUsuario(int Id)
        {
            _usuarioRepositorio.Excluir(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
