using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Boleto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayorName { get; set; }

        [MaxLength(14)]
        public string? PayorCpfCnpj { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayeeName { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [MaxLength(50)]
        public string? Notes { get; set; }

        [Required]
        [ForeignKey("Banco")]
        public int BancoId { get; set; }
    }
}
