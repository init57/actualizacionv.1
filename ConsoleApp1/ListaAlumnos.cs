using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ListaAlumnos
    {
        public string Codigo { get; set; }
        public string Nombres { get; set; }

        public int edad { get; set; }

        public string correo { get; set; }

        public string[,] notas { get; set; } = new string[2, 3];

        public ListaAlumnos siguiente { get; set; }

    }
}
