using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class BancoDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public decimal InterestPercent { get; set; }
    }
}
