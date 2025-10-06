using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class BoletoDto
    {
        [Key]
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
        public int BancoId { get; set; }
    }
}
