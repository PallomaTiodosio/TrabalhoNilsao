using Projeto.Models;

namespace Projeto.Repositorio.Contrato
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> ObterTodosUsuarios();

        void Cadastrar (Usuario usuario);

        void Atualizar (Usuario usuario);

        Usuario ObterUsuario(int Id);

        void Excluir(int Id);
    }
}
