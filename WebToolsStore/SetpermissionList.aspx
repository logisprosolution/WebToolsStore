<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="SetpermissionList.aspx.cs" Inherits="WebToolsStore.SetpermissionList" %>

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
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-header">
                            <h3 class="box-title"></h3>
                        </div>
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="unit_id"
                                    ShowHeaderWhenEmpty="true" OnRowCommand="dgv1_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="รายการ" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='Test'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="รายะเอียด" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="เพิ่ม" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="แก้ไข" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ลบ" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" />
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
