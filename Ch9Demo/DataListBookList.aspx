<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataListBookList.aspx.cs" Inherits="Ch9Demo.DataListBookList" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            书名：<asp:TextBox ID="txtSelect" runat="server"></asp:TextBox>
            <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="查询" />
            <asp:Button ID="btnInsert" runat="server" Text="新增图书" OnClick="btnInsert_Click" />
                     <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <hr />
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" PageSize="2"></webdiyer:AspNetPager>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" OnDeleteCommand="DataList1_DeleteCommand" OnEditCommand="DataList1_EditCommand" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <p>图书编号：<%# Eval("bookcode") %><br />书名：<%# Eval("bookname") %><br /><asp:LinkButton ID="lbDetail" runat="server" CommandName="Detail" CommandArgument='<%# Eval("bookcode") %>'>查看</asp:LinkButton>
                        <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit"  CommandArgument='<%# Eval("bookcode") %>'>修改</asp:LinkButton>
                        <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("bookcode") %>' OnClientClick="return confirm('你确定要删除吗?')">删除</asp:LinkButton>
                    </p>          
                </ItemTemplate>
            </asp:DataList>
            <br />
            
        </div>
    </form>
</body>
</html>
