using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Boleto
    {
        public int Id { get; set; }
        public string PayorName { get; set; }
        public int? PayorCPF_CNPJ { get; set; }
        public string PayeeName { get; set; }
        public int Amount { get; set; }
        public DateOnly DueDate { get; set; }
        public string? Notes { get; set; }
        public Banco BancoId { get; set; }
    }
}
