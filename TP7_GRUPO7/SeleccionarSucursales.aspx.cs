using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP7_GRUPO7


/*En la parte superior del formulario, se podrá escribir sobre el textbox el nombre
completo o parcial de la sucursal que se desee, luego al hacer click sobre el
botón buscar, traerá la sucursal buscada. Si deja el textbox en blanco entonces
se mostrarán todas las sucursales.*/

{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        AccesoDatos ACa = new AccesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "evento_seleccionar")
            {
                //esto es provicional hasta que decidamos como mandarlo al grd o al hacer la clase




                if (Session["Fila"] == null)
                {
                    Session["Fila"] = creartabla();
                }
                
                    string Id = e.CommandArgument.ToString();
                    string Nombre = ACa.Ejecutarcomando("Select NombreSucursal from Sucursal where Id_Sucursal=" + Id, "NombreSucursal");
                    string Descripcion= ACa.Ejecutarcomando("Select DescripcionSucursal from Sucursal where Id_Sucursal="+ Id, "DescripcionSucursal");
                    
                    agregarfila((DataTable)Session["Fila"], Id, Nombre, Descripcion); 
                
                
                
                
            }
        }


        public DataTable creartabla()
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

        protected void btn_NombreSucursal_Click(object sender, EventArgs e)
        {
            ds_Sucursales.SelectCommand = "SELECT[Id_Sucursal], " +
            "[NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal] FROM[Sucursal] WHERE NombreSucursal LIKE '" + 
            txtbx_NombreSucursal.Text + "%'";
        }
    }
}