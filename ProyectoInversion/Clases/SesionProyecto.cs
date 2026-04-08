using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoInversion.Clases
{
    public static class SesionProyecto
    {
        public static int SimulacionID { get; set; } = -1;
        public static int AltBaseID { get; set; } = -1;

        public static bool TieneProyecto => SimulacionID > 0 && AltBaseID > 0;

        public static void IniciarSesion(int simID, int altBaseID)
        {
            SimulacionID = simID;
            AltBaseID = altBaseID;
        }
    }
}
