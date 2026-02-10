<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="RentalRoom.User.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Roomlbl" runat="server" Text="Select Room"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownRoomList" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Guestslbl" runat="server" Text="Enter no.of Guest (1/2)"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="SelectedGuestTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Durationlbl" runat="server" Text="Duration (1 to 30 above)"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="DurationTxt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="PriceDescriptionlbl" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="GetPricelbl" runat="server" OnClick="GetPricelbl_Click" Text="Get Price" />
        </div>
    </form>
</body>
</html>
