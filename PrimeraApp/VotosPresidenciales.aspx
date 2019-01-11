<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VotosPresidenciales.aspx.cs" Inherits="PrimeraApp.VotosPresidenciales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            RESULTADO DE LAS ELECCIONES</div>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server">
        </asp:EntityDataSource>

         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Chart ID="chartVoto" runat="server">
                    <Series>
                        <asp:Series ChartType="Pie" Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </ContentTemplate>
        </asp:UpdatePanel>
        PARTIDOS A VOTAR<br />
        <asp:Button ID="cmdPld" runat="server" Text="PLD" OnClick="cmdPld_Click1" />
&nbsp;&nbsp;
        <asp:Button ID="cmdPrd" runat="server" Text="PRD" OnClick="cmdPrd_Click" />
&nbsp;
        <asp:Button ID="cmdPrsc" runat="server" Text="PRSC" OnClick="cmdPrsc_Click" />
        <br />
    </form>
</body>
</html>
