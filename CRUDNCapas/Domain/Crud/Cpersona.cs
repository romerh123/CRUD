using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Entities;
using Common.Attributes;

namespace Domain.Crud
{
    public class Cpersona
    {

        PERSONAS persona = new PERSONAS();

        public DataTable Mostar()
        {
            DataTable td = new DataTable();
            td = persona.Mostar();
            return td;
        }
        public DataTable Buscar(string Buscar)
        {
            DataTable td = new DataTable();
            td = persona.Buscar(Buscar);
            return td;
        }
        public void Insertar(AttribuitesPeople obj)
        {
            persona.Insertar(obj);
        }
        public void Modificar(AttribuitesPeople obj)
        {
            persona.Modificar(obj);
        }
        public void Eliminar(AttribuitesPeople obj)
        {
            persona.Eliminar(obj);
        }
    }
}
