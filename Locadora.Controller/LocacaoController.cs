using Locadora.Controller.Interfaces;
using Locadora.Models;
using Locadora.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;

namespace Locadora.Controller
{
    public class LocacaoController : ILocacaoController
    {

        public ClienteController clienteController = new();

        public VeiculoController veiculoController = new();

        public FuncionarioController funcionarioController = new();

        //ARRUMAR A ENTRADA DE VEÍCULOS DUPLICADOS
        public void AdicionarLocacao(Locacao locacao)
        { 
            
            using (SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(Locacao.INSERTLOCACAO, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@idCliente", locacao.ClienteID);
                            command.Parameters.AddWithValue("@idVeiculo", locacao.VeiculoID);
                            command.Parameters.AddWithValue("@DataLocacao", locacao.DataLocacao);
                            command.Parameters.AddWithValue("@DataDevolucaoPrevista", locacao.DataDevolucaoPrevista);
                            command.Parameters.AddWithValue("@DataDevolucaoReal", (object?)locacao.DataDevolucaoReal ?? DBNull.Value);
                            command.Parameters.AddWithValue("@ValorDiaria", locacao.ValorDiaria);
                            command.Parameters.AddWithValue("@ValorTotal", locacao.ValorTotal);
                            command.Parameters.AddWithValue("@Multa", locacao.Multa);
                            command.Parameters.AddWithValue("@Status", locacao.Status.ToString());

                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao alocar veículo: " + ex.Message);
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao alocar veículo: " + e.Message);
                    }
                }
            }


        }

        public Locacao BuscarLocacaoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(Locacao.SELECTLOCACAOPORID, connection))
                    {

                        command.Parameters.AddWithValue("@idLocacao", id);
                        Locacao locacao = null;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Funcionario> funcionarios = [];
                            while (reader.Read())
                            {
                                if (locacao == null)
                                {
                                    locacao = new Locacao((int)reader["LocacaoID"],
                                                              (int)reader["ClienteID"],
                                                              (int)reader["VeiculoID"],
                                                              Convert.ToDateTime(reader["DataLocacao"]),
                                                              reader["DataDevolucaoReal"] != (object)DBNull.Value ?
                                                              Convert.ToDateTime(reader["DataDevolucaoReal"]) : null,
                                                              Convert.ToDateTime(reader["DataDevolucaoPrevista"]),
                                                              Convert.ToDecimal(reader["ValorDiaria"]),
                                                              Convert.ToDecimal(reader["ValorTotal"]),
                                                              Convert.ToDecimal(reader["Multa"]),
                                                              (EStatusLocacao)Enum.Parse(typeof(EStatusLocacao), reader["Status"].ToString())
                                                             );

                                    if (locacao == null)
                                        return null;

                                    Cliente cliente = clienteController.BuscarClientePorID(locacao.ClienteID);
                                    locacao.SetClienteNome(cliente.Nome);
                                    locacao.SetClienteEmail(cliente.Email);

                                    Veiculo veiculo = veiculoController.BuscarVeiculoPorID(locacao.VeiculoID);
                                    locacao.SetVeiculoModelo(veiculo.Modelo);
                                    locacao.SetVeiculoPlaca(veiculo.Placa);

                                }
                                if (reader["CPF"] != DBNull.Value)
                                {
                                    funcionarios.Add(funcionarioController.BuscarFuncionarioPorCPF(reader["CPF"].ToString()));
                                }

                                locacao.SetFuncionarios(funcionarios);
                            }
                            return locacao;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao buscar locação: " + ex.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro inesperado ao buscar locação: " + e.Message);
                }
            }
        }

        public List<Funcionario> ListarFuncionariosDeUmaLocacao(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(Locacao.SELECTFUNCIONARIOSDEUMALOCACAO, connection))
                    {

                        command.Parameters.AddWithValue("@idLocacao", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Funcionario> funcionarios = [];
                            while (reader.Read())
                            {
                                var funcionario = new Funcionario(reader["Nome"].ToString(),
                                                                  reader["CPF"].ToString(),
                                                                  reader["Email"].ToString(),
                                                                  reader["Salario"] != (object)DBNull.Value ?
                                                                  (Decimal)reader["Salario"] : null
                                                                 );
                                funcionarios.Add(funcionario);
                            }
                            return funcionarios;

                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar funcionários da locação: " + ex.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro inesperado ao listar funcionários da locação: " + e.Message);
                }
            }
        }

        public void AssociarFuncionario(int idFuncionario, int idLocacao)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {

                    try
                    {
                        using (SqlCommand command = new SqlCommand(Locacao.INSERTLOCACAOFUNCIONARIO, connection,transaction))
                        {
                            command.Parameters.AddWithValue("@idLocacao", idLocacao);
                            command.Parameters.AddWithValue("@idFuncionario", idFuncionario);
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao associar funcionário à locação: " + ex.Message);
                    }
                    catch (Exception e)
                    {   transaction.Rollback();
                        throw new Exception("Erro inesperado ao associar funcionário à locação: " + e.Message);
                    }
                }

            }
        }

        //CONFERIR AMANHÃ
        public void FinalizarLocacao(int idLocacao)
        {
            var locacaoEncontrada = BuscarLocacaoPorId(idLocacao) ?? throw new Exception("Locação não encontrada.");

            if(locacaoEncontrada.Status.ToString() != "Ativa")
                throw new Exception("Locação já está finalizada.");

            using (SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString()))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(Locacao.UPDATELOCACAOPORID, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@idLocacao", idLocacao);
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao finalizar locação: " + ex.Message);
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao finalizar locação: " + e.Message);
                    }
                }
            }
        }

        public List<Locacao> ListarLocacaoPorCliente(int id)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> ListarLocacaoPorFuncionario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> ListarLocacoesAivas()
        {
            throw new NotImplementedException();
        }

        public List<Locacao> ListarTodasLocacoes()
        {
            throw new NotImplementedException();
        }
    }
}
