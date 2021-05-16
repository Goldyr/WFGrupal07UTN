using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP7_GRUPO7
{
    public class Tabla
    {
        AccesoDatos Ad = new AccesoDatos();

        // Consultas
        private string consultaNombre = "Select NombreSucursal from Sucursal where Id_Sucursal=";
        private string consultaDesc = "Select DescripcionSucursal from Sucursal where Id_Sucursal=";


        private string Id;
        private string Nombre;
        private string Desc;

        public Tabla()
        {
            
            Id = "";
            Nombre = "";
            Desc = "";
        }

        public DataTable crearTabla()
        {
            DataTable dt = new DataTable();
            DataColumn columna = new DataColumn("ID_SUCURSAL", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            columna = new DataColumn("DESCRIPCION", System.Type.GetType("System.String"));
            dt.Columns.Add(columna);

            return dt;
        }

        public void crearFila(CommandEventArgs evento, DataTable TablaSession)
        {
            //Valores
            Id = evento.CommandArgument.ToString();
            Nombre = Ad.Ejecutarcomando(consultaNombre += Id, "NombreSucursal");
            Desc = Ad.Ejecutarcomando(consultaDesc += Id, "DescripcionSucursal");

           agregarfila(TablaSession, Id, Nombre, Desc);
        }

        public void agregarfila(DataTable dt, string Id_sucursal, string Nombre, string Descripcion)
        {

            if (!VerificarSiElProductoYaSeSelecciono(dt, Id_sucursal))   // Si encuentra coincidencias con el id de producto no agrego a la tabla
                                                                         // de seleccion
            {
                DataRow dr = dt.NewRow();
                dr["ID_SUCURSAL"] = Id_sucursal;
                dr["NOMBRE"] = Nombre;
                dr["DESCRIPCION"] = Descripcion;
                dt.Rows.Add(dr);
            }

        }

        protected bool VerificarSiElProductoYaSeSelecciono(DataTable tb, string ID_Sucursal)
        {
            foreach (DataRow dr in tb.Rows)
            {
                if (dr["ID_SUCURSAL"].ToString() == ID_Sucursal) return true;
            }

            return false;
        }
    }
}