using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Cita{
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Modulo Modulo { get; set; }
        public Ciudadano Ciudadano { get; set; }
    }
}
