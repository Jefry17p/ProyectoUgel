using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppP1.Class
{
    public class EquiposCLS
    {
        [Key]
        public int idEquipo { get; set; }
        public string nombreEquipo { get; set; }
        public string tipoEquipo { get; set; }
        public string serieEquipo { get; set; }
        public string marcaEquipo { get; set; }
        public string modeloEquipo { get; set; }
        public string areaEquipo { get; set; }
        public DateTime? fechaAdqui { get; set; }
        public string estadoEquipo { get; set; }
        public DateTime? fechaRegistro { get; set; }
    }
}
