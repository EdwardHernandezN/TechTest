using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TechTest.Commons.Utils;

#nullable disable

namespace TechTest.Models
{
    public partial class TechTestOrdersContext : DbContext
    {
        public TechTestOrdersContext()
        {
        }

        public TechTestOrdersContext(DbContextOptions<TechTestOrdersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<TypesDetail> TypesDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.getItem(ConfigurationManager._defaultConnection));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client", "Orders");

                entity.HasComment("Tabla con los datos del cliente");

                entity.HasIndex(e => e.DocNumber, "client_UN")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Identificador único del campo");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasComment("Fecha de creaciòn");

                entity.Property(e => e.DocNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("doc_number")
                    .HasComment("Número de documento del cliente");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasComment("Identificador del genero del usuario");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified")
                    .HasComment("Fecha última modificación");

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("last_name")
                    .HasComment("Apellidos del cliente");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("Nombre del cliente");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1: Activo, 0: Inactivo; Borrado lógico");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.Gender)
                    .HasConstraintName("client_FK");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order", "Orders");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Identificador único del campo");

                entity.Property(e => e.ClientId)
                    .HasColumnName("client_id")
                    .HasComment("Identificador del cliente");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("code")
                    .HasComment("Código del pedido");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasComment("Fecha de creaciòn");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified")
                    .HasComment("Fecha última modificación");

                entity.Property(e => e.OrderPriority)
                    .HasColumnName("order_priority")
                    .HasComment("Prioridad del pedido");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasComment("Estado del pedido");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1: Activo, 0: Inactivo; Borrado lógico");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_FK_2");

                entity.HasOne(d => d.OrderPriorityNavigation)
                    .WithMany(p => p.OrderOrderPriorityNavigations)
                    .HasForeignKey(d => d.OrderPriority)
                    .HasConstraintName("order_FK_1");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.OrderOrderStatusNavigations)
                    .HasForeignKey(d => d.OrderStatus)
                    .HasConstraintName("order_FK");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_details", "Orders");

                entity.HasComment("Detalles de la orden");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Identificador único del campo");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasComment("Fecha de creación");

                entity.Property(e => e.Cuantity)
                    .HasColumnName("cuantity")
                    .HasComment("Cantidad de producto a registrar");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified")
                    .HasComment("Fecha última modificación");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("Identificador de la orden");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("Identificador del prodcuto");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1: Activo, 0: Inactivo; Borrado lógico");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_details_FK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_details_FK_1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "Orders");

                entity.HasComment("Tabla con los datos de los productos");

                entity.HasIndex(e => e.Code, "product_UN")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Identificador único del campo");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("code")
                    .HasComment("Código del producto");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasComment("Fecha de creaciòn");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified")
                    .HasComment("Fecha última modificación");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("Nombre dle producto");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasComment("Precio del producto");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1: Activo, 0: Inactivo; Borrado lógico");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("types", "Orders");

                entity.HasComment("Tabla de artefactos globales de la aplicaciòn (EJ:Estado pedido, tipo pedido, etc)");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Identificador único del campo");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasComment("Fecha de creaciòn");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified")
                    .HasComment("Fecha última modificación");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("Nombre del tipo");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1: Activo, 0: Inactivo; Borrado lògico");
            });

            modelBuilder.Entity<TypesDetail>(entity =>
            {
                entity.ToTable("types_details", "Orders");

                entity.HasComment("Contiene el detalle de los tipos, EJ: tipo Estado Pedido, detalle => abierto, cerrado");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id")
                    .HasComment("Identificador único del campo");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasComment("Fecha de creaciòn");

                entity.Property(e => e.LastModified)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified")
                    .HasComment("Fecha última modificación");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("Nombre del tipo detalle");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1: Activo, 0: Inactivo; Borrado lógico");

                entity.Property(e => e.TypesId)
                    .HasColumnName("types_id")
                    .HasComment("Nombre del tipo");

                entity.HasOne(d => d.Types)
                    .WithMany(p => p.TypesDetails)
                    .HasForeignKey(d => d.TypesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("types_details_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
