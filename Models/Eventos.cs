using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoBancodeDados.Models
{
    [Table("Eventos")]
    public class Eventos
    {
        [Column("EventosId")]
        [Display(Name ="Id do Evento")] 

        public int Id { get; set; }

        [Column("NomeId")]
        [Display(Name = "Nome do Evento")]

        public string Nome { get; set; } = string.Empty;

        [Column("DataCriacaoId")]
        [Display(Name = "Data de Criação")]

        public string DataCriacao { get; set; } = String.Empty;

        [Column("DataAtualizacaoId")]
        [Display(Name = "Data de Atualização")]

        public string DataAtualizacao { get;set; } = String.Empty;

        [Column("DescricaoId")]
        [Display(Name = "Descrição do Evento")]

        public string Criacao { get; set; } = String.Empty;




    }
}
