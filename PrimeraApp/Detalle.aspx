<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="PrimeraApp.Detalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Image ID="imgDetails" runat="server" />
        <br />
        Nombre:
        <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
        <br />
        Size:
        <asp:Label ID="lblSize" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
