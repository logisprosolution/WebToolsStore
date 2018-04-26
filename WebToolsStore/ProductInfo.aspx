<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="WebToolsStore.ProductInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ShowDialog() {
            //debugger
            PopupCenter('PopupProductSelect.aspx?dataId=<%= dataId %>', 'popup', '1000', '700');
        }
        function resultDialogPopupProductSelect(returnValue) {
            $("#<%=hdfValue.ClientID %>").val(returnValue);
            $("#<%=btnAddHidden.ClientID %>").click();
        }
    </script>
    <h1>สินค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">สินค้า</li>
    </ol>

    <!-- call custom imageBrowser js -->
    <link href="../assets//custom/imageBrowser/imageBrowser.css" rel="stylesheet" type="text/css" />
    <script src="../assets/custom/imageBrowser/imageBrowser.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdfValue" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box box-primary">
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-2">
                                <label class="control-label">
                                    รหัสสินค้า
                            <label style="color: red">*</label>
                                </label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_product_code" runat="server" type="text" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_product_code" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <label class="col-sm-2 control-label">
                                ชื่อ
                        <label style="color: red">*</label></label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_product_name" runat="server" type="text" class="form-control" MaxLength="30" ToolTip="ความยาวไม่เกิน 30 ตัวอักษร" placeholder="ชื่อสินค้า" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_product_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <label class="col-sm-2 control-label">
                                หมวด
                        <label style="color: red">*</label></label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_categories" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddl_categories_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredCategories" InitialValue="0" runat="server" ControlToValidate="ddl_categories" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    ประเภท
                            <label style="color: red">*</label>
                                </label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_subcategories" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddl_subcategories_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredSubcategories" InitialValue="0" runat="server" ControlToValidate="ddl_subcategories" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-2">
                                <label class="control-label">
                                    หน่วยสินค้า
                            <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_unit" runat="server" class="form-control" AutoPostBack="True"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredUnit" EnableClientScript="true" InitialValue="0" runat="server" ControlToValidate="ddl_unit" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    รูปภาพ
                        <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_FileName" runat="server" class="form-control" />
                                <asp:FileUpload ID="imgUpload" runat="server" />
                                <asp:Button ID="btnUpload" runat="server" OnClick="Upload" Style="display: none" />
                                <hr />
                                <asp:Image ID="Image1" Style="width: 200px; height: 200px" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">
                            สถาณะ
                        <label style="color: red">*</label></label>
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
        <ul class="nav nav-tabs">
            <li class="active"><a data-toggle="tab" href="#home">ราคาขาย</a></li>
            <li><a data-toggle="tab" href="#menu1">ส่วนประกอบสินค้า</a></li>
        </ul>
        <div class="tab-content">
            <div id="home" class="tab-pane fade in active">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-header">
                            <h3 class="box-title"></h3>
                            <div class="pull-right box-tools">
                                <asp:LinkButton CausesValidation="False" runat="server" ID="btnAdd" class="btn btn-primary" OnClick="btnAdd_Click"> เพิ่ม <i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>
                            </div>
                        </div>
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="False" AllowSorting="True" PageSize="50" DataKeyNames="product_price_id"
                                    ShowHeaderWhenEmpty="True" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting" OnRowEditing="dgv1_RowEditing">
                                    <Columns>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_code" HeaderText="รหัสสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_name" HeaderText="ชื่อสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="unit_name" HeaderText="ชื่อสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_Cash" DataFormatString="{0:n}" HeaderText="ราคาเงินสด">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_Credit" DataFormatString="{0:n}" HeaderText="ราคาเงินเชื่อ">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_CashExtra" DataFormatString="{0:n}" HeaderText="ราคาบัตรเครดิต">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("product_price_id") %>' />
                                                <asp:LinkButton ID="btnGridEdit" runat="server" Text="แก้ไข" class="btn btn-warning fa fa-edit" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                                                <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
                                                <br />
                                            </ItemTemplate>

                                            <HeaderStyle Width="150px"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle CssClass="selectedRowStyle" BackColor="LightCyan" ForeColor="DarkBlue"
                                        Font-Bold="true" />

                                    <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>

                                    <PagerSettings FirstPageText="Frist Page " LastPageText=" Last Page" Mode="NumericFirstLast"
                                        NextPageText=" Next " PreviousPageText=" Previous " />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="menu1" class="tab-pane fade">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-header">
                            <h3 class="box-title"></h3>
                            <div class="pull-right box-tools">
                                <asp:LinkButton runat="server" ID="btnOpenPopup" class="btn btn-primary pull-right" OnClientClick="javascript:ShowDialog(); return false;"> เพิ่ม <i class="fa fa-plus"></i></asp:LinkButton>
                                <asp:Button ID="btnAddHidden" runat="server" type="button" CssClass="hidden" OnClick="btnAddHidden_Click" CausesValidation="false" />
                            </div>
                        </div>
                        <div class="box-body">
                            <div id="example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgv2" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                            AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="ingredient_id"
                                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv2_RowCommand" OnRowDeleting="dgv2_RowDeleting">
                                            <Columns>
                                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_code" HeaderText="รหัสสินค้า">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_name" HeaderText="ชื่อสินค้า">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_qty" HeaderText="จำนวน">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="unit_name" HeaderText="หน่วยสินค้า">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ค่าตั้งต้น" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="chkDefault" Checked='<%# Eval("is_default") %>' OnCheckedChanged="ChkIsDefault_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("ingredient_id") %>' />
                                                        <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="DeleteCart" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle CssClass="selectedRowStyle" BackColor="LightCyan" ForeColor="DarkBlue"
                                                Font-Bold="true" />
                                            <PagerSettings FirstPageText="Frist Page " LastPageText=" Last Page" Mode="NumericFirstLast"
                                                NextPageText=" Next " PreviousPageText=" Previous " />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
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
