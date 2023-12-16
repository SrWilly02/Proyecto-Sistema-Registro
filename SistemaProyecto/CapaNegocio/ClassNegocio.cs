using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_Listar_Clientes()
        {
            return objd.D_Listar_Clientes();
        }

        public DataTable N_Buscar_Clientes(ClassEntidad obje)
        {
            return objd.D_Buscar_Clientes(obje);
        }

        public String N_Mantenimiento_Clientes(ClassEntidad obje)
        {
            return objd.D_Mantenimiento_Clientes(obje);
        }
    }
}
