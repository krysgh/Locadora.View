using Locadora.Models;

namespace Locadora.Controller.Interfaces
{
    public interface ILocacaoController
    {
        public void AdicionarLocacao(Locacao locacao);

        public void AssociarFuncionario(int idFuncionario,int idLocacao);

        public List<Locacao> ListarLocacoesAivas();

        public void FinalizarLocacao(int idLocacao);

        public List<Locacao> ListarLocacaoPorCliente(int id);

        public List<Locacao> ListarLocacaoPorFuncionario(int id);

        public List<Funcionario> ListarFuncionariosDeUmaLocacao(int id);

        public List<Locacao> ListarTodasLocacoes();

    }
}
