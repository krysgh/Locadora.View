namespace Locadora.View.Menus
{
    public class GerenciarCategoriasVeiculos
    {

        public void Run()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("-----| GERENCIAR CATEGORIAS E VEÍCULOS |----");
                Console.WriteLine("1. Cadastrar Categoria");
                Console.WriteLine("2. Listar Categorias com Veículos");
                Console.WriteLine("3. Cadastrar Veículo");
                Console.WriteLine("4. Consultar Veículos por Categoria");
                Console.WriteLine("5. Atualizar Status do Veículo");
                Console.WriteLine("6. Voltar ao Menu Principal\n");
                Console.Write("Digite a opção desejada: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
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