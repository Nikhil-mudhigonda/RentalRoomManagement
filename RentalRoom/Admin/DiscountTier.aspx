<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscountTier.aspx.cs" Inherits="RentalRoom.Admin.DiscountTier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="MinDayslbl" runat="server" Text="Mininum Days"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="MinDaysTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="MaxDayslbl" runat="server" Text="Maximum Days"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="MaxDaysTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="GuestCountlbl" runat="server" Text="GuestCount"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="GuestCountBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="PricePerPersonlbl" runat="server" Text="PricePerPerson"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="PricePerPersonTxt" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="Add" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="UpdateBtn" runat="server" OnClick="UpdateBtn_Click" Text="Update" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" CellPadding="10">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
