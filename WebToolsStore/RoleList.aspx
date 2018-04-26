<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="WebToolsStore.RoleList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>กำหนดสิทธิ์
                <small>รายการ</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">กำหนดสิทธิ์</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <br />
                <%--<div class="box-body">--%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-2">
                            <label for="">ค้นหา</label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox class="form-control" ID="txtSearch" placeholder="รหัส/ชื่อ" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" />
                        </div>
                        <div class="col-md-1">
                            <asp:LinkButton runat="server" ID="brnSearch" CausesValidation="false" class="btn btn-info" OnClick="brnSearch_Click"> ค้นหา <i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <div class="pull-right box-tools">
                                <label class="control-label">
                                    ชื่อรายการ
                                    <label style="color: red">*</label></label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txt_role_name" runat="server" type="text" class="form-control" MaxLength="30" ToolTip="ความยาวไม่เกิน 30 ตัวอักษร" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_role_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-1">
                            <asp:Button ID="btnSave" runat="server" Text="บันทึก" type="button" class="btn btn-success" OnClick="btnSave_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <%--</div>--%>
                <hr>
                <div class="row">
                    <div class="col-md-12" style="display: none">
                        <div class="form-group">
                            <div class="col-md-2">
                                <div class="pull-right box-tools">
                                    <label class="control-label">รหัสรายการ</label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txt_role_code" runat="server" type="text" class="form-control" />
                            </div>
                            <%--<div class="col-md-2">
                                <div class="pull-right box-tools">
                                    <label class="control-label">
                                        ชื่อรายการ
                                    <label style="color: red">*</label></label>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txt_role_name" runat="server" type="text" class="form-control" MaxLength="30" ToolTip="ความยาวไม่เกิน 30 ตัวอักษร" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_role_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-1">
                                <asp:Button ID="btnSave" runat="server" Text="บันทึก" type="button" class="btn btn-success" OnClick="btnSave_Click"></asp:Button>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="role_id"
                                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting" OnRowEditing="dgv1_RowEditing">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <%--  <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="role_code" HeaderText="รหัสรายการ">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>--%>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="role_name" HeaderText="ชื่อรายการ">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <%--                                            <asp:TemplateField HeaderText="สถาณะ" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%#string.Format("{0:#,###.##}",Eval("is_enabled")) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderStyle-Width="250px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("role_id") %>' />
                                                <asp:LinkButton ID="btnGridUser" CausesValidation="False" runat="server" Text="ผู้ใช้งาน" class="btn btn-warning fa fa-edit" CommandName="User" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                <asp:LinkButton ID="btnGridEdit" CausesValidation="False" runat="server" Text="แก้ไข" class="btn btn-warning fa fa-edit" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                <asp:LinkButton ID="btnGridDelete" CausesValidation="False" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
