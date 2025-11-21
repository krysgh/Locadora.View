using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Controller.Interfaces
{
    public interface IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo);

        public Veiculo BuscarVeiculoPorPlaca(string placa);

        public List<Veiculo> ListarTodosVeiculos();

        public void AtualizarVeiculo(string statusVeiculo,string placa);

        public void DeletarVeiculo(string placa);
    }
}
