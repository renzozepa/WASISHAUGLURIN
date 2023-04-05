namespace WASISHAUGLURIN.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelSISHAUGLURIN : DbContext
    {
        public ModelSISHAUGLURIN()
            : base("name=ModelSISHAUGLURIN")
        {
        }

        public virtual DbSet<ActaLiberacionCliente> ActaLiberacionCliente { get; set; }
        public virtual DbSet<ActaLiberacionClienteDetalle> ActaLiberacionClienteDetalle { get; set; }
        public virtual DbSet<ActaLiberacionInterna> ActaLiberacionInterna { get; set; }
        public virtual DbSet<ActaLiberacionInternaDetalle> ActaLiberacionInternaDetalle { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<ProyectoElemento> ProyectoElemento { get; set; }
        public virtual DbSet<ProyectoEnsamble> ProyectoEnsamble { get; set; }
        public virtual DbSet<ProyectoPeriodoCalendario> ProyectoPeriodoCalendario { get; set; }
        public virtual DbSet<ProyectoProducto> ProyectoProducto { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActaLiberacionCliente>()
                .Property(e => e.NActaLiberacion)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionCliente>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionCliente>()
                .Property(e => e.CodPeriodo)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionClienteDetalle>()
                .Property(e => e.NActaLiberacion)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionClienteDetalle>()
                .Property(e => e.CodElemento)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionClienteDetalle>()
                .Property(e => e.CodMarca)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionClienteDetalle>()
                .Property(e => e.Plano)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionClienteDetalle>()
                .Property(e => e.Revision)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionClienteDetalle>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionClienteDetalle>()
                .Property(e => e.Detalle)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInterna>()
                .Property(e => e.NActaLiberacion)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInterna>()
                .Property(e => e.Revision)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInterna>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInterna>()
                .Property(e => e.NActaLiberacion1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInterna>()
                .Property(e => e.CodPeriodo)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.NActaLiberacion)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.CodElemento)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.CodMarca)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.Plano)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.Revision)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.VT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.PT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.UT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.RT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.Detalle)
                .IsUnicode(false);

            modelBuilder.Entity<ActaLiberacionInternaDetalle>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Anio)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.CodPartidaProyecto)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Monto)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.PesoProyecto)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.TipoProyecto)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.LineaNegocio)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.CodPeriodo)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.CodProducto)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.CodEnsamble)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.CodMarca)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.CodElemento)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.DescribeElemento)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Grado)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Peso)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Area)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Largo)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Plano)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Revision)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Pedido)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Hoja)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Fluido)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.PlgDiaTotal)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.PlgDiaTaller)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.PlgDiaObra)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.PlgDiaRanurada)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.PaintSystem)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.PlanoEnsamble)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Grupo)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.POE)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NOrdenTrabajo)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NOrdenTrabajoGranalla)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NOrdenTrabajoPintura)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstFinNegro)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstLibNegro)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstPinBase)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstPinAcabado)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstLibCliente)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NActaLibCliente)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDespacho)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NDespacho)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NPacking)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.ControlCambio)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NotaTecnica)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.NotaTecnicaPintura)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Ancho)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Altura)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.plgdiametral)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Clasificacion)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDocTrazabilidad)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDocDimensional)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDocVisual)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDocTintes)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDocUltrasonido)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDocCapaBase)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstDocCapaAcabado)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.Carpeta)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.EstLibPintura)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.CodElementoAlterno1)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.CodPeriodo)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceMaterial)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceHabilitado)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceRolPle)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceArmado)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceSoldadura)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvancePrensamble)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceInstLinSupp)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceInspNegro)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceGranallado)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvancePintura)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceInspFinal)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoElemento>()
                .Property(e => e.AvanceEmbalaje)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoEnsamble>()
                .Property(e => e.CodProducto)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoEnsamble>()
                .Property(e => e.CodEnsamble)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoEnsamble>()
                .Property(e => e.DescripcionEnsamble)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoEnsamble>()
                .Property(e => e.PesoTotalEnsamble)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoEnsamble>()
                .Property(e => e.PesoAceroEnsamble)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoEnsamble>()
                .Property(e => e.PlanoEnsamble)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoPeriodoCalendario>()
                .Property(e => e.CodProyecto)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoPeriodoCalendario>()
                .Property(e => e.CodPeriodo)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoPeriodoCalendario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoPeriodoCalendario>()
                .Property(e => e.PeriodoCalendario)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoProducto>()
                .Property(e => e.CodProducto)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoProducto>()
                .Property(e => e.DescripcionProducto)
                .IsUnicode(false);

            modelBuilder.Entity<ProyectoProducto>()
                .Property(e => e.PesoTotalProducto)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoProducto>()
                .Property(e => e.PesoAceroProducto)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ProyectoProducto>()
                .Property(e => e.PlanoGeneral)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.Usuario)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
