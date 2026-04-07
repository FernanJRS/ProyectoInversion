using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoInversion.Clases
{
    public class AlternativaModel
    {
        public int AlternativaID { get; set; }
        public int SimulacionID { get; set; }
        public int? AlternativaBaseID { get; set; }
        public string Nombre { get; set; }
        public string TipoAlternativa { get; set; } = "Personalizada";
        public bool EsBase { get; set; }
        public decimal? Probabilidad { get; set; }
        public string Notas { get; set; }
        public DateTime FechaGuardado { get; set; }

        // ── Parámetros propios de la alternativa ──
        public decimal TasaDescuento { get; set; }
        public decimal TasaImpuesto { get; set; }
        public decimal VentasAnio1 { get; set; }   // = Demanda año 1
        public decimal PrecioBase { get; set; }   // = Precio
        public decimal CostoVarBase { get; set; }   // = Costo Variable
        public decimal CostoFijoBase { get; set; }   // = Costo Fijo

        // ── Activos (campos del formulario) ──
        public decimal Construccion { get; set; }
        public decimal MaquinaA { get; set; }
        public decimal MaquinaB { get; set; }
        public decimal Terreno { get; set; }

        // ── Indicadores calculados ──
        public decimal? VAN { get; set; }
        public decimal? TIR { get; set; }
        public decimal? IndiceRentabilidad { get; set; }
        public decimal? PeriodoRecupNormal { get; set; }
        public decimal? PeriodoRecupDesc { get; set; }
        public decimal? InversionInicial { get; set; }
        public decimal? ValorDesechoEcon { get; set; }
        public string Viabilidad { get; set; }
        public string EvalTIR { get; set; }
    }

    public class IndicadoresModel
    {
        public decimal? VAN { get; set; }
        public decimal? TIR { get; set; }
        public decimal? TIR_Pct { get; set; }
        public decimal? IndiceRentabilidad { get; set; }
        public decimal? PeriodoRecupNormal { get; set; }
        public decimal? PeriodoRecupDesc { get; set; }
        public decimal? InversionInicial { get; set; }
        public decimal? ValorDesechoEcon { get; set; }
        public string Viabilidad { get; set; }
        public string EvalTIR { get; set; }
    }
}
