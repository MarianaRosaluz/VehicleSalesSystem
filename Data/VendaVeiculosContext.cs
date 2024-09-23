using Microsoft.EntityFrameworkCore;
using VehicleSalesSystem.Models;

namespace VehicleSalesSystem.Data
{
    public class VendaVeiculosContext : DbContext
    {
        public VendaVeiculosContext(DbContextOptions<VendaVeiculosContext> options)
            : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando relacionamento 1-para-1 entre Veiculo e Venda
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Venda)
                .WithOne(v => v.Veiculo)
                .HasForeignKey<Venda>(v => v.VeiculoId);

            // Configurando relacionamento 1-para-muitos entre Cliente e Venda
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Vendas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.ClienteId);

            // Configurando relacionamento 1-para-muitos entre Vendedor e Venda
            modelBuilder.Entity<Vendedor>()
                .HasMany(v => v.Vendas)
                .WithOne(v => v.Vendedor)
                .HasForeignKey(v => v.VendedorId);

            // Configurando relacionamento 1-para-1 entre Venda e Pagamento
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Pagamento)
                .WithOne(p => p.Venda)
                .HasForeignKey<Pagamento>(p => p.VendaId);
        }
    }
}
