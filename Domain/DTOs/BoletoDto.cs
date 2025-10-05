using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? PayorCPF_CNPJ { get; set; }

        [Required]
        [MaxLength(50)]
        public string PayeeName { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateOnly DueDate { get; set; }

        [MaxLength(50)]
        public string? Notes { get; set; }

        [Required]
        public int BancoId { get; set; }
    }
}
