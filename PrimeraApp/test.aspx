<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PrimeraApp.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Cedula</div>
        <p>
            <asp:TextBox ID="txtMensaje" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
        </p>
        <p>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Image ID="ImageFoto" runat="server" />
        </p>
    </form>
    <script type="text/javascript" language="javascript">
        function Func() {
            alert("hello!")
        }
</script>

</body>
</html>
