<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/LayoutPopup.Master" AutoEventWireup="true" CodeBehind="PopupProductIngredient.aspx.cs" Inherits="WebToolsStore.PopupProductIngredient" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript">
        function GetCheckedRows() {
            var returnValue = '';
            $("#example_wrapper tr").not(':first').each(function () {
               // debugger
                var $checkBox = $(this).find("input[type='checkbox']");
                var $id = $(this).find("input[type='hidden']").val();

                if ($checkBox.is(':checked')) {
                    returnValue = returnValue + $id + '*' + '1|';
                }
                //else {
                //    returnValue = returnValue + $id + '*' + '0|';
                //}
            });
            try {
                returnValue = returnValue.slice(0, -1);
                window.opener.resultDialogPopupProductIngredient(returnValue);
            }
            catch (err) { }
            window.close();
            return false;
        }
        function CloseDialog() {
            <%--var num = $("#<%=txtNumber.ClientID %>").val();
            var returnValue = num + '*' + $("#<%=hdfValue.ClientID %>").val();

            if (returnValue == '' || returnValue == null) {
                alert('กรุณาเลือกราคา');
                return false;
            }--%>
            try {
                window.opener.resultDialogPopupProductIngredient(returnValue);
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
    <asp:HiddenField ID="hdfValue" runat="server" />
    <h4 class="box-title">ส่วนประกอบรายการสินค้า</h4>
    <hr />
    <%--<div class="form-group">
        <div class="row">
            <div class="col-sm-12">
                <div class="col-sm-1">
                    <label for="">ค้นหา</label>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox class="form-control" ID="txtSearch" placeholder="รหัส/ชื่อ" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" />
                </div>
                <div class="col-sm-2">
                    <label for="">หมวดหลัก</label>
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="ddlCategoryID" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlCategoryID_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-sm-2">
                    <label for="">หมวดย่อย</label>
                </div>
                <div class="col-sm-2">
                    <asp:DropDownList ID="ddlSubCategoryID" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                </div>
                <div class="col-sm-1">
                    <asp:LinkButton runat="server" ID="brnSearch" class="btn btn-info" OnClick="brnSearch_Click"> ค้นหา <i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>--%>
    <%--<table style="width: 100%; border: 0">
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
    <br />--%>
    <div class="row">
        <div class="col-md-12">
            <%--<div class="box-header">
                <h3 class="box-title"></h3>
            </div>--%>
            <div class="box-body">
                <div id="example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                    <div class="row">
                        <div class="col-xs-6"></div>
                        <div class="col-xs-6"></div>
                    </div>
                    <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                        AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="ingredient_id"
                        ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ">
                        <Columns>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_code" HeaderText="รหัสสินค้า">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_name" HeaderText="รายละเอียด">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="unit_name" HeaderText="หน่วยสินค้า">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_qty" HeaderText="จำนวน">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ค่าตั้งต้น" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkDefault" runat="server" Checked='<%# Eval("is_default") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("ingredient_id") %>' />
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
            <div class="col-md-12">
                <asp:LinkButton ID="btnSelect" runat="server" class="btn btn-primary pull-right" CausesValidation="False" OnClientClick="GetCheckedRows();">
                    <i class="fa fa-check"></i>เลือก</asp:LinkButton>
                <button type="button" class="btn btn-default pull-left" onclick="CancelDialog();">กลับ</button>
            </div>
        </div>
    </div>
</asp:Content>
