<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/LayoutPopup.Master" AutoEventWireup="true" CodeBehind="PopupDocSelect.aspx.cs" Inherits="WebToolsStore.PopupDocSelect" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript">

        function CloseDialog() {
            var id = $("#<%=hdfValue.ClientID %>").val();
            var returnValue = id;

            if (returnValue == '' || returnValue == null) {
                alert('กรุณาเลือกเอกสาร');
                return false;
            }
            try {
                window.opener.resultDialogPopupDocSelect(returnValue);
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
    <h4 class="box-title">ค้นหาสินค้า</h4>
    <hr />
    <table style="width: 100%; border: 0">
        <tr style="text-align: center">
            <td>
                <label for="">ค้นหา</label>
            </td>
            <td style="width: 225px">
                <asp:TextBox class="form-control" ID="txtSearch" placeholder="เลขที่ใบเอกสาร" runat="server" MaxLength="50" ToolTip="ความยาวไม่เกิน 50 ตัวอักษร" /></td>
            <td>
                <asp:Label runat="server" ID="lblTypeName" Text=""></asp:Label>
            </td>
            <td style="width: 225px">
                <asp:DropDownList ID="ddl_supplier" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
                <asp:DropDownList ID="ddl_customer" runat="server" AutoPostBack="true" class="form-control"></asp:DropDownList>
            </td>
            <td>
                <asp:Label runat="server" ID="lblTypeDate" Text=""></asp:Label>
            </td>
            <td style="width: 225px">
                <div class="input-group date" data-provide="datepicker" data-date-language="th">
                    <asp:TextBox ID="txt_header_date" runat="server" type="text" class="form-control" />
                    <div class="input-group-addon">
                        <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>
            </td>
            <td>
                <asp:LinkButton runat="server" ID="btnSearch" class="btn btn-info" OnClick="brnSearch_Click"> ค้นหา <i class="fa fa-search" aria-hidden="true"></i> </asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <div class="row">
        <div class="col-md-12">
            <div class="box-header">
                <h3 class="box-title">รายการเอกสาร</h3>
            </div>
            <div class="box-body">
                <div id="example_wrapper" class="dataTables_wrapper form-inline" role="grid">
                    <div class="row">
                        <div class="col-xs-6"></div>
                        <div class="col-xs-6"></div>
                    </div>
                    <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                        AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="header_id"
                        ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnSelectedIndexChanged="dgv1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="เลือก" ControlStyle-CssClass="btn btn-success btn-xs btn-circle fa fa-edit" />
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="header_code" HeaderText="เลขที่เอกสาร">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblName" Text=""></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="name" HeaderText="ชื่อ">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="วันที่ทำรายการ" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblheader_date" runat="server" Text='<%#string.Format("{0:d/M/yyyy}",Eval("header_date")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="payment_id1" HeaderText="การชำระเงิน">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="status_name" HeaderText="สถาณะ">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("header_id") %>' />
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
                <h3 class="box-title"></h3>
                <div class="pull-right box-tools">
                    <%--                    <asp:LinkButton CausesValidation="False" runat="server" ID="btnAdd" class="btn btn-primary" OnClick="btnAdd_Click"> เพิ่ม <i class="fa fa-plus" aria-hidden="true"></i></asp:LinkButton>--%>
                </div>
            </div>
            <div class="box-body">
                <div id="example2_wrapper" class="dataTables_wrapper form-inline" role="grid">
                    <div class="row">
                        <div class="col-xs-6"></div>
                        <div class="col-xs-6"></div>
                    </div>
                    <asp:GridView ID="dgv2" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                        AutoGenerateColumns="false" AllowSorting="True" PageSize="50" DataKeyNames="header_id"
                        ShowHeaderWhenEmpty="true" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ">
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
                            <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="unit_name" HeaderText="หน่วย">
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
    <div class="navbar navbar-default navbar-fixed-bottom">
        <div class="box-footer">
            <div class="form-group">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <asp:LinkButton ID="btnSelect" runat="server" class="btn btn-primary" CausesValidation="False" OnClientClick="CloseDialog();">
                    <i class="fa fa-check"></i>เลือก</asp:LinkButton>
                        <button type="button" class="btn btn-default" onclick="CancelDialog();">กลับ</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
