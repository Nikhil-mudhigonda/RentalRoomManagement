<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RentalRoom.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Username" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameBox" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="LoginId" runat="server" OnClick="LoginId_Click" Text="Login" />
        <br />
        <asp:Label ID="ErrorTextlogin" runat="server" Text="ErrorTextLogin"></asp:Label>
    </form>
</body>
</html>
