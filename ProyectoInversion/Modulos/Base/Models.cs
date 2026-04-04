using System.Collections.Generic;

namespace ProyectoInversion
{
    public class IndicadoresBase
    {
        public decimal VAN { get; set; }
        public decimal TIR_Pct { get; set; } 
        public decimal IR { get; set; }
        public decimal? PeriodoRecupNormal { get; set; }
        public decimal? PeriodoRecupDesc { get; set; }
        public decimal InversionInicial { get; set; }
        public decimal TasaDescuento_Pct { get; set; } 
        public int     HorizonteAnios { get; set; }

        public string VANFormateado => $"${VAN:N0}";
        public string TIRFormateado => $"{TIR_Pct:N2}%";
        public string IRFormateado => IR.ToString("N4");
        public string InversionFormateada => $"${InversionInicial:N0}";
        public string PeriodoRecupFormateado => 
            PeriodoRecupNormal == null ? "N/A" : 
            $"{(int)PeriodoRecupNormal.Value}–{(int)PeriodoRecupNormal.Value + 1} años";
    }
    public class FlujoCajaAnual
    {
        public int Anio { get; set; }
        public decimal FlujoPeriodo { get; set; }
    }
}
