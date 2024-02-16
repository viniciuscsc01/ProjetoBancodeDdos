using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancoDeDados.Models
{
    [Table("Passagens")]
    public class Passagens
    {
        [Column("PassagensId")]
        [Display(Name = "Código da passagem")]

        public int Id { get; set; }

        [Column("DescricaoId")]
        [Display(Name = "Descrição das passagens")]

        public string DescricaoId { get; set; } = string.Empty;
    }
}
