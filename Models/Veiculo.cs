using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleSalesSystem.Models
{
 public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }

        public int Ano { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Required]
        public string Status { get; set; } // Disponível, Vendido
        // Relacionamento com Venda
        public Venda Venda { get; set; }
    }
}