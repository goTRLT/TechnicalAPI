using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class BoletoDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "PayorName is required.")]
        [MaxLength(50)]
        public string PayorName { get; set; }

        [MaxLength(14)]
        public string? PayorCpfCnpj { get; set; }

        [Required(ErrorMessage = "PayeeName is required.")]
        [MaxLength(50)]
        public string PayeeName { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "DueDate is required.")]
        public DateTime DueDate { get; set; }

        [MaxLength(50)]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "BancoId is required.")]
        public int BancoId { get; set; }
    }
}
