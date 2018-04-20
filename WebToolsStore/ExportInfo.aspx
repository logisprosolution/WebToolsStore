<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="ExportInfo.aspx.cs" Inherits="WebToolsStore.ExportInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ShowDialog() {
            //debugger
            PopupCenter('PopupProductPriceSelect.aspx?dataId=11', 'popup', '1000', '700');
        }

        function resultDialogPopupProductSelect(returnValue) {
            $("#<%=hdfValue.ClientID %>").val(returnValue);
            $("#<%=btnAddHidden.ClientID %>").click();
        }
        function makeMoney(e, source) {
            //debugger
            if (e.keyCode === 13) {
                e.preventDefault(); // Ensure it is only this code that rusn
                var money = parseFloat(source.value, 10).toFixed(2);
                //Format your value
                source.value = money.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
            }
        }
        <%--  function GetCheckedRows(id) {
            var returnValue = '';

            debugger
            var grid = $("#main_dgv1 tr").find("span[name='" + id + "']");
            var $checkBox = grid.find("input[type='checkbox']").eq(0);
            //var $id = grid.parent().next().eq(0).find("input[type='hidden']").val();

            if ($checkBox.is(':checked')) {
                $checkBox = true;
            }
            else {
                $checkBox = false;
            }
            $("#hdfIngID").val(id);
            $("#hdfChk").val($checkBox);

            <% 
                int id = hdfIngID.Value != "" ? Convert.ToInt16(hdfIngID.Value) : 0;
                bool check = hdfChk.Value != "" ? Convert.ToBoolean(hdfChk.Value) : false;
                if (IngredientList_Show.Find(x => x.ingredient_id == id) != null)
                {
                    IngredientList_Save.Find(x => x.ingredient_id == id).is_enabled = check;
                }
            %>
        }--%>

    </script>
    <h1>นำออก
               
        <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">นำออก</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdfValue" runat="server" />
    <asp:HiddenField ID="hdfChk" runat="server" />
    <asp:HiddenField ID="hdfIngID" runat="server" />
    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" href="#order">สั่งทำ</a></li>
        <li><a data-toggle="tab" href="#detail">ข้อมูลเพิ่มเติม</a></li>
    </ul>
    <div class="box box-primary">
        <br />
        <div class="tab-content">
            <div id="order" class="tab-pane fade in active">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
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
                                            วันที่นำออก
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
                    </ContentTemplate>
                </asp:UpdatePanel>
                <hr>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="box-header">
                                    <h3 class="box-title"></h3>
                                    <asp:LinkButton runat="server" CausesValidation="false" ID="btnOpenPopup" class="btn btn-primary pull-right" OnClientClick="javascript:ShowDialog(); return false;"> เพิ่ม <i class="fa fa-plus"></i></asp:LinkButton>
                                    <asp:Button ID="btnAddHidden" runat="server" type="button" CssClass="hidden" OnClick="btnAddHidden_Click" CausesValidation="false" UseSubmitBehavior="false" />
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
                                                <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="detail_price" HeaderText="ราคาต่อหน่วย" DataFormatString="{0:n}">
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="ราคารวม" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPrice" runat="server" Text='<%# String.Format( "{0:n}" , ((WebToolsStore.Data.DOC_Detail)Container.DataItem).detail_price * ((WebToolsStore.Data.DOC_Detail)Container.DataItem).detail_qty ) %> '>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("header_id") %>' />
                                                        <asp:HiddenField ID="hdfPaytype" runat="server" Value='<%# Eval("PaytypeID") %>' />
                                                        <asp:LinkButton Visible="false" ID="btnGridEdit" runat="server" ToolTip="รายละเอียดส่วนประกอบสินค้า" Text="" class="btn btn-warning fa fa-cog" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick='<%# "ShowDetailDialog(\""+Eval("product_id")+"\"); return false;" %>' />
                                                        <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="DeleteCart" CausesValidation="False" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
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
                                    <div class="col-sm-6">
                                        <asp:Label runat="server" Visible="false" ID="lbl_deposit" Style="color: red"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="control-label pull-right">
                                            รวมทั้งหมด
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_total" runat="server" AutoPostBack="true" type="text" Text="0.00" class="form-control" onblur='makeMoney(this);' />
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
                                            ส่วนเพิ่ม
                                        </label>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="txt_added" runat="server" AutoPostBack="true" type="text" Text="0.00" class="form-control" onkeypress='makeMoney(event,this);' OnTextChanged="txt_added_TextChanged" />
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
                                        <asp:TextBox ID="txt_net" ReadOnly="true" runat="server" type="text" Text="0.00" class="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group" runat="server" visible="false">
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="detail" class="tab-pane fade">
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
                        <asp:Button ID="btnSave" runat="server" Text="บันทึก" type="button" class="btn btn-success" OnClick="btnSave_Click" UseSubmitBehavior="false"></asp:Button>
                        <asp:Button ID="btnCancel" runat="server" Text="กลับ" type="button" class="btn" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="false"></asp:Button>
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
