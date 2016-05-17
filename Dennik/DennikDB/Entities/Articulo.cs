using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DennikDB.Entities {
    [Table("Inventario")]
    public class Articulo {
        public int ArticuloId { get; set; }
        public ArticuloDesc Art { get; set; }
    }
}
