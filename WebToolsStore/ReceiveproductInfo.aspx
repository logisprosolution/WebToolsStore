<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="ReceiveproductInfo.aspx.cs" Inherits="WebToolsStore.ReceiveproductInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ShowDialog() {
            //debugger
            PopupCenter('PopupProductPriceSelect.aspx?dataId=2', 'popup', '1000', '700');
        }
        function resultDialogPopupProductSelect(returnValue) {
            $("#<%=hdfValue.ClientID %>").val(returnValue);
            $("#<%=btnAddHidden.ClientID %>").click();
        }

        <%--        function ShowDocDialog() {
            //debugger
            PopupCenter('PopupDocSelect.aspx?dataId=1', 'popup', '1000', '700');
        }
        function resultDialogPopupDocSelect(returnValue) {
            $("#<%=hdfDocValue.ClientID %>").val(returnValue);
            $("#<%=btnAddDocHidden.ClientID %>").click();
        }--%>

        
    </script>
    <h1>รับเข้าสินค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">รับเข้าสินค้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdfValue" runat="server" />    
    <asp:HiddenField ID="hdfIgdValue" runat="server" />
    <asp:HiddenField ID="hdfDocValue" runat="server" />
    <asp:Button ID="btnAddIgdHidden" runat="server" type="btnAddIgdHidden" CssClass="hidden" OnClick="btnAddIgdHidden_Click" CausesValidation="False" />

    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" href="#receive">รับเข้า</a></li>
        <li><a data-toggle="tab" href="#detail">ข้อมูลเพิ่มเติม</a></li>
    </ul>
    <div class="box box-primary">
        <br />
        <div class="tab-content">
            <div id="receive" class="tab-pane fade in active">
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-2">
                                <label class="control-label">
                                    เลขที่ใบสั่งซื้อ
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_header_code" runat="server" type="text" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_header_code" Display="Dynamic" ErrorMessage="กรุณาเลือกวันที่" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    วันที่รับเข้า
                            <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <div class="input-group date" data-provide="datepicker" data-date-language="th">
                                    <asp:TextBox ID="txt_header_date" runat="server" type="text" class="form-control" />
                                    <div class="input-group-addon">
                                        <span class="glyphicon glyphicon-th"></span>
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_header_date" Display="Dynamic" ErrorMessage="กรุณาเลือกวันที่" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-2">
                                        <label class="control-label">
                                            บริษัทคู่ค้า
                            <label style="color: red">*</label></label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddl_supplier" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddl_supplier_SelectedIndexChanged" />
                                        <asp:RequiredFieldValidator ID="RequiredSupplier" EnableClientScript="true" InitialValue="0" runat="server" ControlToValidate="ddl_supplier" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    </div>
                                    <%--<div class="col-sm-2">
                                        <label class="control-label">สถานะ</label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddl_is_enabled" runat="server" class="form-control">
                                            <asp:ListItem Text="ใช้งาน" Value="True"></asp:ListItem>
                                            <asp:ListItem Text="ปิดใช้งาน" Value="False"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <hr>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box-header">
                            <h3 class="box-title"></h3>
                            <% if ((roleMenu != null ? roleMenu.is_add : false) == true)
                                    { %>
                            <asp:LinkButton runat="server" ID="btnOpenPopup" class="btn btn-primary pull-right" OnClientClick="javascript:ShowDialog(); return false;"> เพิ่ม <i class="fa fa-plus"></i></asp:LinkButton>
                            <% } %>
                            <asp:Button ID="btnAddHidden" runat="server" type="button" CssClass="hidden" CausesValidation="false" OnClick="btnAddHidden_Click" />
                        </div>
                        <div class="box-body">
                            <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="detail_id,product_price_id"
                                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowDataBound="dgv1_RowDataBound" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <img alt="" style="cursor: pointer" src="images/plus.png" />
                                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                    <asp:GridView ID="dgv2" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server" DataKeyNames="ingredient_id"
                                                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ">
                                                        <Columns>
                                                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_code" HeaderText="รหัสสินค้า">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_name" HeaderText="ชื่อสินค้า">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="unit_name" HeaderText="หน่วยสินค้า">
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderStyle-Width="100px" HeaderText="จำนวน" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txt_product_qty" Width="100px" TextMode="Number" CssClass="form-control" runat="server" Text='<%# Eval("product_qty") %>'>
                                                                    </asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_code" HeaderText="รหัสสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_name" HeaderText="ชื่อสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="unit_name" HeaderText="หน่วยสินค้า">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="detail_qty" HeaderText="จำนวน">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <%--<asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="detail_price" HeaderText="ราคาต่อหน่วย" DataFormatString="{0:n}">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="ราคารวม" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# String.Format( "{0:n}" , ((WebToolsStore.Data.DOC_Detail)Container.DataItem).detail_price * ((WebToolsStore.Data.DOC_Detail)Container.DataItem).detail_qty ) %> '>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("header_id") %>' />
                                                <asp:HiddenField ID="hdfPaytype" runat="server" Value='<%# Eval("PaytypeID") %>' />
                                                <asp:LinkButton ID="btnGridEdit" CausesValidation="false" runat="server" ToolTip="รายละเอียดส่วนประกอบสินค้า" Text="" class="btn btn-warning fa fa-cog" Visible="<%# roleMenu != null ? roleMenu.is_delete : false %>" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick='<%# "ShowDetailDialog(\""+Eval("product_id")+"\"); return false;" %>' />
                                                <asp:LinkButton ID="btnGridDelete" CausesValidation="false" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" Visible="<%# roleMenu != null ? roleMenu.is_delete : false %>" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
            <div id="detail" class="tab-pane fade">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-2">
                                        <label class="control-label">ที่อยู่</label>
                                    </div>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txt_header_address" runat="server" type="text" class="form-control" TextMode="multiline" Columns="50" Rows="3" />
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
                                <label class="control-label">หมายเหตุ</label>
                            </div>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txt_remark" runat="server" type="text" class="form-control" TextMode="multiline" Columns="50" Rows="3" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="box-footer" style="text-align: center;">
                        <% if ((roleMenu != null ? roleMenu.is_add : false) == true || (roleMenu != null ? roleMenu.is_edit : false) == true)
                        { %>
                        <asp:Button ID="btnSave" runat="server" Text="บันทึก" type="button" class="btn btn-success" OnClick="btnSave_Click"></asp:Button>
                        <% } %>
                        <asp:Button ID="btnCancel" runat="server" Text="กลับ" type="button" class="btn" OnClick="btnCancel_Click" CausesValidation="False"></asp:Button>
                        <div class="col-sm-offset-1">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                DisplayMode="BulletList" ShowSummary="true" HeaderText="ไม่สามารถบันทึกข้อมูลได้ :" ForeColor="#CC3300" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<%--        <div class="modal fade" id="mymodal" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:LinkButton runat="server" data-dismiss="modal" class="close">&times;</asp:LinkButton>
                        <h4 class="modal-title">ค้นหาสินค้า</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-1">
                                <label for="">ค้นหา</label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox class="form-control" ID="txtSearch" placeholder="รหัส/ชื่อ" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" />
                            </div>
                            <div class="col-md-1">
                                <label for="">หมวด</label>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <label for="">ประเภท</label>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="DropDownList2" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:LinkButton runat="server" ID="brnSearch" class="btn btn-info"> ค้นหา <i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
                            </div>
                            <div class="col-md-1"></div>
                        </div>
                        <br>
                        <div class="box">
                            <div class="box-header">
                                <h3 class="box-title">รายการสินค้า</h3>
                            </div>
                            <div class="box-body">
                                <div id="example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                    <div class="row">
                                        <div class="col-xs-6"></div>
                                        <div class="col-xs-6"></div>
                                    </div>
                                    <asp:GridView ID="GridView1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                        AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames=""
                                        ShowHeaderWhenEmpty="true" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRow" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="" HeaderText="รหัสสินค้า">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="" HeaderText="จำนวน">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="" HeaderText="ราคา">
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:BoundField>
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
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                        <asp:LinkButton runat="server" ID="LinkButton1" class="btn btn-default pull-left" data-dismiss="modal">Close</asp:LinkButton>
                        <button type="button" class="btn btn-primary">เลือก</button>
                        <asp:LinkButton runat="server" ID="LinkButton2" class="btn btn-primary">เลือก</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>--%>
