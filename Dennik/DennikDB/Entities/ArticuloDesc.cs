using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DennikDB.Entities {
    public class ArticuloDesc {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public int CodigoProducto { get; set; }
        public bool Bloqueado { get; set; }
    }
}
