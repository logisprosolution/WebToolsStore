<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="ProductPriceInfo.aspx.cs" Inherits="WebToolsStore.ProductPriceInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>เพิ่มรหัสซื้อขายสินค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">สินค้า</li>
        <li class="active">เพิ่มรหัสซื้อขายสินค้า</li>
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
                        <label class="control-label">บาร์โค๊ดสินค้า
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_product_price_code" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_product_price_code" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">ชื่อ
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_product_price_name" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_product_price_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">ต้นทุน
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_cost" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_cost" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">เงินสด
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_price_Cash" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_price_Cash" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">เงินเชื่อ
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_price_Credit" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_price_Credit" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">เงินสดพิเศษ
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_price_CashExtra" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_price_CashExtra" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">หน่วยราคา
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_unit" runat="server" class="form-control" AutoPostBack="True"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredUnit" InitialValue="0" runat="server" ControlToValidate="ddl_unit" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <label class="col-sm-2 control-label">สถาณะ
                        <label style="color: red">*</label></label>
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
                        <label class="control-label">หมายเหตุ</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDescription" runat="server" type="text" class="form-control" TextMode="MultiLine" MaxLength="300" ToolTip="ความยาวไม่เกิน 300 ตัวอักษร" />
                    </div>
                </div>
            </div>
        </div>
        <%--   </div>
        </div>--%>
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
