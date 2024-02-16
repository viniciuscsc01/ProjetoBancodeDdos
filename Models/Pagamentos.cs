using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancoDeDados.Models
{
    [Table("Pagamentos")]
    public class Pagamentos
    {
        [Column("PagamentosId")]
        [Display(Name = "Código do Pagamento")]

        public int Id { get; set; }

        [Column("ValorId")]
        [Display(Name = "Valor do pagamento")]

        public string ValorId { get; set; } = string.Empty;
    }
}