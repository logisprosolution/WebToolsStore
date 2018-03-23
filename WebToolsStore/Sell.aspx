<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="Sell.aspx.cs" Inherits="WebToolsStore.Sell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>ขายสินค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">ขายสินค้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:Repeater ID="dgv1" runat="server">
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1">
            <tr>
                <th scope="col" style="width: 80px">
                    Customer Id
                </th>
                <th scope="col" style="width: 120px">
                    Customer Name
                </th>
                <th scope="col" style="width: 100px">
                    Country
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Image ID="img" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblContactName" runat="server" Text='<%# Eval("ContactName") %>' />
            </td>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("Country") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
</asp:Content>
