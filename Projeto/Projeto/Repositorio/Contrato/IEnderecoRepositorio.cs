using Projeto.Models;

namespace Projeto.Repositorio.Contrato
{
    public interface IEnderecoRepositorio
    {
        //CRUD
        void Cadastrar(Endereco endereco);
        void Atualizar (Endereco endereco);
        void Excluir(int Id);
        Endereco ObterEndereco(int  Id);
        IEnumerable<Endereco> ObterTodosEnderecos();
    }
}
