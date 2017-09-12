<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeCedacri.aspx.cs" Inherits="WebFormNet4.HomeCedacri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="243px"></asp:ListBox>
            <br />
            <br />
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Height="18px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="166px">
                <asp:ListItem Value="BO">Bologna</asp:ListItem>
                <asp:ListItem Value="MI">Milano</asp:ListItem>
                <asp:ListItem Value="PR">Parma</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
