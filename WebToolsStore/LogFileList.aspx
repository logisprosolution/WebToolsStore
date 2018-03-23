<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="LogFileList.aspx.cs" Inherits="WebToolsStore.LogFileList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>การใช้งานระบบ
                <small>รายการ</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">การใช้งานระบบ</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <br />
                <%--<div class="box-body">--%>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-sm-1">
                        <label class="control-label"> วันที่</label>
                    </div>
                    <div class="col-sm-3">
                        <div class="input-group date" data-provide="datepicker" data-date-language="th">
                            <asp:TextBox ID="txt_header_date" runat="server" type="text" class="form-control" />
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-th"></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1">
                        <label for="">ค้นหา</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox class="form-control" ID="txtSearch" placeholder="รหัส/ชื่อ" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" />
                    </div>
                    <div class="col-md-3">
                        <asp:LinkButton runat="server" ID="brnSearch" class="btn btn-info" OnClick="brnSearch_Click"> ค้นหา <i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
                    </div>
                </div>
                <div class="col-md-1"></div>
                <%--</div>--%>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-header">
                            <h3 class="box-title">รายงานการใช้ระบบ</h3>
                        </div>
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="customer_id"
                                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="customer_code" HeaderText="ผู้ใช้งาน">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="customer_name" HeaderText="รายการ">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="customer_code" HeaderText="วันที่">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>                                    </Columns>
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
