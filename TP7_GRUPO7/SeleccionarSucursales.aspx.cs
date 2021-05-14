using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TP7_GRUPO7
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    { 
        Tabla TablaSucursales = new Tabla();
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
                    Session["Fila"] = TablaSucursales.crearTabla();
                }
                TablaSucursales.crearFila(e, (DataTable)Session["Fila"]);
            }
        }

        protected void btn_NombreSucursal_Click(object sender, EventArgs e) // Para la busqueda de sucursales
        {
            ds_Sucursales.SelectCommand = "SELECT[Id_Sucursal], " +
            "[NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal] FROM[Sucursal] WHERE NombreSucursal LIKE '" + 
            txtbx_NombreSucursal.Text + "%'";
        }

        protected void dtl_btn_Provincias_Command(object sender, CommandEventArgs e) // Filtrar sucursal por su provincia
        {
            string consulta = "SELECT [Id_Sucursal], [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal] " +
                "FROM [Sucursal] WHERE Id_ProvinciaSucursal = ";

            if (e.CommandName == "sel_provincia_suc")
            {
                ds_Sucursales.SelectCommand = consulta += e.CommandArgument;
            }
        }
    }
}