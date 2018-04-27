<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/LayoutPopup.Master" AutoEventWireup="true" CodeBehind="PopupProductPriceSelect.aspx.cs" Inherits="WebToolsStore.PopupProductPriceSelect" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript">
        function CloseDialog() {
            debugger
            var num = $("#<%=txtNumber.ClientID %>").val();
            var price = $("#<%=txtPrice.ClientID %>").val();
            var index = $("#<%=ddlprice.ClientID %> option:selected").index();
            if (index == -1) {
                index = 0;
            }
            var returnValue = num + '*' + index + '*' + price + '*' + $("#<%=hdfValue.ClientID %>").val();
            var is_stock = $("#<%=is_stock.ClientID %>").val();
            if (<%= dataId %> != 2) {
                if (returnValue == '' || returnValue == null || index == '0') {
                    alert('กรุณาเลือกราคา');
                    return false;
                }
            }

            try {
                window.opener.resultDialogPopupProductSelect(returnValue);
            }
            catch (err) { }
            window.close();
            return false;
        }
        function CancelDialog() {
            window.close();
            return false;
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdfValue" runat="server" />
    <asp:HiddenField ID="is_stock" runat="server" />
    <h4 class="box-title">ค้นหาสินค้า</h4>
    <hr />
    <div class="box-body">
        <table style="width: 100%; border: 0">
            <tr style="text-align: center">
                <td>
                    <label for="">ค้นหา</label>
                </td>
                <td style="width: 225px">
                    <asp:TextBox class="form-control" ID="txtSearch" placeholder="รหัส/ชื่อ" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" /></td>
                <td>
                    <label for="">หมวดหลัก</label>
                </td>
                <td style="width: 225px">
                    <asp:DropDownList ID="ddlCategoryID" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCategoryID_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <label for="">หมวดย่อย</label>
                </td>
                <td style="width: 225px">
                    <asp:DropDownList ID="ddlSubCategoryID" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                </td>
                <td>
                    <asp:LinkButton runat="server" ID="brnSearch" class="btn btn-info" OnClick="brnSearch_Click"> ค้นหา <i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
                </td>
            </tr>
        </table>
        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="box-header">
                    <h3 class="box-title">รายการสินค้า</h3>
                </div>
                <div class="box-body">
                    <div id="example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-xs-6"></div>
                            <div class="col-xs-6"></div>
                        </div>
                        <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                            AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="product_id"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnSelectedIndexChanged="dgv1_SelectedIndexChanged">
                            <Columns>

                                <asp:CommandField ShowSelectButton="True" SelectText="เลือก" ControlStyle-CssClass="btn btn-success btn-xs btn-circle fa fa-edit" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_code" HeaderText="รหัส">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_name" HeaderText="ชื่อสินค้า">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="categories_name" HeaderText="หมวดสินค้า">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="subcategories_name" HeaderText="ประเภทสินค้า">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("product_id") %>' />
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
                <div class="box-header" runat="server" id="subtitle" style="display: none">
                    <h3 class="box-title">รายการราคาสินค้า</h3>
                    <div class="pull-right box-tools">
                    </div>
                </div>
                <div class="box-body">
                    <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                        <div class="row">
                            <div class="col-xs-6"></div>
                            <div class="col-xs-6"></div>
                        </div>
                        <asp:GridView ID="dgv2" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                            AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="product_price_id"
                            ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnSelectedIndexChanged="dgv2_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" SelectText="เลือก" ControlStyle-CssClass="btn btn-success btn-xs btn-circle fa fa-edit" />
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_code" HeaderText="รหัส">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_name" HeaderText="ชื่อสินค้า">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="unit_name" HeaderText="หน่วยสินค้า">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="cost" HeaderText="ต้นทุน">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_Cash" DataFormatString="{0:n}" HeaderText="ราคาเงินสด">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_Credit" DataFormatString="{0:n}" HeaderText="ราคาเงินเชื่อ">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_CashExtra" DataFormatString="{0:n}" HeaderText="ราคาส่วนลดพิเศษ">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="จำนวน" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStock" runat="server" Text='<%#Eval("stock") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("product_id") %>' />
                                        <asp:HiddenField ID="hdfProduct_price_id" runat="server" Value='<%# Eval("product_price_id") %>' />
                                        <asp:HiddenField ID="hdfPrice" runat="server" Value='<%# Eval("price_Cash") %>' />
                                        <asp:HiddenField ID="hdfUnit" runat="server" Value='<%# Eval("unit_value") %>' />
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
    <%--<div class="navbar-fixed-bottom">--%>
    <%--<footer>--%>
    <%--<div class="">--%>
    <%--<div class="form-group">--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div class="box-footer navbar-fixed-bottom">
                        <asp:LinkButton ID="btnSelect" runat="server" class="btn btn-primary pull-right" CausesValidation="False" OnClientClick="CloseDialog();">
                    <i class="fa fa-check"></i>เลือก</asp:LinkButton>
                        <button type="button" class="btn btn-default pull-left" onclick="CancelDialog();">กลับ</button>
                        <div class="col-sm-1 text-center">
                            <asp:Label Text="ราคา" ID="lblprice" runat="server" />
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList class="form-control" ID="ddlprice" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlprice_SelectedIndexChanged" />
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox class="form-control" ID="txtPrice" ReadOnly="true" Text="0.00" runat="server" />
                        </div>
                        <div class="col-sm-1 text-center">
                            <asp:Label Text="จำนวน" runat="server" />
                        </div>
                        <div class="col-sm-2">
                            <asp:TextBox class="form-control" ID="txtNumber" Text="1" TextMode="Number" MaxLength="50" runat="server" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--</div>--%>
    <%--</div>--%>
    <%--</footer>--%>
    <%--</div>--%>
</asp:Content>
