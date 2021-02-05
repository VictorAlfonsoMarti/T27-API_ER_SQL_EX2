using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX2.Model
{
    public class Cientifico
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string DNI { get; set; }
        public string NomApels { get; set; }

        public ICollection<Asignado_A> Asignado_As { get; set; }

        // CONSTRUCTOR
        public Cientifico()
        {
            Asignado_As = new HashSet<Asignado_A>();
        }

    }
}
