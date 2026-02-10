<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="RentalRoom.Login.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            <asp:Label ID="Usernamelbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="Username" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Passwordlbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Rolelbl" runat="server" Text="Role"></asp:Label>
            <asp:RadioButtonList ID="RoleButtonList1" runat="server">
                <asp:ListItem>Admin</asp:ListItem>
                <asp:ListItem>User</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:Button ID="SignInBtn" runat="server" OnClick="SignInBtn_Click" Text="SignIn" />
            <asp:Label ID="Label1" runat="server" Text="already signin? please "></asp:Label>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            <asp:Label ID="Label2" runat="server" Text="  here"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Errorlbl" runat="server" Text="ErrorText"></asp:Label>
        </p>
    </form>
</body>
</html>
