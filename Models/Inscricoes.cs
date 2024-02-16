using ProjetoBancodeDados.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancoDeDados.Models
{
    [Table("Inscricoes")]
    public class Inscricoes
    {
        [Column("InscricoesId")]
        [Display(Name = "Código da inscrição")]

        public int Id { get; set; }

        [ForeignKey("EventosId")]
        public int EventosId { get; set; }
        public Eventos? Eventos { get; set; }


        [ForeignKey("PagamentosId")]
        public int PagamentosId { get; set; }
        public Pagamentos? PagamentoId { get; set; }


        [ForeignKey("UsuariosId")]
        public int UsuariosId { get; set; }
        public Usuarios? Usuarios { get; set; }


        [ForeignKey("PassagensId")]
        public int PassagensId { get; set; }
        public Passagens? Passagens { get; set; }
    }
}