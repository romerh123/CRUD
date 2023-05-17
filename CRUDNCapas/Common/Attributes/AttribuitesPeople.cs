using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attributes
{
    public class AttribuitesPeople
    {
        private int ID;
        private string nombre;
        private string apellido;
        private string sexo;

        public int ID1 { get => ID; set => ID = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Sexo { get => sexo; set => sexo = value; }
    }
}
