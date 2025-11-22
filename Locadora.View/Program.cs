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

FuncionarioController funcionarioController = new FuncionarioController();

Funcionario funcionario = new("Wayne","12312312312","wjunior123@email.com");

LocacaoController locacaoController = new LocacaoController();

Locacao locacao = new(1, 1, 300m, 12);
/*
try
{
    locacaoController.AdicionarLocacao(locacao);
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}


try
{
    Console.WriteLine(locacaoController.BuscarLocacaoPorId(1));
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

try
{
    var funcaionarios = locacaoController.ListarFuncionariosDeUmaLocacao(1002);

    foreach(var funcaionario in funcaionarios)
    {
        Console.WriteLine(funcaionario);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
*/
try
{
    locacaoController.FinalizarLocacao(1002);

    Console.WriteLine(locacaoController.BuscarLocacaoPorId(1002));
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
