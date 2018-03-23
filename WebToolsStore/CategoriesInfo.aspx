<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="CategoriesInfo.aspx.cs" Inherits="WebToolsStore.CategoriesInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>หมวดสินค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">หมวดสินค้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="box box-primary">
        <br />
        <%-- <div class="row">
            <div class="box-body">--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">รหัส</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_categories_code" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">ชื่อ <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_categories_name" runat="server" type="text" class="form-control" MaxLength="30" ToolTip="ความยาวไม่เกิน 30 ตัวอักษร" placeholder="ชื่อหมวด" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_categories_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <%--<br><br>--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">ลำดับการจัดเรียง <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_categories_index" runat="server" type="text" class="form-control" TextMode="Number" Text="1" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_categories_index" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                        <asp:RangeValidator Display="Dynamic" runat="server" ControlToValidate="txt_categories_index" ErrorMessage="จำนวนต้องมีค่า 1-10000" MaximumValue="10000" MinimumValue="1" Type="Integer" ForeColor="#CC3300"></asp:RangeValidator>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">สถาณะ <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_is_enabled" runat="server" class="form-control">
                            <asp:ListItem Text="ใช้งาน" Value="True"></asp:ListItem>
                            <asp:ListItem Text="ปิดใช้งาน" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator InitialValue="0" runat="server" ControlToValidate="ddl_is_enabled" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">รายละเอียด</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescription" runat="server" type="text" class="form-control" TextMode="MultiLine" MaxLength="300" ToolTip="ความยาวไม่เกิน 300 ตัวอักษร" />
                    </div>
                </div>
            </div>
        </div>
        <%--   </div>
        </div>--%>
        <hr>
        <div class="row">
            <div class="col-md-12">
                <div class="box-header">
                    <h3 class="box-title"></h3>
                    <div class="pull-right box-tools">
                        <asp:LinkButton runat="server" CausesValidation="False" ID="btnAdd" class="btn btn-primary" OnClick="btnAdd_Click"> เพิ่ม <i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                    </div>
                </div>
                <div class="box-body">
                    <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-xs-6"></div>
                            <div class="col-xs-6"></div>
                        </div>
                        <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                            AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="subcategories_id"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting" OnRowEditing="dgv1_RowEditing">
                            <Columns>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="subcategories_code" HeaderText="รหัส">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="subcategories_name" HeaderText="ชื่อประเภท">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="สถาณะ" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotal" runat="server" Text='<%#string.Format("{0:#,###.##}",Eval("is_enabled")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("subcategories_id") %>' />
                                        <asp:LinkButton CausesValidation="False" ID="btnGridEdit" runat="server" Text="แก้ไข" class="btn btn-warning fa fa-edit" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                        <asp:LinkButton CausesValidation="False" ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
