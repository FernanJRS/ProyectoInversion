using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProyectoInversion.Clases;

namespace ProyectoInversion
{
    internal static class DatabaseHelper
    {
        public static IndicadoresBase ObtenerIndicadoresBase()
        {
            const string sql = @"
                SELECT
                    i.VAN,
                    i.TIR * 100           AS TIR_Pct,
                    i.IndiceRentabilidad  AS IR,
                    i.PeriodoRecupNormal,
                    i.PeriodoRecupDesc,
                    i.InversionInicial,
                    s.TasaDescuento * 100 AS TasaDescuento_Pct,
                    s.HorizonteAnios
                FROM proy.IndicadoresAlternativa i
                JOIN proy.Alternativas  a ON a.AlternativaID = i.AlternativaID
                JOIN proy.Simulaciones  s ON s.SimulacionID  = a.SimulacionID
                WHERE a.EsBase          = 1
                  AND a.TipoAlternativa = 'Base';";

            var db = new ConexionDB();
            using (var con = db.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, con))
            using (var rdr = cmd.ExecuteReader())
            {
                if (!rdr.Read()) throw new Exception("No se encontraron datos base.");

                return new IndicadoresBase
                {
                    VAN = rdr.GetDecimal(0),
                    TIR_Pct = rdr.GetDecimal(1),
                    IR = rdr.GetDecimal(2),
                    PeriodoRecupNormal = rdr.IsDBNull(3) ? (decimal?)null : rdr.GetDecimal(3),
                    PeriodoRecupDesc = rdr.IsDBNull(4) ? (decimal?)null : rdr.GetDecimal(4),
                    InversionInicial = rdr.GetDecimal(5),
                    TasaDescuento_Pct = rdr.GetDecimal(6),
                    HorizonteAnios = rdr.GetInt32(7)
                };
            }
        }
        public static List<FlujoCajaAnual> ObtenerFlujoCajaBase()
        {
            const string sql = @"
                SELECT
                    f.Anio,
                    f.FlujoPeriodo
                FROM proy.FlujoCajaAlternativa f
                JOIN proy.Alternativas a ON a.AlternativaID = f.AlternativaID
                WHERE a.EsBase          = 1
                  AND a.TipoAlternativa = 'Base'
                  AND f.Anio           >= 1
                ORDER BY f.Anio;";

            var lista = new List<FlujoCajaAnual>();
            var db = new ConexionDB();
            using (var con = db.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, con))
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    lista.Add(new FlujoCajaAnual { Anio = rdr.GetInt32(0), FlujoPeriodo = rdr.GetDecimal(1) });
                }
            }
            return lista;
        }
        public static DataTable ObtenerAlternativas()
        {
            const string sql = @"
        SELECT AlternativaID, Nombre, TipoAlternativa
        FROM proy.Alternativas
        ORDER BY AlternativaID";

            var dt = new DataTable();
            using (var con = new ConexionDB().ObtenerConexion())
            using (var cmd = new SqlCommand(sql, con))
            using (var da = new SqlDataAdapter(cmd))
                da.Fill(dt);

            return dt;
        }
        public static IndicadoresBase ObtenerIndicadoresPorID(int alternativaID)
        {
            const string sql = @"
        SELECT
            i.VAN,
            i.TIR * 100           AS TIR_Pct,
            i.IndiceRentabilidad  AS IR,
            i.PeriodoRecupNormal,
            i.PeriodoRecupDesc,
            i.InversionInicial,
            s.TasaDescuento * 100 AS TasaDescuento_Pct,
            s.HorizonteAnios
        FROM proy.IndicadoresAlternativa i
        JOIN proy.Alternativas a ON a.AlternativaID = i.AlternativaID
        JOIN proy.Simulaciones s ON s.SimulacionID  = a.SimulacionID
        WHERE i.AlternativaID = @id";

            using (var con = new ConexionDB().ObtenerConexion())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", alternativaID);
                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read())
                        throw new Exception($"No se encontraron indicadores para la alternativa {alternativaID}.");

                    return new IndicadoresBase
                    {
                        VAN = rdr.GetDecimal(0),
                        TIR_Pct = rdr.GetDecimal(1),
                        IR = rdr.GetDecimal(2),
                        PeriodoRecupNormal = rdr.IsDBNull(3) ? (decimal?)null : rdr.GetDecimal(3),
                        PeriodoRecupDesc = rdr.IsDBNull(4) ? (decimal?)null : rdr.GetDecimal(4),
                        InversionInicial = rdr.GetDecimal(5),
                        TasaDescuento_Pct = rdr.GetDecimal(6),
                        HorizonteAnios = rdr.GetInt32(7)
                    };
                }
            }
        }
        public static List<FlujoCajaAnual> ObtenerFlujoCajaPorID(int alternativaID)
        {
            const string sql = @"
        SELECT Anio, FlujoPeriodo
        FROM proy.FlujoCajaAlternativa
        WHERE AlternativaID = @id AND Anio >= 1
        ORDER BY Anio";

            var lista = new List<FlujoCajaAnual>();

            using (var con = new ConexionDB().ObtenerConexion())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", alternativaID);
                using (var rdr = cmd.ExecuteReader())
                    while (rdr.Read())
                        lista.Add(new FlujoCajaAnual
                        {
                            Anio = rdr.GetInt32(0),
                            FlujoPeriodo = rdr.GetDecimal(1)
                        });
            }
            return lista;
        }
    }
}
