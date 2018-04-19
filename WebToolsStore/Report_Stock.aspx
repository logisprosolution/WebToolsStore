<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="Report_Stock.aspx.cs" Inherits="WebToolsStore.Report_Stock" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1><small></small></h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">รายงานสต็อก</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div class="box box-primary">
        <br />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-2 text-right">
                                <label class="control-label">ค้นหา</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox class="form-control" ID="txtSearch" placeholder="รหัส/ชื่อ" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" /></td>
                            </div>
                            <div class="col-sm-2 text-right">
                                <label class="control-label">คลัง</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlWarehouseID" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-2 text-right">
                                <label class="control-label">หมวดสินค้าหลัก</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlCategoryID" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCategoryID_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-sm-2 text-right">
                                <label class="control-label">หมวดสินค้าย่อย</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlSubCategoryID" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="form-group">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-footer" style="text-align: center;">
                        <asp:Button ID="btnSearch" runat="server" Text="ค้นหารายงาน" type="button" class="btn btn-default" OnClick="btnSearch_Click"></asp:Button>
                        <asp:Button ID="btnPrint" runat="server" Text="ค้นหาและพิมพ์" type="button" class="btn btn-default" OnClick="btnPrint_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="box-body">
                    <div id="example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-xs-6"></div>
                            <div class="col-xs-6"></div>
                        </div>
                        <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                            AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="product_id"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnSelectedIndexChanged="dgv1_SelectedIndexChanged">
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
                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdfUnit" runat="server" Value='<%# Eval("product_unit") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("product_id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="stock" HeaderText="จำนวนคงเหลือ">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True" SelectText="พิมพ์" ControlStyle-CssClass="btn btn-info btn-circle fa fa-print" />
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
    <%--</div>--%>

    <%--</div>--%>
    <%--<div class="col-sm-12">
                <div class="portlet light ">
                    <div class="popover-title">
                        <div class="caption font-dark">
                            <i class="icon-basket font-dark"></i>
                            <span class="caption-subject bold uppercase">รายงาน</span>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                    </div>
                </div>
            </div>--%>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
