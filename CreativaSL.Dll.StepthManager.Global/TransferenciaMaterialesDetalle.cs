using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Global
{
    public class TransferenciaMaterialesDetalle
    {
        public TransferenciaMaterialesDetalle()
        {
            this.FechaInicio = DateTime.MinValue;
            this.Producto = string.Empty;
            this.Clave = string.Empty;
            this.CantidadMetrica = 0;
            this.TipoMetrica = string.Empty;
            this.CantidadUsos = 0;
            this.Consumo = 0;
            this.DiasTranscurridos = 0;
        }
        /// <summary>
        /// Fecha inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Producto { get; set; }

        /// <summary>
        /// Clave del producto
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Cantidad metrica
        /// </summary>
        public int CantidadMetrica { get; set; }

        /// <summary>
        /// Tipo de metrica
        /// </summary>
        public string TipoMetrica { get; set; }

        /// <summary>
        /// Cantidad de uso
        /// </summary>
        public int CantidadUsos { get; set; }

        /// <summary>
        /// Consumo
        /// </summary>
        public int Consumo { get; set; }

        /// <summary>
        /// Dias transcurridos desde la fecha inicio hasta la actualidad
        /// </summary>
        public int DiasTranscurridos { get; set; }
    }
}
