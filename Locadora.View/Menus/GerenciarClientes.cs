using Locadora.Controller;
using Locadora.Models;

namespace Locadora.View.Menus
{
    public class GerenciarClientes
    {
        private ClienteController clienteController = new ClienteController();

        public void Run()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("---| GERENCIAR CLIENTES |----");
                Console.WriteLine("1. Cadastrar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Buscar Cliente Por Email");
                Console.WriteLine("4. Atualizar Cliente");
                Console.WriteLine("5. Deletar Cliente");
                Console.WriteLine("6. Voltar ao Menu Principal\n");
                Console.Write("Digite a opção desejada: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            
                           // clienteController.AdicionarCliente(new Cliente("Nome","CPF","Email"),new Documento("CPF","123456789",Convert.ToDateTime(11/12/2020),Convert.ToDateTime(11/12/2030)));
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Digite uma opção válida (1 a 6).\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Digite um número inteiro entre 1 e 6!\n");
                }

            } while (opcao != 6);
        }
    }
}