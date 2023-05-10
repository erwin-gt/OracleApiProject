using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Oracle.DataAccess.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cardex> Cardices { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Descuento> Descuentos { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FormaPago> FormaPagos { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Territorio> Territorios { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=PROYECTO; Password=1234; Data Source=localhost:1521/DB2;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("PROYECTO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Cardex>(entity =>
        {
            entity.HasKey(e => e.Idinventario).HasName("SYS_C007775");

            entity.ToTable("CARDEX");

            entity.Property(e => e.Idinventario)
                .HasPrecision(10)
                .HasColumnName("IDINVENTARIO");
            entity.Property(e => e.Almacen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ALMACEN");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Fecharegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHAREGISTRO");
            entity.Property(e => e.Fechaultimaactualizacion)
                .HasColumnType("DATE")
                .HasColumnName("FECHAULTIMAACTUALIZACION");
            entity.Property(e => e.Numeroserie)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMEROSERIE");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");
            entity.Property(e => e.Preciounitario)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECIOUNITARIO");
            entity.Property(e => e.Valortotal)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("VALORTOTAL");
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.Idcategoriaproducto).HasName("SYS_C007779");

            entity.ToTable("CATEGORIA_PRODUCTO");

            entity.Property(e => e.Idcategoriaproducto)
                .HasPrecision(10)
                .HasColumnName("IDCATEGORIAPRODUCTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Tipomueble)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIPOMUEBLE");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("SYS_C007722");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.Idcliente)
                .HasPrecision(10)
                .HasColumnName("IDCLIENTE");
            entity.Property(e => e.CiudadResidencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CIUDAD_RESIDENCIA");
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTAMENTO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Idusuario)
                .HasPrecision(10)
                .HasColumnName("IDUSUARIO");
            entity.Property(e => e.NombreDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_DOCUMENTO");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAIS");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_NOMBRE");
            entity.Property(e => e.Profesion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROFESION");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_NOMBRE");
            entity.Property(e => e.TelefonoCelular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_CELULAR");
            entity.Property(e => e.TelefonoResidencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_RESIDENCIA");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_DOCUMENTO");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK_USUARIO");
        });

        modelBuilder.Entity<Descuento>(entity =>
        {
            entity.HasKey(e => e.Iddescuento).HasName("SYS_C007728");

            entity.ToTable("DESCUENTO");

            entity.Property(e => e.Iddescuento)
                .HasPrecision(10)
                .HasColumnName("IDDESCUENTO");
            entity.Property(e => e.CondicionesUso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONDICIONES_USO");
            entity.Property(e => e.DescuentoCantidad)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DESCUENTO_CANTIDAD");
            entity.Property(e => e.PorcentajeDescuento)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PORCENTAJE_DESCUENTO");
            entity.Property(e => e.TipoDescuento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_DESCUENTO");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Iddetallefactura).HasName("SYS_C007750");

            entity.ToTable("DETALLE_FACTURA");

            entity.Property(e => e.Iddetallefactura)
                .HasPrecision(10)
                .HasColumnName("IDDETALLEFACTURA");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Iddescuento)
                .HasPrecision(10)
                .HasColumnName("IDDESCUENTO");
            entity.Property(e => e.Idfactura)
                .HasPrecision(10)
                .HasColumnName("IDFACTURA");
            entity.Property(e => e.Preciounitario)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECIOUNITARIO");
            entity.Property(e => e.Totaldetalle)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTALDETALLE");

            entity.HasOne(d => d.IddescuentoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.Iddescuento)
                .HasConstraintName("FK_DESCUENTO_DETALLEFACTURA");

            entity.HasOne(d => d.IdfacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.Idfactura)
                .HasConstraintName("FK_FACTURA_DETALLEFACTURA");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.IddetallePedido).HasName("SYS_C007791");

            entity.ToTable("DETALLE_PEDIDO");

            entity.Property(e => e.IddetallePedido)
                .HasPrecision(10)
                .HasColumnName("IDDETALLE_PEDIDO");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Descuento)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("DESCUENTO");
            entity.Property(e => e.Idpedido)
                .HasPrecision(10)
                .HasColumnName("IDPEDIDO");
            entity.Property(e => e.Idproducto)
                .HasPrecision(10)
                .HasColumnName("IDPRODUCTO");
            entity.Property(e => e.Preciounitario)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECIOUNITARIO");
            entity.Property(e => e.Subtotal)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("SUBTOTAL");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.Idpedido)
                .HasConstraintName("FK_PEDIDO_DETALLE_PEDIDO");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK_PRODUCTO_PEDIDO");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("SYS_C007736");

            entity.ToTable("EMPLEADO");

            entity.HasIndex(e => e.Email, "SYS_C007737").IsUnique();

            entity.Property(e => e.Idempleado)
                .HasPrecision(10)
                .HasColumnName("IDEMPLEADO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Dpi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DPI");
            entity.Property(e => e.Edad)
                .HasPrecision(3)
                .HasColumnName("EDAD");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Evaluaciondesempeno)
                .HasPrecision(3)
                .HasColumnName("EVALUACIONDESEMPENO");
            entity.Property(e => e.Fechacontratacion)
                .HasColumnType("DATE")
                .HasColumnName("FECHACONTRATACION");
            entity.Property(e => e.Idpuesto)
                .HasPrecision(10)
                .HasColumnName("IDPUESTO");
            entity.Property(e => e.Idsucursal)
                .HasPrecision(10)
                .HasColumnName("IDSUCURSAL");
            entity.Property(e => e.Idusuario)
                .HasPrecision(10)
                .HasColumnName("IDUSUARIO");
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_APELLIDO");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMER_NOMBRE");
            entity.Property(e => e.Salario)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("SALARIO");
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_APELLIDO");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDO_NOMBRE");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SEXO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.IdpuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idpuesto)
                .HasConstraintName("FK_PUESTO");

            entity.HasOne(d => d.IdsucursalNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idsucursal)
                .HasConstraintName("FK_SUCURSAL");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK_USUARIOEMPLEADO");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Idfactura).HasName("SYS_C007744");

            entity.ToTable("FACTURA");

            entity.Property(e => e.Idfactura)
                .HasPrecision(10)
                .HasColumnName("IDFACTURA");
            entity.Property(e => e.Estadofactura)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADOFACTURA");
            entity.Property(e => e.Fechaemision)
                .HasColumnType("DATE")
                .HasColumnName("FECHAEMISION");
            entity.Property(e => e.Idcliente)
                .HasPrecision(10)
                .HasColumnName("IDCLIENTE");
            entity.Property(e => e.Idempleado)
                .HasPrecision(10)
                .HasColumnName("IDEMPLEADO");
            entity.Property(e => e.Idformapago)
                .HasPrecision(10)
                .HasColumnName("IDFORMAPAGO");
            entity.Property(e => e.Notas)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOTAS");
            entity.Property(e => e.Total)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK_CLIENTE_FACTURA");

            entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Idempleado)
                .HasConstraintName("FK_EMPLEADO_FACTURA");

            entity.HasOne(d => d.IdformapagoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Idformapago)
                .HasConstraintName("FK_FORMAPAGO_FACTURA");
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.HasKey(e => e.Idformapago).HasName("SYS_C007742");

            entity.ToTable("FORMA_PAGO");

            entity.Property(e => e.Idformapago)
                .HasPrecision(10)
                .HasColumnName("IDFORMAPAGO");
            entity.Property(e => e.Tipopago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPOPAGO");
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.Idordencompra).HasName("SYS_C007765");

            entity.ToTable("ORDEN_COMPRA");

            entity.Property(e => e.Idordencompra)
                .HasPrecision(10)
                .HasColumnName("IDORDENCOMPRA");
            entity.Property(e => e.Cantidad)
                .HasPrecision(10)
                .ValueGeneratedOnAdd()
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Fechacompra)
                .HasColumnType("DATE")
                .HasColumnName("FECHACOMPRA");
            entity.Property(e => e.Idproducto)
                .HasPrecision(10)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDPRODUCTO");
            entity.Property(e => e.Idproveedor)
                .HasPrecision(10)
                .HasColumnName("IDPROVEEDOR");
            entity.Property(e => e.Preciounitario)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECIOUNITARIO");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UBICACION");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.Idproveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDENCOMPRA_FK1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido).HasName("SYS_C007787");

            entity.ToTable("PEDIDO");

            entity.Property(e => e.Idpedido)
                .HasPrecision(10)
                .HasColumnName("IDPEDIDO");
            entity.Property(e => e.Estadoenvio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ESTADOENVIO");
            entity.Property(e => e.Fechaentrega)
                .HasColumnType("DATE")
                .HasColumnName("FECHAENTREGA");
            entity.Property(e => e.Fechapedido)
                .HasColumnType("DATE")
                .HasColumnName("FECHAPEDIDO");
            entity.Property(e => e.Idfactura)
                .HasPrecision(10)
                .HasColumnName("IDFACTURA");

            entity.HasOne(d => d.IdfacturaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idfactura)
                .HasConstraintName("FK_FACTURA_PEDIDO");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("SYS_C007782");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.Idproducto)
                .HasPrecision(10)
                .HasColumnName("IDPRODUCTO");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLOR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Dimensiones)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DIMENSIONES");
            entity.Property(e => e.Foto)
                .HasColumnType("BLOB")
                .HasColumnName("FOTO");
            entity.Property(e => e.Idcategoriaproducto)
                .HasPrecision(10)
                .HasColumnName("IDCATEGORIAPRODUCTO");
            entity.Property(e => e.Idinventario)
                .HasPrecision(10)
                .HasColumnName("IDINVENTARIO");
            entity.Property(e => e.Idordencompra)
                .HasPrecision(10)
                .HasColumnName("IDORDENCOMPRA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IdcategoriaproductoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idcategoriaproducto)
                .HasConstraintName("FK_CATEGORIAPRODUCTO_PRODUCTO");

            entity.HasOne(d => d.IdinventarioNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idinventario)
                .HasConstraintName("FK_CARDEX_PRODUCTO");

            entity.HasOne(d => d.IdordencompraNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idordencompra)
                .HasConstraintName("FK_ORDENCOMPRA_PRODUCTO");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Idproveedor).HasName("SYS_C007758");

            entity.ToTable("PROVEEDOR");

            entity.Property(e => e.Idproveedor)
                .HasPrecision(10)
                .HasColumnName("IDPROVEEDOR");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nombreempresa)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBREEMPRESA");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Idpuesto).HasName("SYS_C007731");

            entity.ToTable("PUESTO");

            entity.Property(e => e.Idpuesto)
                .HasPrecision(10)
                .HasColumnName("IDPUESTO");
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTAMENTO");
            entity.Property(e => e.Niveljuridico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIVELJURIDICO");
            entity.Property(e => e.Nombrepuesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBREPUESTO");
            entity.Property(e => e.Salario)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("SALARIO");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Idregion).HasName("SYS_C007710");

            entity.ToTable("REGION");

            entity.Property(e => e.Idregion)
                .HasPrecision(10)
                .HasColumnName("IDREGION");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CIUDAD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROVINCIA");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Idsucursal).HasName("SYS_C007725");

            entity.ToTable("SUCURSAL");

            entity.Property(e => e.Idsucursal)
                .HasPrecision(10)
                .HasColumnName("IDSUCURSAL");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Idterritorio)
                .HasPrecision(10)
                .HasColumnName("IDTERRITORIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMERO");

            entity.HasOne(d => d.IdterritorioNavigation).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.Idterritorio)
                .HasConstraintName("FK_TERRITORIO");
        });

        modelBuilder.Entity<Territorio>(entity =>
        {
            entity.HasKey(e => e.Idterritorio).HasName("SYS_C007712");

            entity.ToTable("TERRITORIO");

            entity.Property(e => e.Idterritorio)
                .HasPrecision(10)
                .HasColumnName("IDTERRITORIO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Idregion)
                .HasPrecision(10)
                .HasColumnName("IDREGION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdregionNavigation).WithMany(p => p.Territorios)
                .HasForeignKey(d => d.Idregion)
                .HasConstraintName("FK_REGION");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Idtipousuario).HasName("SYS_C007715");

            entity.ToTable("TIPO_USUARIO");

            entity.Property(e => e.Idtipousuario)
                .HasPrecision(10)
                .HasColumnName("IDTIPOUSUARIO");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.NombreTipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TIPO_USUARIO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("SYS_C007717");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Idusuario)
                .HasPrecision(10)
                .HasColumnName("IDUSUARIO");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRASEÑA");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Idtipousuario)
                .HasPrecision(10)
                .HasColumnName("IDTIPOUSUARIO");
            entity.Property(e => e.Permisos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERMISOS");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROL");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.IdtipousuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idtipousuario)
                .HasConstraintName("FK_TIPO_USUARIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
