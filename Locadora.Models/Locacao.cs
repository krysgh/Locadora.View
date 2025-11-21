using Locadora.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Locacao
    {
        public Guid LocacaoID { get; private set; }

        public int VeiculoID { get; private set; }

        public int ClienteID { get; private set; }

        public DateTime DataLocacao { get; private set; }

        public DateTime DataDevolucaoPrevista { get; private set; }

        public DateTime? DataDevolucaoReal {get;private set; }

        public decimal ValorDiaria { get; private set; }

        public decimal ValorTotal { get; private set; }

        public decimal Multa { get; private set; }

        public EStatusLocacao Status { get; private set; }

        public Locacao(int veiculoID, int clienteID, decimal valorDiaria, int diasParaRetornar)
        {
            this.VeiculoID = veiculoID;
            this.ClienteID = clienteID;
            this.DataLocacao = DateTime.UtcNow;
            this.ValorDiaria = valorDiaria;
            this.DataDevolucaoPrevista = DateTime.Now.AddDays(diasParaRetornar);
            this.Status = EStatusLocacao.Ativa;
        }

        public override string? ToString()
        {
            return  $"Cliente ID: {this.ClienteID}\n" +
                    $"Veículo ID: {this.VeiculoID}\n" +
                    $"Data de Locação: {this.DataLocacao}\n" +
                    $"Data de Devolução Prevista: {this.DataDevolucaoPrevista}\n" +
                    $"Data de Devolução Real: {this.DataDevolucaoReal}\n" +
                    $"Valor da Diária: {this.ValorDiaria:C}\n" +
                    $"Valor Total: {this.ValorTotal:C}\n" +
                    $"Multa: {this.Multa:C}\n" +
                    $"Status: {this.Status}\n";
        }
    }
}
