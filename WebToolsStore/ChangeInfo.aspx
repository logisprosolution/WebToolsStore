<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="ChangeInfo.aspx.cs" Inherits="WebToolsStore.ChangeInfo" %>

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

        function ShowDocDialog() {
            //debugger
            PopupCenter('PopupDocSelect.aspx?dataId=2', 'popup', '1000', '700');
        }
        function resultDialogPopupDocSelect(returnValue) {
            $("#<%=hdfDocValue.ClientID %>").val(returnValue);
            $("#<%=btnAddDocHidden.ClientID %>").click();
        }


    </script>
    <h1>เปลี่ยนสินค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">เปลี่ยนสินค้า </li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdfValue" runat="server" />
    <asp:HiddenField ID="hdfDocValue" runat="server" />
    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" href="#change">เปลี่ยน</a></li>
        <li><a data-toggle="tab" href="#detail">ข้อมูลเพิ่มเติม</a></li>
    </ul>
    <div class="box box-primary">
        <br />
        <div class="tab-content">
            <div id="change" class="tab-pane fade in active">
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-2">
                                <label class="control-label">เลขที่เอกสาร</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_header_code" runat="server" type="text" class="form-control" />
                            </div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    เลขที่เอกกสารอ้างอิง
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <div class="input-group margin" style="margin: 0px;">
                                    <asp:TextBox ID="txt_header_ref" runat="server" type="text" class="form-control" />
                                    <div class="input-group-btn">
                                        <asp:LinkButton runat="server" ID="btnOpenDocPopup" ToolTip="นำเข้าจาก" OnClientClick="javascript:ShowDocDialog(); return false;" class="btn btn-info btn-flat">นำเข้าจาก<i class="fa fa-ellipsis-h" aria-hidden="true" ></i></asp:LinkButton>
                                        <asp:Button ID="btnAddDocHidden" runat="server" type="btnAddDocHidden" CssClass="hidden" OnClick="btnAddDocHidden_Click" CausesValidation="False" />
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_header_ref" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                            ลูกค้า
                                    <label style="color: red">*</label></label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddl_customer" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddl_customer_SelectedIndexChanged" />
                                        <asp:RequiredFieldValidator ID="RequiredCustomer" EnableClientScript="true" InitialValue="0" runat="server" ControlToValidate="ddl_customer" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="control-label">
                                            วันที่เปลี่ยน
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
                                            วันที่จัดส่ง
                                    <label style="color: red">*</label></label>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="input-group date" data-provide="datepicker" data-date-language="th">
                                            <asp:TextBox ID="txt_header_date_to" runat="server" type="text" class="form-control" />
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-th"></span>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_header_date_to" Display="Dynamic" ErrorMessage="กรุณาเลือกวันที่" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                    </div>
                                   <%-- <div class="col-sm-2">
                                        <label class="control-label">
                                            สถานะเอกสาร
                            <label style="color: red">*</label></label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList runat="server" ID="ddl_header_status" class="form-control">
                                            <asp:ListItem Text="อยู่ระหว่างดำเนินการ" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="เสร็จสมบูรณ์" Value="2"></asp:ListItem>
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
                            <h3 class="box-title">ตารางรับคืน</h3>
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
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="used_qty" HeaderText="รับคืนแล้ว">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="detail_price" HeaderText="ราคา" DataFormatString="{0:n}">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="จำนวนเปลี่ยนคืน" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_used_qty_current" TextMode="Number" Text="0" runat="server" type="text" class="form-control" OnTextChanged="txt_used_qty_TextChanged" />
                                                <br />
                                                <asp:RangeValidator Display="Dynamic" runat="server" ControlToValidate="txt_used_qty_current" ErrorMessage="ไม่สามารถเลือกจำนวนมากกว่าคงเหลือได้" MaximumValue='<%# (int)Eval("detail_qty") - (int)Eval("used_qty") %>' MinimumValue="0" Type="Integer" ForeColor="#CC3300"></asp:RangeValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="สถานะการเปลี่ยนสินค้า" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddl_status" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddl_status_SelectedIndexChanged">
                                                    <asp:ListItem Text="ยังไม่เปลี่ยน" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="เปลี่ยนแล้ว" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("header_id") %>' />
                                                <asp:HiddenField ID="hdfPaytype" runat="server" Value='<%# Eval("PaytypeID") %>' />
                                                <asp:LinkButton ID="btnGridDelete" CausesValidation="False" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="DeleteCart" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
                        <div class="box-header">
                            <h3 class="box-title">ตารางเปลี่ยนคืน</h3>
                            <asp:LinkButton runat="server" ID="btnOpenPopup" class="btn btn-primary pull-right" OnClientClick="javascript:ShowDialog(); return false;"> เพิ่ม <i class="fa fa-plus"></i></asp:LinkButton>
                            <asp:Button ID="btnAddHidden" runat="server" type="button" CssClass="hidden" OnClick="btnAddHidden_Click" CausesValidation="False" />
                        </div>
                        <div class="box-body">
                            <div id="example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                                <div class="row">
                                    <div class="col-xs-6"></div>
                                    <div class="col-xs-6"></div>
                                </div>
                                <asp:GridView ID="dgv3" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                                    AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="detail_id,product_price_id"
                                    ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowDataBound="dgv3_RowDataBound" OnRowCommand="dgv3_RowCommand" OnRowDeleting="dgv3_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <img alt="" style="cursor: pointer" src="images/plus.png" />
                                                <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                    <asp:GridView ID="dgv4" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server" DataKeyNames="ingredient_id"
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
                                        <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="detail_price" HeaderText="ราคา" DataFormatString="{0:n}">
                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("header_id") %>' />
                                                <asp:HiddenField ID="hdfPaytype" runat="server" Value='<%# Eval("PaytypeID") %>' />
                                                <asp:LinkButton ID="btnGridDelete" CausesValidation="False" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="DeleteCart" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6">
                                        <asp:Label runat="server" Visible="false" ID="lbl_deposit" Style="color: red"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            รวมทั้งหมด
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_total" runat="server" AutoPostBack="true" type="text" Text="0.00" class="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            ส่วนเพิ่ม
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_added" runat="server" AutoPostBack="true" type="text" Text="0.00" class="form-control" OnTextChanged="txt_added_TextChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            ส่วนลด
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_discout" runat="server" AutoPostBack="true" type="text" Text="0.00" class="form-control" OnTextChanged="txt_discout_TextChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            ภาษีมูลค่าเพิ่ม
                                        </label>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:DropDownList ID="ddl_vat" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddl_vat_SelectedIndexChanged">
                                            <asp:ListItem Text="ไม่มี" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="3%" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="5%" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="7%" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="10%" Value="10"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:TextBox ID="txt_vat" runat="server" type="text" ReadOnly="true" Text="0.00" class="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            ราคาสุทธิ
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_net" runat="server" ReadOnly="true" type="text" Text="0.00" class="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            รับเงิน
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_receive" runat="server" AutoPostBack="true" type="text" Text="0.00" class="form-control" OnTextChanged="txt_receive_TextChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-6"></div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            คืนเงิน
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_refund" runat="server" AutoPostBack="true" type="text" Text="0.00" class="form-control" OnTextChanged="txt_refund_TextChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
