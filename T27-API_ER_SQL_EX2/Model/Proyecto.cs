using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX2.Model
{
    public class Proyecto
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int? Horas { get; set; }

        public ICollection<Asignado_A> Asignado_As { get; set; }

        // CONSTRUCTOR
        public Proyecto()
        {
            Asignado_As = new HashSet<Asignado_A>();
        }
    }
}
