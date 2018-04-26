<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="WebToolsStore.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>สินค้า
                <small>รายการ</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">สินค้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <br />
                <% if ((roleMenu != null ? roleMenu.is_search : false) == true)
                    { %>
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-1">
                        <label for="">ค้นหา</label>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="txtSearch" placeholder="รหัส/ชื่อ" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" />
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton runat="server" ID="brnSearch" class="btn btn-info" OnClick="brnSearch_Click"> ค้นหา <i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
                    </div>
                </div>
                <% } %>
                <div class="col-md-1"></div>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-header">
                            <h3 class="box-title">รายการหมวดสินค้า</h3>
                            <div class="pull-right box-tools">
                                <% if ((roleMenu != null ? roleMenu.is_add : false) == true)
                                    { %>
                                <asp:LinkButton runat="server" ID="btnAdd" class="btn btn-primary" OnClick="btnAdd_Click"> เพิ่ม <i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                                <% } %>
                            </div>
                        </div>
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="product_id"
                                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting" OnRowEditing="dgv1_RowEditing">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_code" HeaderText="รหัส">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_name" HeaderText="ชื่อสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="categories_name" HeaderText="หมวดสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="subcategories_name" HeaderText="ประเภทสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="สถาณะ" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%#string.Format("{0:#,###.##}",Eval("is_enabled")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("product_id") %>' />
                                                <asp:LinkButton ID="btnGridView" runat="server" Text="ดู" class="btn btn-info fa fa-eye"  Visible="<%# roleMenu != null ? roleMenu.is_view : false %>" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                <asp:LinkButton ID="btnGridEdit" runat="server" Text="แก้ไข" class="btn btn-warning fa fa-edit"  Visible="<%# roleMenu != null ? roleMenu.is_edit : false %>" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" Visible="<%# roleMenu != null ? roleMenu.is_delete : false %>" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle CssClass="selectedRowStyle" BackColor="LightCyan" ForeColor="DarkBlue"
                                        Font-Bold="true" />
                                    <PagerSettings FirstPageText="Frist Page " LastPageText=" Last Page" Mode="NumericFirstLast"
                                        NextPageText=" Next " PreviousPageText=" Previous " />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
