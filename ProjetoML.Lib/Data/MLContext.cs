using Microsoft.EntityFrameworkCore;
using ProjetoML.Lib.Models;

namespace ProjetoML.Lib.Data
{
    public class MLContext : DbContext
    {
        public MLContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //mapeando tabelas

            //Pedidos
            modelBuilder.Entity<Pedido>().ToTable("ML_Pedidos");
            modelBuilder.Entity<Pedido>().HasKey(key => key.Id);
            modelBuilder.Entity<Pedido>()
                                         .HasMany(pedido => pedido.ProdutosPedidos)
                                         .WithOne(produtosPedidos => produtosPedidos.Pedido)
                                         .HasForeignKey(x => x.IdPedido);

            //Produtos
            modelBuilder.Entity<Produto>().ToTable("ML_Produtos");
            modelBuilder.Entity<Produto>().HasKey(x => x.Id);
            modelBuilder.Entity<Produto>()
                                         .HasMany(x => x.ProdutosPedidos)
                                         .WithOne(x => x.Produto)
                                         .HasForeignKey(x => x.IdProduto);

            //ProdutosPedidos
            modelBuilder.Entity<ProdutoPedido>().ToTable("ML_ProdutosXPedidos");
            modelBuilder.Entity<ProdutoPedido>().HasKey(x => x.Id);
            modelBuilder.Entity<ProdutoPedido>()
                                                .HasOne(x => x.Pedido)
                                                .WithMany(x => x.ProdutosPedidos)
                                                .HasForeignKey(x => x.IdPedido);
            modelBuilder.Entity<ProdutoPedido>()
                                                .HasOne(x => x.Produto)
                                                .WithMany(x => x.ProdutosPedidos)
                                                .HasForeignKey(x => x.IdProduto);

            //Transportadoras
            modelBuilder.Entity<Transportadora>().ToTable("ML_Transportadoras");
            modelBuilder.Entity<Transportadora>().HasKey(x => x.Id);
            modelBuilder.Entity<Transportadora>()
                                                 .HasMany(x => x.Pedidos)
                                                 .WithOne(x => x.Transportadora)
                                                 .HasForeignKey(x => x.IdTransportadora);

            //Usuarios
            modelBuilder.Entity<Usuario>().ToTable("ML_Usuarios");
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);
            modelBuilder.Entity<Usuario>()
                                          .HasMany(x => x.Pedidos)
                                          .WithOne(x => x.Usuario)
                                          .HasForeignKey(x => x.IdUsuario);

            //Vendedores
            modelBuilder.Entity<Vendedor>().ToTable("ML_Vendedores");
            modelBuilder.Entity<Vendedor>().HasKey(x => x.Id);
            modelBuilder.Entity<Vendedor>()
                                           .HasMany(x => x.Produtos)
                                           .WithOne(x => x.Vendedor)
                                           .HasForeignKey(x => x.IdVendedor);
        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoPedido> ProdutosPedidos { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

    }
}