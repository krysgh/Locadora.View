using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

#region ClienteDocumentoObjetos
//Primeiro teste inserindo cliente e documento e printando
Cliente cliente = new Cliente("Justin Bieber", "jbieber123@email.com","16990897832");
Documento documento = new Documento (1,"RG","123456789", new DateTime(2020,11,20), new DateTime(2030,11,20));

//Console.WriteLine(cliente);
//Console.WriteLine(documento);
//
#endregion


var clienteController = new ClienteController();
/*
clienteController.AdicionarCliente(cliente);

try
{
    var TodosClientes = clienteController.ListarTodosClientes();

    foreach (Cliente c in TodosClientes)
    {
        Console.WriteLine(c);
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

*/
//clienteController.AtualizarTelefoneCliente("16998674563", "jsilva123@email.com");

//Console.WriteLine(clienteController.BuscarClientePorEmail("jsilva123@email.com"));


clienteController.DeletarCliente("jbieber123@email.com");