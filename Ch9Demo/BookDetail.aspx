<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetail.aspx.cs" Inherits="Ch9Demo.BookDetail"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr><td>图书编号：</td><td>
                    <asp:TextBox ID="txtBookCode" runat="server"></asp:TextBox>
                    </td><td>
                        <asp:Label ID="lblBookCodeRequied" runat="server" ForeColor="Red" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookCode" Display="Dynamic" ErrorMessage="必须输入图书编号！" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="hfBookCode" runat="server" />
                    </td></tr>
                 <tr><td>书名：</td><td>
                     <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
                     </td><td>
                         <asp:Label ID="lblBookNameRequied" runat="server" ForeColor="Red" Text="*"></asp:Label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBookName" Display="Dynamic" ErrorMessage="必须输入书名！" ForeColor="Red"></asp:RequiredFieldValidator>
                     </td></tr>
                 <tr><td>图书类型：</td><td>
                     <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
                     </td><td></td></tr>
                 <tr><td>作者：</td><td>
                     <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
                     </td><td></td></tr>
                 <tr><td>译者：</td><td>
                     <asp:TextBox ID="txtTranslator" runat="server"></asp:TextBox>
                     </td><td></td></tr>
                 <tr><td>出版社：</td><td>
                     <asp:TextBox ID="txtPubName" runat="server"></asp:TextBox>
                     </td><td></td></tr>
                 <tr><td>单价：</td><td>
                     <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                     </td><td>
                         <asp:Label ID="lblPriceRequied" runat="server" ForeColor="Red" Text="*"></asp:Label>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="单价格式不正确！" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="必须输入单价！" ForeColor="Red"></asp:RequiredFieldValidator>
                     </td></tr>
                 <tr><td>页数：</td><td>
                     <asp:TextBox ID="txtPage" runat="server"></asp:TextBox>
                     </td><td>
                         <asp:Label ID="lblPageRequied" runat="server" ForeColor="Red" Text="*"></asp:Label>
                         <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtPage" Display="Dynamic" ErrorMessage="页数格式不正确！" ForeColor="Red" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPage" Display="Dynamic" ErrorMessage="必须输入页数！" ForeColor="Red"></asp:RequiredFieldValidator>
                     </td></tr>
                 <tr><td colspan="3">
                     <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="确定" />
                     <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回" CausesValidation="False" />
                     <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                     </td></tr>             
            </table>
        </div>
    </form>
</body>
</html>
