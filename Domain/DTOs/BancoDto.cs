using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
    {
    public class BancoDto
        {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        public int Code { get; set; }

        [Required(ErrorMessage = "InterestPercent is required.")]
        public decimal InterestPercent { get; set; }
        }
    }
