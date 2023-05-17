using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//vincular
using System.Data.SqlClient;//vincular
using DataAccess.Connection;
using Common.Attributes;


namespace DataAccess.Entities
{
    public class PERSONAS
    { //variable
        Connection_DataBase c = new Connection_DataBase();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable td = new DataTable();

        public DataTable Mostar()//retornar un datatable
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Mostar";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                td.Load(dr);
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.ClosedConnection();
            }
            return td;
        }

        public DataTable Buscar(string Buscar)//retornar un datatable
        {
            try
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Buscar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscar", Buscar);
                SqlDataAdapter da = new SqlDataAdapter(cmd);    
                dr = cmd.ExecuteReader();
                td.Load(dr);
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
            }
            finally
            {
                cmd.Connection = c.ClosedConnection();
            }
            return td;
        }
        public void Insertar(AttribuitesPeople obj)
        {
            try

            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Insertar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.ID1);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                cmd.ExecuteNonQuery();//llamar toda la consulta
                cmd.Parameters.Clear();//limpiar consulta para no sobreescribir los parametros
            }
            catch (Exception ex)

            {

            }
            finally

            {
                cmd.Connection = c.ClosedConnection();
            }
        }
        public void Modificar(AttribuitesPeople obj)
        {
            try

            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Modificar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.ID1);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@Sexo", obj.Sexo);
                cmd.ExecuteNonQuery();//llamar toda la consulta
                cmd.Parameters.Clear();//limpiar consulta para no sobreescribir los parametros
            }
            catch (Exception ex)

            {

            }
            finally

            {
                cmd.Connection = c.ClosedConnection();
            }
        }
        public void Eliminar(AttribuitesPeople obj)
            {
            try 
            {
                cmd.Connection = c.OpenConnection();
                cmd.CommandText = "SP_Eliminar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", obj.ID1);
                cmd.ExecuteReader();
                cmd.Parameters.Clear();

            }
            catch (Exception ex) 
            { 
                string msj = ex.ToString();    
            }
            finally 
            {
                cmd.Connection = c.ClosedConnection();
            }

}

}
    }

