using Contable.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Contable.Infrastructure.Context
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

        public DbSet<Anticipo> Anticipo => Set<Anticipo>();
        public DbSet<Caja> Caja => Set<Caja>();
        public DbSet<Factura> Factura => Set<Factura>();
        public DbSet<Inventario> Inventario => Set<Inventario>();
        public DbSet<Producto> Producto => Set<Producto>();
        public DbSet<Rol> Rol => Set<Rol>();
        public DbSet<Servicio> Servicio => Set<Servicio>();
        public DbSet<Tercero> Tercero => Set<Tercero>();
        public DbSet<TipoDoc> TipoDoc => Set<TipoDoc>();
        public DbSet<TipoFactura> TipoFactura => Set<TipoFactura>();
        public DbSet<TipoPago> TipoPago => Set<TipoPago>();
        public DbSet<TipoTercero> TipoTercero => Set<TipoTercero>();
        public DbSet<Usuario> Usuario => Set<Usuario>();

        // Nuevos DbSet para detalles
        public DbSet<DetalleProducto> DetalleProducto => Set<DetalleProducto>();
        public DbSet<DetalleServicio> DetalleServicio => Set<DetalleServicio>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));

            #region Models

            modelBuilder.Entity<Factura>()
                .HasOne(c => c.Tercero)
                .WithMany(p => p.Facturas)
                .HasForeignKey(c => c.TerceroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Factura>()
                .HasOne(c => c.TipoDePago)
                .WithMany(tp => tp.Facturas)
                .HasForeignKey(c => c.TipoPagoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Factura>()
                .HasOne(c => c.TipoFactura)
                .WithMany(tp => tp.Facturas)
                .HasForeignKey(c => c.TipoFacturaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Factura>()
                .HasOne(v => v.Anticipo)
                .WithMany(a => a.Facturas)
                .HasForeignKey(v => v.AnticipoId)
                .OnDelete(DeleteBehavior.Restrict);            

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.TipoDoc)
                .WithMany(ti => ti.Usuarios)
                .HasForeignKey(u => u.TipoDocId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(ti => ti.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tercero>()
                .HasOne(u => u.TipoDoc)
                .WithMany(ti => ti.Terceros)
                .HasForeignKey(u => u.TipoDocId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tercero>()
                .HasOne(u => u.TipoTercero)
                .WithMany(ti => ti.Terceros)
                .HasForeignKey(u => u.TipoTerceroId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones para DetalleProducto
            modelBuilder.Entity<DetalleProducto>()
                .HasOne(dp => dp.Factura)
                .WithMany(f => f.Productos)
                .HasForeignKey(dp => dp.FacturaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleProducto>()
                .HasOne(dp => dp.Producto)
                .WithMany() // ✅ sin navegación inversa en Producto.cs
                .HasForeignKey(dp => dp.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones para DetalleServicio
            modelBuilder.Entity<DetalleServicio>()
                .HasOne(ds => ds.Factura)
                .WithMany(f => f.Servicios)
                .HasForeignKey(ds => ds.FacturaId)
                .OnDelete(DeleteBehavior.Cascade);

            //  Aquí defines la precisión del decimal
                modelBuilder.Entity<DetalleProducto>()
                .Property(dp => dp.PrecioUnitario)
                 .HasPrecision(18, 2);

            modelBuilder.Entity<Caja>()
                .Property(dp => dp.Saldo)
                 .HasPrecision(18, 2);


            modelBuilder.Entity<DetalleServicio>()
                .HasOne(ds => ds.Servicio)
                .WithMany() // ✅ sin navegación inversa en Servicio.cs
                .HasForeignKey(ds => ds.ServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleServicio>()
               .Property(dp => dp.PrecioUnitario)
                .HasPrecision(18, 2);
            #endregion

            // Semilla de datos
            modelBuilder.Entity<Rol>().HasData(
                new Rol { RolId = 1, NombreRol = "Administrador", DescripcionRol = "Administrador", FechaRegistro = DateTime.UtcNow },
                new Rol { RolId = 2, NombreRol = "Contable", DescripcionRol = "Contable", FechaRegistro = DateTime.UtcNow }
            );

            modelBuilder.Entity<TipoDoc>().HasData(
                new TipoDoc { TipoDocId = 1, Nombre = "Cédula de ciudadanía", FechaRegistro = DateTime.UtcNow },
                new TipoDoc { TipoDocId = 2, Nombre = "NIT", FechaRegistro = DateTime.UtcNow },
                new TipoDoc { TipoDocId = 3, Nombre = "Cédula de extranjería", FechaRegistro = DateTime.UtcNow },
                new TipoDoc { TipoDocId = 4, Nombre = "Pasaporte", FechaRegistro = DateTime.UtcNow }
            );

            modelBuilder.Entity<TipoTercero>().HasData(
                new TipoTercero { TipoTerceroId = 1, Nombre = "Proveedor", FechaRegistro = DateTime.UtcNow },
                new TipoTercero { TipoTerceroId = 2, Nombre = "Cliente", FechaRegistro = DateTime.UtcNow },
                new TipoTercero { TipoTerceroId = 3, Nombre = "Colaborador", FechaRegistro = DateTime.UtcNow }
            );

            modelBuilder.Entity<TipoFactura>().HasData(
                new TipoFactura { TipoFacturaId = 1, Nombre = "Compra", FechaRegistro = DateTime.UtcNow },
                new TipoFactura { TipoFacturaId = 2, Nombre = "Venta", FechaRegistro = DateTime.UtcNow },
                new TipoFactura { TipoFacturaId = 3, Nombre = "Comprobante de caja", FechaRegistro = DateTime.UtcNow }
            );

            modelBuilder.Entity<TipoPago>().HasData(
                new TipoPago { TipoPagoId = 1, Nombre = "Crédito", FechaRegistro = DateTime.UtcNow },
                new TipoPago { TipoPagoId = 2, Nombre = "Contado", FechaRegistro = DateTime.UtcNow }
            );

            modelBuilder.Entity<Anticipo>().HasData(
                new Anticipo { AnticipoId = 1, PorcentajeAnticipo = 0, FechaRegistro = DateTime.UtcNow },
                new Anticipo { AnticipoId = 2, PorcentajeAnticipo = 10, FechaRegistro = DateTime.UtcNow },
                new Anticipo { AnticipoId = 3, PorcentajeAnticipo = 30, FechaRegistro = DateTime.UtcNow }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}