using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleSalesSystem.Models
{
 public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        [Required]
        public string FormaPagamento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        public DateTime DataPagamento { get; set; }
    }
}