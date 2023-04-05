using AppCalidad.Tablas;
using System;
namespace AppCalidad.ViewModels
{
    public class EProyectoElementoViewModel : BaseViewModel
    {
        private int _CodProyecto;
        public int CodProyecto { get { return _CodProyecto; } set { _CodProyecto = value; } }
        private string _CodProducto;
        public string CodProducto { get { return _CodProducto; } set { _CodProducto = value; } }
        private string _CodEnsamble;
        public string CodEnsamble { get { return _CodEnsamble; } set { _CodEnsamble = value; } }
        private string _CodMarca;
        public string CodMarca { get { return _CodMarca; } set { _CodMarca = value; } }
        private string _CodElemento;
        public string CodElemento { get { return _CodElemento; } set { _CodElemento = value; } }
        private string _DescribeElemento;
        public string DescribeElemento { get { return _DescribeElemento; } set { _DescribeElemento = value; } }
        private string _Grado;
        public string Grado { get { return _Grado; } set { _Grado = value; } }
        private int? _Cantidad;
        public int? Cantidad { get { return _Cantidad; } set { _Cantidad = value; } }
        private decimal? _Peso;
        public decimal? Peso { get { return _Peso; } set { _Peso = value; } }
        private decimal? _Area;
        public decimal? Area { get { return _Area; } set { _Area = value; } }
        private decimal? _Largo;
        public decimal? Largo { get { return _Largo; } set { _Largo = value; } }
        private string _Plano;
        public string Plano { get { return _Plano; } set { _Plano = value; } }
        private string _Revision;
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private int? _Nivel;
        public int? Nivel { get { return _Nivel; } set { _Nivel = value; } }
        private string _Tipo;
        public string Tipo { get { return _Tipo; } set { _Tipo = value; } }
        private string _Pedido;
        public string Pedido { get { return _Pedido; } set { _Pedido = value; } }
        private string _Hoja;
        public string Hoja { get { return _Hoja; } set { _Hoja = value; } }
        private string _Fluido;
        public string Fluido { get { return _Fluido; } set { _Fluido = value; } }
        private decimal? _PlgDiaTotal;
        public decimal? PlgDiaTotal { get { return _PlgDiaTotal; } set { _PlgDiaTotal = value; } }
        private decimal? _PlgDiaTaller;
        public decimal? PlgDiaTaller { get { return _PlgDiaTaller; } set { _PlgDiaTaller = value; } }
        private decimal? _PlgDiaObra;
        public decimal? PlgDiaObra { get { return _PlgDiaObra; } set { _PlgDiaObra = value; } }
        private decimal? _PlgDiaRanurada;
        public decimal? PlgDiaRanurada { get { return _PlgDiaRanurada; } set { _PlgDiaRanurada = value; } }
        private string _PaintSystem;
        public string PaintSystem { get { return _PaintSystem; } set { _PaintSystem = value; } }
        private string _PlanoEnsamble;
        public string PlanoEnsamble { get { return _PlanoEnsamble; } set { _PlanoEnsamble = value; } }
        private string _Grupo;
        public string Grupo { get { return _Grupo; } set { _Grupo = value; } }
        private string _POE;
        public string POE { get { return _POE; } set { _POE = value; } }
        private int? _CodContrata;
        public int? CodContrata { get { return _CodContrata; } set { _CodContrata = value; } }
        private string _NOrdenTrabajo;
        public string NOrdenTrabajo { get { return _NOrdenTrabajo; } set { _NOrdenTrabajo = value; } }
        private string _NOrdenTrabajoGranalla;
        public string NOrdenTrabajoGranalla { get { return _NOrdenTrabajoGranalla; } set { _NOrdenTrabajoGranalla = value; } }
        private string _NOrdenTrabajoPintura;
        public string NOrdenTrabajoPintura { get { return _NOrdenTrabajoPintura; } set { _NOrdenTrabajoPintura = value; } }
        private int? _AvanceFisico;
        public int? AvanceFisico { get { return _AvanceFisico; } set { _AvanceFisico = value; } }
        private string _EstFinNegro;
        public string EstFinNegro { get { return _EstFinNegro; } set { _EstFinNegro = value; } }
        private DateTime? _FecFinNegro;
        public DateTime? FecFinNegro { get { return _FecFinNegro; } set { _FecFinNegro = value; } }
        private int? _CantNegro;
        public int? CantNegro { get { return _CantNegro; } set { _CantNegro = value; } }
        private string _EstLibNegro;
        public string EstLibNegro { get { return _EstLibNegro; } set { _EstLibNegro = value; } }
        private DateTime? _FecLibNegro;
        public DateTime? FecLibNegro { get { return _FecLibNegro; } set { _FecLibNegro = value; } }
        private int? _CantLibNegro;
        public int? CantLibNegro { get { return _CantLibNegro; } set { _CantLibNegro = value; } }
        private string _EstPinBase;
        public string EstPinBase { get { return _EstPinBase; } set { _EstPinBase = value; } }
        private DateTime? _FecPinBase;
        public DateTime? FecPinBase { get { return _FecPinBase; } set { _FecPinBase = value; } }
        private int? _CantBase;
        public int? CantBase { get { return _CantBase; } set { _CantBase = value; } }
        private string _EstPinAcabado;
        public string EstPinAcabado { get { return _EstPinAcabado; } set { _EstPinAcabado = value; } }
        private DateTime? _FecPinAcabado;
        public DateTime? FecPinAcabado { get { return _FecPinAcabado; } set { _FecPinAcabado = value; } }
        private int? _CantAcabado;
        public int? CantAcabado { get { return _CantAcabado; } set { _CantAcabado = value; } }
        private string _EstLibCliente;
        public string EstLibCliente { get { return _EstLibCliente; } set { _EstLibCliente = value; } }
        private DateTime? _FecLibCliente;
        public DateTime? FecLibCliente { get { return _FecLibCliente; } set { _FecLibCliente = value; } }
        private int? _CantLibCliente;
        public int? CantLibCliente { get { return _CantLibCliente; } set { _CantLibCliente = value; } }
        private string _NActaLibCliente;
        public string NActaLibCliente { get { return _NActaLibCliente; } set { _NActaLibCliente = value; } }
        private string _EstDespacho;
        public string EstDespacho { get { return _EstDespacho; } set { _EstDespacho = value; } }
        private string _NDespacho;
        public string NDespacho { get { return _NDespacho; } set { _NDespacho = value; } }
        private int? _CantDespacho;
        public int? CantDespacho { get { return _CantDespacho; } set { _CantDespacho = value; } }
        private DateTime? _FecDespacho;
        public DateTime? FecDespacho { get { return _FecDespacho; } set { _FecDespacho = value; } }
        private string _NPacking;
        public string NPacking { get { return _NPacking; } set { _NPacking = value; } }
        private string _ControlCambio;
        public string ControlCambio { get { return _ControlCambio; } set { _ControlCambio = value; } }
        private string _NotaTecnica;
        public string NotaTecnica { get { return _NotaTecnica; } set { _NotaTecnica = value; } }
        private string _NotaTecnicaPintura;
        public string NotaTecnicaPintura { get { return _NotaTecnicaPintura; } set { _NotaTecnicaPintura = value; } }
        private decimal? _Ancho;
        public decimal? Ancho { get { return _Ancho; } set { _Ancho = value; } }
        private decimal? _Altura;
        public decimal? Altura { get { return _Altura; } set { _Altura = value; } }
        public decimal? _plgdiametral;
        public decimal? plgdiametral { get { return _plgdiametral; } set { _plgdiametral = value; } }
        private string _Clasificacion;
        public string Clasificacion { get { return _Clasificacion; } set { _Clasificacion = value; } }
        private string _EstDocTrazabilidad;
        public string EstDocTrazabilidad { get { return _EstDocTrazabilidad; } set { _EstDocTrazabilidad = value; } }
        private DateTime? _FecDocTrazabilidad;
        public DateTime? FecDocTrazabilidad { get { return _FecDocTrazabilidad; } set { _FecDocTrazabilidad = value; } }
        private string _EstDocDimensional;
        public string EstDocDimensional { get { return _EstDocDimensional; } set { _EstDocDimensional = value; } }
        private DateTime? _FecDocDimensional;
        public DateTime? FecDocDimensional { get { return _FecDocDimensional; } set { _FecDocDimensional = value; } }
        private string _EstDocVisual;
        public string EstDocVisual { get { return _EstDocVisual; } set { _EstDocVisual = value; } }
        private DateTime? _FecDocVisual;
        public DateTime? FecDocVisual { get { return _FecDocVisual; } set { _FecDocVisual = value; } }
        private string _EstDocTintes;
        public string EstDocTintes { get { return _EstDocTintes; } set { _EstDocTintes = value; } }
        private DateTime? _FecDocTintes;
        public DateTime? FecDocTintes { get { return _FecDocTintes; } set { _FecDocTintes = value; } }
        private string _EstDocUltrasonido;
        public string EstDocUltrasonido { get { return _EstDocUltrasonido; } set { _EstDocUltrasonido = value; } }
        private DateTime? _FecDocUltrasonido;
        public DateTime? FecDocUltrasonido { get { return _FecDocUltrasonido; } set { _FecDocUltrasonido = value; } }
        private string _EstDocCapaBase;
        public string EstDocCapaBase { get { return _EstDocCapaBase; } set { _EstDocCapaBase = value; } }
        private DateTime? _FecDocCapaBase;
        public DateTime? FecDocCapaBase { get { return _FecDocCapaBase; } set { _FecDocCapaBase = value; } }
        private string _EstDocCapaAcabado;
        public string EstDocCapaAcabado { get { return _EstDocCapaAcabado; } set { _EstDocCapaAcabado = value; } }
        private DateTime? _FecDocCapaAcabado;
        public DateTime? FecDocCapaAcabado { get { return _FecDocCapaAcabado; } set { _FecDocCapaAcabado = value; } }
        private string _Carpeta;
        public string Carpeta { get { return _Carpeta; } set { _Carpeta = value; } }
        private string _EstLibPintura;
        public string EstLibPintura { get { return _EstLibPintura; } set { _EstLibPintura = value; } }
        private DateTime? _FecLibPintura;
        public DateTime? FecLibPintura { get { return _FecLibPintura; } set { _FecLibPintura = value; } }
        private int? _CantLibPintura;
        public int? CantLibPintura { get { return _CantLibPintura; } set { _CantLibPintura = value; } }
        private string _CodElementoAlterno1;
        public string CodElementoAlterno1 { get { return _CodElementoAlterno1; } set { _CodElementoAlterno1 = value; } }
        private string _CodPeriodo;
        public string CodPeriodo { get { return _CodPeriodo; } set { _CodPeriodo = value; } }
        private decimal? _AvanceMaterial;
        public decimal? AvanceMaterial { get { return _AvanceMaterial; } set { _AvanceMaterial = value; } }
        private decimal? _AvanceHabilitado;
        public decimal? AvanceHabilitado { get { return _AvanceHabilitado; } set { _AvanceHabilitado = value; } }
        private decimal? _AvanceRolPle;
        public decimal? AvanceRolPle { get { return _AvanceRolPle; } set { _AvanceRolPle = value; } }
        private decimal? _AvanceArmado;
        public decimal? AvanceArmado { get { return _AvanceArmado; } set { _AvanceArmado = value; } }
        private decimal? _AvanceSoldadura;
        public decimal? AvanceSoldadura { get { return _AvanceSoldadura; } set { _AvanceSoldadura = value; } }
        private decimal? _AvancePrensamble;
        public decimal? AvancePrensamble { get { return _AvancePrensamble; } set { _AvancePrensamble = value; } }
        private decimal? _AvanceInstLinSupp;
        public decimal? AvanceInstLinSupp { get { return _AvanceInstLinSupp; } set { _AvanceInstLinSupp = value; } }
        private decimal? _AvanceInspNegro;
        public decimal? AvanceInspNegro { get { return _AvanceInspNegro; } set { _AvanceInspNegro = value; } }
        private decimal? _AvanceGranallado;
        public decimal? AvanceGranallado { get { return _AvanceGranallado; } set { _AvanceGranallado = value; } }
        private decimal? _AvancePintura;
        public decimal? AvancePintura { get { return _AvancePintura; } set { _AvancePintura = value; } }
        private decimal? _AvanceInspFinal;
        public decimal? AvanceInspFinal { get { return _AvanceInspFinal; } set { _AvanceInspFinal = value; } }
        private decimal? _AvanceEmbalaje;
        public decimal? AvanceEmbalaje { get { return _AvanceEmbalaje; } set { _AvanceEmbalaje = value; } }

        public EProyectoElementoViewModel()
        {

        }

        public EProyectoElementoViewModel(ProyectoElemento proyelem)
        {
            CodProyecto = proyelem.CodProyecto;
            CodProducto = proyelem.CodProducto;
            CodEnsamble = proyelem.CodEnsamble;
            CodMarca = proyelem.CodMarca;
            CodElemento = proyelem.CodElemento;
            DescribeElemento = proyelem.DescribeElemento;
            Grado = proyelem.Grado;
            Cantidad = proyelem.Cantidad;
            Peso = proyelem.Peso;
            Area = proyelem.Area;
            Largo = proyelem.Largo;
            Plano = proyelem.Plano;
            Revision = proyelem.Revision;
            Nivel = proyelem.Nivel;
            Tipo = proyelem.Tipo;
            Pedido = proyelem.Pedido;
            Hoja = proyelem.Hoja;
            Fluido = proyelem.Fluido;
            PlgDiaTotal = proyelem.PlgDiaTotal;
            PlgDiaTaller = proyelem.PlgDiaTaller;
            PlgDiaObra = proyelem.PlgDiaObra;
            PlgDiaRanurada = proyelem.PlgDiaRanurada;
            PaintSystem = proyelem.PaintSystem;
            PlanoEnsamble = proyelem.PlanoEnsamble;
            Grupo = proyelem.Grupo;
            POE = proyelem.POE;
            CodContrata = proyelem.CodContrata;
            NOrdenTrabajo = proyelem.NOrdenTrabajo;
            NOrdenTrabajoGranalla = proyelem.NOrdenTrabajoGranalla;
            NOrdenTrabajoPintura = proyelem.NOrdenTrabajoPintura;
            AvanceFisico = proyelem.AvanceFisico;
            EstFinNegro = proyelem.EstFinNegro;
            FecFinNegro = proyelem.FecFinNegro;
            CantNegro = proyelem.CantNegro;
            EstLibNegro = proyelem.EstLibNegro;
            FecLibNegro = proyelem.FecLibNegro;
            CantLibNegro = proyelem.CantLibNegro;
            EstPinBase = proyelem.EstPinBase;
            FecPinBase = proyelem.FecPinBase;
            CantBase = proyelem.CantBase;
            EstPinAcabado = proyelem.EstPinAcabado;
            FecPinAcabado = proyelem.FecPinAcabado;
            CantAcabado = proyelem.CantAcabado;
            EstLibCliente = proyelem.EstLibCliente;
            FecLibCliente = proyelem.FecLibCliente;
            CantLibCliente = proyelem.CantLibCliente;
            NActaLibCliente = proyelem.NActaLibCliente;
            EstDespacho = proyelem.EstDespacho;
            NDespacho = proyelem.NDespacho;
            CantDespacho = proyelem.CantDespacho;
            FecDespacho = proyelem.FecDespacho;
            NPacking = proyelem.NPacking;
            ControlCambio = proyelem.ControlCambio;
            NotaTecnica = proyelem.NotaTecnica;
            NotaTecnicaPintura = proyelem.NotaTecnicaPintura;
            Ancho = proyelem.Ancho;
            Altura = proyelem.Altura;
            plgdiametral = proyelem.plgdiametral;
            Clasificacion = proyelem.Clasificacion;
            EstDocTrazabilidad = proyelem.EstDocTrazabilidad;
            FecDocTrazabilidad = proyelem.FecDocTrazabilidad;
            EstDocDimensional = proyelem.EstDocDimensional;
            FecDocDimensional = proyelem.FecDocDimensional;
            EstDocVisual = proyelem.EstDocVisual;
            FecDocVisual = proyelem.FecDocVisual;
            EstDocTintes = proyelem.EstDocTintes;
            FecDocTintes = proyelem.FecDocTintes;
            EstDocUltrasonido = proyelem.EstDocUltrasonido;
            FecDocUltrasonido = proyelem.FecDocUltrasonido;
            EstDocCapaBase = proyelem.EstDocCapaBase;
            FecDocCapaBase = proyelem.FecDocCapaBase;
            EstDocCapaAcabado = proyelem.EstDocCapaAcabado;
            FecDocCapaAcabado = proyelem.FecDocCapaAcabado;
            Carpeta = proyelem.Carpeta;
            EstLibPintura = proyelem.EstLibPintura;
            FecLibPintura = proyelem.FecLibPintura;
            CantLibPintura = proyelem.CantLibPintura;
            CodElementoAlterno1 = proyelem.CodElementoAlterno1;
            CodPeriodo = proyelem.CodPeriodo;
            AvanceMaterial = proyelem.AvanceMaterial;
            AvanceHabilitado = proyelem.AvanceHabilitado;
            AvanceRolPle = proyelem.AvanceRolPle;
            AvanceArmado = proyelem.AvanceArmado;
            AvanceSoldadura = proyelem.AvanceSoldadura;
            AvancePrensamble = proyelem.AvancePrensamble;
            AvanceInstLinSupp = proyelem.AvanceInstLinSupp;
            AvanceInspNegro = proyelem.AvanceInspNegro;
            AvanceGranallado = proyelem.AvanceGranallado;
            AvancePintura = proyelem.AvancePintura;
            AvanceInspFinal = proyelem.AvanceInspFinal;
            AvanceEmbalaje = proyelem.AvanceEmbalaje;
        }

        public ProyectoElemento GetProyectoElemento()
        {
            return new ProyectoElemento()
            {
                CodProyecto = this.CodProyecto,
            CodProducto = this.CodProducto,
            CodEnsamble = this.CodEnsamble,
            CodMarca = this.CodMarca,
            CodElemento = this.CodElemento,
            DescribeElemento = this.DescribeElemento,
            Grado = this.Grado,
            Cantidad = this.Cantidad,
            Peso = this.Peso,
            Area = this.Area,
            Largo = this.Largo,
            Plano = this.Plano,
            Revision = this.Revision,
            Nivel = this.Nivel,
            Tipo = this.Tipo,
            Pedido = this.Pedido,
            Hoja = this.Hoja,
            Fluido = this.Fluido,
            PlgDiaTotal = this.PlgDiaTotal,
            PlgDiaTaller = this.PlgDiaTaller,
            PlgDiaObra = this.PlgDiaObra,
            PlgDiaRanurada = this.PlgDiaRanurada,
            PaintSystem = this.PaintSystem,
            PlanoEnsamble = this.PlanoEnsamble,
            Grupo = this.Grupo,
            POE = this.POE,
            CodContrata = this.CodContrata,
            NOrdenTrabajo = this.NOrdenTrabajo,
            NOrdenTrabajoGranalla = this.NOrdenTrabajoGranalla,
            NOrdenTrabajoPintura = this.NOrdenTrabajoPintura,
            AvanceFisico = this.AvanceFisico,
            EstFinNegro = this.EstFinNegro,
            FecFinNegro = this.FecFinNegro,
            CantNegro = this.CantNegro,
            EstLibNegro = this.EstLibNegro,
            FecLibNegro = this.FecLibNegro,
            CantLibNegro = this.CantLibNegro,
            EstPinBase = this.EstPinBase,
            FecPinBase = this.FecPinBase,
            CantBase = this.CantBase,
            EstPinAcabado = this.EstPinAcabado,
            FecPinAcabado = this.FecPinAcabado,
            CantAcabado = this.CantAcabado,
            EstLibCliente = this.EstLibCliente,
            FecLibCliente = this.FecLibCliente,
            CantLibCliente = this.CantLibCliente,
            NActaLibCliente = this.NActaLibCliente,
            EstDespacho = this.EstDespacho,
            NDespacho = this.NDespacho,
            CantDespacho = this.CantDespacho,
            FecDespacho = this.FecDespacho,
            NPacking = this.NPacking,
            ControlCambio = this.ControlCambio,
            NotaTecnica = this.NotaTecnica,
            NotaTecnicaPintura = this.NotaTecnicaPintura,
            Ancho = this.Ancho,
            Altura = this.Altura,
            plgdiametral = this.plgdiametral,
            Clasificacion = this.Clasificacion,
            EstDocTrazabilidad = this.EstDocTrazabilidad,
            FecDocTrazabilidad = this.FecDocTrazabilidad,
            EstDocDimensional = this.EstDocDimensional,
            FecDocDimensional = this.FecDocDimensional,
            EstDocVisual = this.EstDocVisual,
            FecDocVisual = this.FecDocVisual,
            EstDocTintes = this.EstDocTintes,
            FecDocTintes = this.FecDocTintes,
            EstDocUltrasonido = this.EstDocUltrasonido,
            FecDocUltrasonido = this.FecDocUltrasonido,
            EstDocCapaBase = this.EstDocCapaBase,
            FecDocCapaBase = this.FecDocCapaBase,
            EstDocCapaAcabado = this.EstDocCapaAcabado,
            FecDocCapaAcabado = this.FecDocCapaAcabado,
            Carpeta = this.Carpeta,
            EstLibPintura = this.EstLibPintura,
            FecLibPintura = this.FecLibPintura,
            CantLibPintura = this.CantLibPintura,
            CodElementoAlterno1 = this.CodElementoAlterno1,
            CodPeriodo = this.CodPeriodo,
            AvanceMaterial = this.AvanceMaterial,
            AvanceHabilitado = this.AvanceHabilitado,
            AvanceRolPle = this.AvanceRolPle,
            AvanceArmado = this.AvanceArmado,
            AvanceSoldadura = this.AvanceSoldadura,
            AvancePrensamble = this.AvancePrensamble,
            AvanceInstLinSupp = this.AvanceInstLinSupp,
            AvanceInspNegro = this.AvanceInspNegro,
            AvanceGranallado = this.AvanceGranallado,
            AvancePintura = this.AvancePintura,
            AvanceInspFinal = this.AvanceInspFinal,
            AvanceEmbalaje = this.AvanceEmbalaje
        };
        }
    }
}
