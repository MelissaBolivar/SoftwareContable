using Contable.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Contable.Infrastructure.Contexto
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        public DbSet<Anticipos> Anticipos => Set<Anticipos>();     
        public DbSet<Clientes> Clientes => Set<Clientes>();     
        public DbSet<Compras> Compras => Set<Compras>();     
        public DbSet<Costos> Costos => Set<Costos>();     
        public DbSet<Gastos> Gastos => Set<Gastos>();     
        public DbSet<Inventario> Inventario => Set<Inventario>();     
        public DbSet<Item> Item => Set<Item>();     
        public DbSet<Proveedores> Proveedores => Set<Proveedores>();     
        public DbSet<Rol> Rol => Set<Rol>();     
        public DbSet<Tesoreria> Tesoreria => Set<Tesoreria>();     
        public DbSet<TipodeDisponible> TipodeDisponible => Set<TipodeDisponible>();     
        public DbSet<TipoDeIdentificacion> TipoDeIdentificacion => Set<TipoDeIdentificacion>();     
        public DbSet<TipoDePago> TipoDePago => Set<TipoDePago>();     
        public DbSet<Usuario> Usuario => Set<Usuario>();     
        public DbSet<Ventas> Ventas => Set<Ventas>();     
        
        //poner las otras entidades y relaciones

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));

            #region Models

            // ============================
            // 🔹 Anticipos ↔ Rol (1:N)
            // ============================
            modelBuilder.Entity<Anticipos>()
                .HasOne(a => a.Rol)
                .WithMany(r => r.Anticipos)        // ICollection<Anticipos> en Rol
                .HasForeignKey(a => a.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // 🔹 Clientes ↔ Rol (1:N)
            // ============================
            modelBuilder.Entity<Clientes>()
                .HasOne(c => c.Rol)
                .WithMany(r => r.Clientes)         // ICollection<Clientes> en Rol
                .HasForeignKey(c => c.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // 🔹 Compras ↔ Proveedores (1:N)
            // ============================
            modelBuilder.Entity<Compras>()
                .HasOne(c => c.Proveedor)
                .WithMany(p => p.Compras)          // ICollection<Compras> en Proveedores
                .HasForeignKey(c => c.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Compras ↔ TipoDePago (1:N)
            modelBuilder.Entity<Compras>()
                .HasOne(c => c.TipoDePago)
                .WithMany(tp => tp.Compras)        // ICollection<Compras> en TipoDePago
                .HasForeignKey(c => c.IdTipoPago)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Compras ↔ Rol (1:N)
            modelBuilder.Entity<Compras>()
                .HasOne(c => c.Rol)
                .WithMany(r => r.Compras)          // ICollection<Compras> en Rol
                .HasForeignKey(c => c.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // 🔹 Costos ↔ Proveedores (1:N)
            // ============================
            modelBuilder.Entity<Costos>()
                .HasOne(co => co.Proveedor)
                .WithMany(p => p.Costos)           // ICollection<Costos> en Proveedores
                .HasForeignKey(co => co.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Costos ↔ TipoDePago (1:N)
            modelBuilder.Entity<Costos>()
                .HasOne(co => co.TipoDePago)
                .WithMany(tp => tp.Costos)         // ICollection<Costos> en TipoDePago
                .HasForeignKey(co => co.IdTipoPago)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Costos ↔ Rol (1:N)
            modelBuilder.Entity<Costos>()
                .HasOne(co => co.Rol)
                .WithMany(r => r.Costos)           // ICollection<Costos> en Rol
                .HasForeignKey(co => co.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // 🔹 Gastos ↔ Proveedores (1:N)
            // ============================
            modelBuilder.Entity<Gastos>()
                .HasOne(g => g.Proveedor)
                .WithMany(p => p.Gastos)           // ICollection<Gastos> en Proveedores
                .HasForeignKey(g => g.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Gastos ↔ TipoDePago (1:N)
            modelBuilder.Entity<Gastos>()
                .HasOne(g => g.TipoDePago)
                .WithMany(tp => tp.Gastos)         // ICollection<Gastos> en TipoDePago
                .HasForeignKey(g => g.IdTipoPago)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Gastos ↔ Rol (1:N)
            modelBuilder.Entity<Gastos>()
                .HasOne(g => g.Rol)
                .WithMany(r => r.Gastos)           // ICollection<Gastos> en Rol
                .HasForeignKey(g => g.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // Inventario - Item
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Item)
                .WithMany(it => it.Inventarios)
                .HasForeignKey(i => i.IdItem)
                .OnDelete(DeleteBehavior.Restrict);

            // Inventario - Rol
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Rol)
                .WithMany()
                .HasForeignKey(i => i.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // Tesoreria - TipoDisponible
            modelBuilder.Entity<Tesoreria>()
                .HasOne(t => t.TipoDisponible)
                .WithMany(td => td.Tesorerias)
                .HasForeignKey(t => t.IdTipoDisponible)
                .OnDelete(DeleteBehavior.Restrict);

            // Tesoreria - Rol
            modelBuilder.Entity<Tesoreria>()
                .HasOne(t => t.Rol)
                .WithMany()
                .HasForeignKey(t => t.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario - TipoIdentificacion
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.TipoIdentificacion)
                .WithMany(ti => ti.Usuarios)
                .HasForeignKey(u => u.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.Restrict);

            // Usuario - Rol
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.IdRol)
                .OnDelete(DeleteBehavior.Restrict);

            // Venta - Cliente
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Venta - TipoPago
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.TipoPago)
                .WithMany(tp => tp.Ventas)
                .HasForeignKey(v => v.IdTipoPago)
                .OnDelete(DeleteBehavior.Restrict);

            // Venta - Anticipo
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.Anticipo)
                .WithMany(a => a.Ventas)
                .HasForeignKey(v => v.IdAnticipo)
                .OnDelete(DeleteBehavior.Restrict);

            // Venta - Rol
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.Rol)
                .WithMany()
                .HasForeignKey(v => v.IdRol)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
