<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="Ch9Demo.BookList"%>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="bookcode" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"  PageSize="2">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="bookcode" HeaderText="图书编号">
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="bookname" HeaderText="书名">
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="type" HeaderText="图书类型">
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="author" HeaderText="作者">
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="translator" HeaderText="译者">
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="pubname" HeaderText="出版社">
                    <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="price" HeaderText="单价">
                    <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="page" HeaderText="页数" />
                    <asp:TemplateField HeaderText="查看">
                        <HeaderTemplate>
                            查看
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("bookcode") %>' CommandName="Detail">查看</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                    <asp:TemplateField HeaderText="删除" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" CommandName="Delete"  OnClientClick="return confir5m('你确定要删除吗?')" Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" PageSize="2"></webdiyer:AspNetPager>
        </div>
    </form>
</body>
</html>
