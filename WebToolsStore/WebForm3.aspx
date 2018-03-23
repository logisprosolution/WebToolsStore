<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebToolsStore.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
        AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="categories_id"
        ShowHeaderWhenEmpty="true" OnRowDataBound="OnRowDataBound" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt="" style="cursor: pointer" src="images/plus.png" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="dgv2" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ">
                            <Columns>
                                <asp:BoundField ItemStyle-Width="150px" DataField="categories_code" HeaderText="Order Id" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="categories_name" HeaderText="Date" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="150px" DataField="categories_code" HeaderText="Contact Name" />
            <asp:BoundField ItemStyle-Width="150px" DataField="categories_name" HeaderText="City" />
        </Columns>
    </asp:GridView>
</asp:Content>
