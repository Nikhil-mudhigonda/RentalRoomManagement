<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="RentalRoom.Admin.Room" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="RoomIbl" runat="server" Text="Room"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="RoomTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="BasePricelbl" runat="server" Text="BasePrice"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="BasePriceTxtBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="isActivelbl" runat="server" Text="isActive"></asp:Label>
        <asp:RadioButtonList ID="isActiveRadioBtn" runat="server" BorderStyle="Solid" CellPadding="5" Height="57px" Width="187px">
            <asp:ListItem Value="1">yes</asp:ListItem>
            <asp:ListItem Value="0">no</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="Add" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="DeleteId" runat="server" OnClick="DeleteId_Click1" Text="Delete" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" Height="239px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="678px">
        </asp:GridView>
        <br />
    </form>
</body>
</html>
