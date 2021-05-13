<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursalesSeleccionados.aspx.cs" Inherits="TP7_GRUPO7.ListadoSucursalesSeleccionados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Grupo 7 
            - Matias Flori - Sergio Rivera - Facundo Rivas - Enzo Bogado - Sebastian Buelga</div>
        <div>
        <asp:HyperLink ID="linkListado" runat="server" NavigateUrl="SeleccionarSucursales.aspx">Listado de sucursales</asp:HyperLink>
        <br />
        <asp:HyperLink ID="linkMostrarSeleccionado" runat="server" NavigateUrl="ListadoSucursalesSeleccionados.aspx">Mostrar sucursales seleccionadas</asp:HyperLink>
    </div>

        <asp:GridView ID="grdListado" runat="server">
        </asp:GridView>

    </form>
</body>
</html>
