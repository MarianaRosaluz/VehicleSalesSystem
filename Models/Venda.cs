using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleSalesSystem.Models
{
public class Venda
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataVenda { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalVenda { get; set; }

        // Relacionamento com Veiculo
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        // Relacionamento com Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relacionamento com Vendedor
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        // Relacionamento com Pagamento
        public Pagamento Pagamento { get; set; }
    }
}