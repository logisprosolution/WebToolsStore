<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="RoleUser.aspx.cs" Inherits="WebToolsStore.RoleUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ShowDialog() {
            //debugger
            PopupCenter('PopupUserSelect.aspx', 'popup', '1000', '700');
        }

        function resultDialogPopupUserSelect(returnValue) {
            $("#<%=hdfValue.ClientID %>").val(returnValue);
            $("#<%=btnAddHidden.ClientID %>").click();
        }
    </script>
    <h1>กำหนดสิทธิ์
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">กำหนดสิทธิ์</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdfValue" runat="server" />
    <div class="box box-primary">
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="box-header">
                    <h3 class="box-title"></h3>
                    <div class="pull-right box-tools">
                            <asp:LinkButton runat="server" ID="btnOpenPopup" class="btn btn-primary pull-right" OnClientClick="javascript:ShowDialog(); return false;"> เพิ่ม <i class="fa fa-plus"></i></asp:LinkButton>
                            <asp:Button ID="btnAddHidden" runat="server" type="button" CssClass="hidden" OnClick="btnAddHidden_Click" CausesValidation="False" />
                    </div>
                </div>
                <div class="box-body">
                    <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-xs-6"></div>
                            <div class="col-xs-6"></div>
                        </div>
                        <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="user_id"
                                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeq" runat="server" Text='<%# Container.DataItemIndex +1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="user_name" HeaderText="ชื่อที่แสดง">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("user_id") %>' />
                                                <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');"/>
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
        <div class="row">
            <div class="col-md-12">
                <div class="box-footer" style="text-align: center;">
                    <asp:Button ID="btnSave" runat="server" Text="บันทึก" type="button" class="btn btn-success" OnClick="btnSave_Click"></asp:Button>
                    <asp:Button ID="btnCancel" runat="server" Text="กลับ" type="button" class="btn" OnClick="btnCancel_Click" CausesValidation="False"></asp:Button>
                    <div class="col-sm-offset-1">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            DisplayMode="BulletList" ShowSummary="true" HeaderText="ไม่สามารถบันทึกข้อมูลได้ :" ForeColor="#CC3300" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
