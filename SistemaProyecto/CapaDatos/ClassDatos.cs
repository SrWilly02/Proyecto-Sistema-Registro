using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using System.Configuration;

namespace CapaDatos
{
    public class ClassDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_Listar_Clientes()
        {
            SqlCommand cmd = new SqlCommand("ListarClientes", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_Buscar_Clientes(ClassEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("BuscarClientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obje.nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String D_Mantenimiento_Clientes(ClassEntidad obje)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("MantenimientoClientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obje.codigo);
            cmd.Parameters.AddWithValue("@nombre", obje.nombre);
            cmd.Parameters.AddWithValue("@correo", obje.correo);
            cmd.Parameters.AddWithValue("@telefono", obje.telefono);
            cmd.Parameters.AddWithValue("@edad", obje.edad);
            cmd.Parameters.AddWithValue("@DNI", obje.DNI);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }
    }
}
