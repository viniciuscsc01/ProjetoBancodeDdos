using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancoDeDados.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Column("UsuarioId")]
        [Display(Name = "Código do Usuário")]

        public int Id { get; set; }

        [Column("NomeId")]
        [Display(Name = "Nome do Usuário")]

        public string NomeId { get; set; } = string.Empty;

        [Column("EmailId")]
        [Display(Name = "Email do Usuário")]

        public string EmailId { get; set; } = string.Empty;

        [Column("SenhaId")]
        [Display(Name = "Senha do Usuário")]

        public string SenhaId { get; set; } = string.Empty;
    }
}