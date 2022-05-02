using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFuncionarios.Models
{
    [Table("<funcionario>")]
    public class Funcionario
    {
        [Key]
        public int  Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Habilitacao { get; set; }
        public string Categoria { get; set; }
        public string Ligua { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }

    }
}
