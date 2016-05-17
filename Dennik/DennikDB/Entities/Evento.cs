using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DennikDB.Entities {
    [Table("Eventos")]
    public class Evento {        
        public int EventoId { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Cliente { get; set; }
    }
}
