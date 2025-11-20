using System.Data;

namespace Locadora.Models
{
    public class Cliente
    {
        public readonly static string INSERTCLIENTE = "INSERT INTO tblClientes VALUES (@Nome,@Email,@Telefone); " +
                                                       "SELECT SCOPE_IDENTITY();";

        public readonly static string SELECTTODOSCLIENTES = "SELECT * FROM tblClientes;";

        public readonly static string UPDATETELEFONECLIENTE = "UPDATE tblClientes SET Telefone = @Telefone WHERE ClienteID = @idCliente;";

        public readonly static string SELECTCLIENTEPOREMAIL = "SELECT * FROM tblClientes WHERE Email = @Email;";

        public readonly static string DELETECLIENTE = "DELETE FROM tblClientes WHERE ClienteID = @idCliente;";
        public int ClienteID { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string? Telefone { get; private set; } = String.Empty;

        public Cliente(string nome, string email)
        {
            this.Nome = nome;
            this.Email = email;
        }

        public Cliente(string nome, string email, string? telefone) : this(nome, email)
        {
            this.Telefone = telefone;
        }

        public void SetClienteID(int id)
        {
            this.ClienteID = id;
        }

        public void SetTelefone(string telefone)
        {
            this.Telefone = telefone;
        }

        public override string ToString()
        {
            return $"Nome: {this.Nome}\n" +
                $"Email: {this.Email}\n" +
                $"Telefone: {this.Telefone}";
        }

    }
}
