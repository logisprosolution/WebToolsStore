﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="ReceiveproductList.aspx.cs" Inherits="WebToolsStore.ReceiveproductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>รับเข้าสินค้า
                <small>รายการ</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">รับเข้าสินค้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <br />
                <%--<div class="box-body">--%>
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
                <div class="col-md-1"></div>
                <%--</div>--%>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-header">
                            <h3 class="box-title">รายการสั่งซื้อสินค้า</h3>
                            <div class="pull-right box-tools">
                                <asp:LinkButton runat="server" ID="btnAdd" class="btn btn-primary" OnClick="btnAdd_Click"> เพิ่ม <i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                        </div>
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="header_id"
                                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting" OnRowEditing="dgv1_RowEditing">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="header_code" HeaderText="รหัสบิลรับเข้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
<%--                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="header_customer_name" HeaderText="รหัสบิลสั่งซื้อ">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>--%>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="user_name" HeaderText="ผู้ทำรายการ">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <%--<asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="vat_id" HeaderText="ประเภทบิล">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="payment_id" HeaderText="ประเภทการจ่ายเงิน">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="วันที่รับเข้า" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblheader_date" runat="server" Text='<%#string.Format("{0:d/M/yyyy}",Eval("header_date")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("header_id") %>' />
                                                <asp:LinkButton ID="btnGridEdit" runat="server" Text="แก้ไข" class="btn btn-warning fa fa-edit" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
