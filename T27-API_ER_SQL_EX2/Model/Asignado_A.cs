using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX2.Model
{
    public class Asignado_A
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public string Cientifico { get; set; }
        public string Proyecto { get; set; }

        public Cientifico Cientificos { get; set; }
        public Proyecto Proyectos { get; set; }
    }
}
