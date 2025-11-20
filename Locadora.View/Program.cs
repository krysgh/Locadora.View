using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

#region ClienteDocumentoObjetos
//Primeiro teste inserindo cliente e documento e printando
Cliente cliente = new Cliente("Justin Bieber", "jbieber123@email.com","16990897832");
Documento documento = new Documento ("RG","123456789", new DateTime(2020,11,20), new DateTime(2030,11,20));

//Console.WriteLine(cliente);
//Console.WriteLine(documento);
//
#endregion




var clienteController = new ClienteController();
DocumentoController documentoController = new DocumentoController();
/*

*/
/*
try
{
    clienteController.AdicionarCliente(cliente, documento);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}





clienteController.AtualizarTelefoneCliente("16998674563", "jsilva123@email.com");

Console.WriteLine(clienteController.BuscarClientePorEmail("jsilva123@email.com"));

try
{
    clienteController.DeletarCliente("jbieber123@email.com");
}
catch (Exception e)
{
    Console.WriteLine(e);
}

*/

var documentoNovo = new Documento("CPF", "7343824173438", new DateTime(2020,11,20), new DateTime(2020, 11, 30));

try
{
    clienteController.AtualizarDocumentoCliente(documentoNovo, "jbieber123@email.com");
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    var TodosClientes = clienteController.ListarTodosClientes();

    Console.WriteLine("---------------------| LISTA DE CLIENTES |-----------------------");
    foreach (Cliente c in TodosClientes)
    {
        Console.WriteLine(c);
        Console.WriteLine("-----------------------------------------------------------------");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
