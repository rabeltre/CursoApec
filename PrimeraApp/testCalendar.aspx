<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testCalendar.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="PrimeraApp.testCalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblCantidad" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Calendar ID="calCita" runat="server"></asp:Calendar>
        <br />
        <asp:CheckBox ID="cboAceptar" runat="server" OnCheckedChanged="cboAceptar_CheckedChanged" Text="Confirmar Asistencia" />
        <br />
        <asp:CheckBoxList ID="cblLista" runat="server">
            <asp:ListItem>Yuca</asp:ListItem>
            <asp:ListItem>Platano</asp:ListItem>
            <asp:ListItem>Batata</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <asp:DropDownList ID="ddlCuenta" runat="server">
            <asp:ListItem>802415596</asp:ListItem>
            <asp:ListItem>809589625</asp:ListItem>
            <asp:ListItem>801823614</asp:ListItem>
        </asp:DropDownList>
        <br />
        Nombre de la imagen:
        <asp:TextBox ID="txtNombreImagen" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:FileUpload ID="fuImagen" runat="server" style="margin-bottom: 4px" AllowMultiple="True" />
        <asp:Button ID="btnGuardarImage" runat="server" OnClick="btnGuardarImage_Click" Text="Postear" />
        <p>
            <asp:Button ID="btnCalendario" runat="server" OnClick="btnCalendario_Click" Text="Aceptar" />
        &nbsp;&nbsp;&nbsp;
        </p>
        <p>
            <asp:Label ID="lblFecha" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <asp:DataList ID="dliImages" runat="server" RepeatColumns="3" CellPadding="12">
            <ItemTemplate>
                <br />
               &nbsp;<asp:Image ID="imgImagenCargada" runat="server" Height="153px" ImageUrl='<%# Eval("Imagen", "/Images/{0}") %>' Width="171px" /><br />
                <strong>Nombre: </strong>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Imagen", "/Detalle.aspx?Nombre={0}&ruta=") +Eval("Imagen") %>' Text='<%# Eval("Detalle") %>'></asp:HyperLink>
                <br />
                <strong>Like:</strong>
                <asp:Label ID="lblSize" runat="server" Text='<%# Eval("Likes") %>'></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Button ID="btnLike" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnLike_Click" Text="Likes" />
                <br />
                <br />
                <asp:Button ID="btnDislike" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="btnDislike_Click" Text="Dislike" />
                <br />
            

            </ItemTemplate>
 
        </asp:DataList>
    </form>

</body>
</html>
