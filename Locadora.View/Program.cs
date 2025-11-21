using Locadora.Controller;
using Locadora.Models;
using Locadora.Models.Enums;
using Microsoft.Data.SqlClient;
using Utils.Databases;

#region ClienteDocumentoObjetos
//Primeiro teste inserindo cliente e documento e printando
Cliente cliente = new Cliente("Justin Bieber", "jbieber123@email.com", "16990897832");
Documento documento = new Documento("RG", "123456789", new DateTime(2020, 11, 20), new DateTime(2030, 11, 20));

//Console.WriteLine(cliente);
//Console.WriteLine(documento);
//
#endregion




var clienteController = new ClienteController();
DocumentoController documentoController = new DocumentoController();
CategoriaController categoriaController = new CategoriaController();

var veiculoController = new VeiculoController();

var categoria = new Categoria("NovaCategoria", "Essa é uma nova categoria", Convert.ToDecimal(130));

/*
try
{
    var TodasCategorias = categoriaController.ListarTodasCategorias();
    Console.WriteLine("--------------------| LISTA DE CATEGORIAS |----------------------");
    foreach (Categoria c in TodasCategorias)
    {
        Console.WriteLine(c);
        Console.WriteLine("-----------------------------------------------------------------");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

var veiculo = new Veiculo(1, "XYZ-9876", "Chevrolet", "S10", 2025, EStatusVeiculo.Disponivel.ToString());




try
{

    Console.WriteLine("--------------------| LISTA DE VEICULOS |----------------------");
    foreach (Veiculo v in veiculoController.ListarTodosVeiculos())
    {
        Console.WriteLine(v);
        Console.WriteLine("-----------------------------------------------------------------");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

var categoriaNova = new Categoria("Loucos", Convert.ToDecimal(300));
try
{
    categoriaController.AtualizarCategoriaPorID(1004, categoriaNova);
}
catch (Exception e)
{
    Console.WriteLine("Erro: " + e.Message);
}

try
{
    var TodasCategorias = categoriaController.ListarTodasCategorias();
    Console.WriteLine("--------------------| LISTA DE CATEGORIAS |----------------------");
    foreach (Categoria c in TodasCategorias)
    {
        Console.WriteLine(c);
        Console.WriteLine("-----------------------------------------------------------------");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try {
    Console.WriteLine(veiculoController.BuscarVeiculoPorPlaca("XYZ-9876"));
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
*/
try
{
    veiculoController.AtualizarVeiculo(EStatusVeiculo.Alugado.ToString(), "MNO7890");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
try
{

    Console.WriteLine("--------------------| LISTA DE VEICULOS |----------------------");
    foreach (Veiculo v in veiculoController.ListarTodosVeiculos())
    {
        Console.WriteLine(v);
        Console.WriteLine("-----------------------------------------------------------------");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
