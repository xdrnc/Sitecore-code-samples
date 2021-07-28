<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="checkMedia.aspx.cs" inherits="alexTest"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="media path:" runat="server"></asp:Label>
        <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button5" OnClick="checkMediaCacheFolder_Click" runat="server" Text="Check Media Cache folder" />
        <asp:Button ID="Button3" OnClick="testEndSession_Click" runat="server" Text="End Session" />        
        <br />
        <asp:Label ID="labelOutput" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
