<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="OrderBuyInfo.aspx.cs" Inherits="WebToolsStore.OrderBuyInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ShowDialog() {
            //debugger
            PopupCenter('PopupProductPriceSelect.aspx', 'popup', '1000', '700');
        }

        function resultDialogPopupProductSelect(returnValue) {
            $("#<%=hdfValue.ClientID %>").val(returnValue);
            $("#<%=btnAddHidden.ClientID %>").click();
        }
    </script>
    <h1>สั่งซื้อสินค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">สั่งซื้อสินค้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hdfValue" runat="server" />
    <div class="box box-primary">
        <br />
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">เลขที่บิล</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_header_code" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">
                            วันที่สั่งซื้อ
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
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">
                            บริษัทคู่ค้า
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_supplier" runat="server" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_supplier" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">
                            การชำระเงิน
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList runat="server" ID="ddl_PaymentID" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_PaymentID" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">
                            วันที่ชำระเงิน
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group date" data-provide="datepicker" data-date-language="th">
                            <asp:TextBox ID="txt_PaymentDate" runat="server" type="text" class="form-control" />
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-th"></span>
                            </div>
                        </div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_PaymentDate" Display="Dynamic" ErrorMessage="กรุณาเลือกวันที่" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">
                            ค่ามัดจำ
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_Deposit" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_Deposit" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <hr>
        <div class="row">
            <div class="col-md-12">
                <div class="box-header">
                    <h3 class="box-title"></h3>
                    <asp:LinkButton runat="server" ID="btnOpenPopup" class="btn btn-primary pull-right" OnClientClick="javascript:ShowDialog(); return false;"> เพิ่ม <i class="fa fa-plus"></i></asp:LinkButton>
                    <asp:Button ID="btnAddHidden" runat="server" type="button" CssClass="hidden" OnClick="btnAddHidden_Click" />
                </div>
                <div class="box-body">
                    <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-xs-6"></div>
                            <div class="col-xs-6"></div>
                        </div>
                        <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                            AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="detail_id"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting">
                            <Columns>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_code" HeaderText="รหัสสินค้า">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_name" HeaderText="ชื่อสินค้า">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="detail_qty" HeaderText="จำนวน">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="detail_price" HeaderText="ราคา" DataFormatString="{0:N2}">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("header_id") %>' />
                                        <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="DeleteCart" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">ที่อยู่</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" TextMode="multiline" Columns="50" Rows="3" />
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">หมายเหตุ</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox2" runat="server" type="text" class="form-control" TextMode="multiline" Columns="50" Rows="3" />
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
    </div>
</asp:Content>
