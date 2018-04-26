<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="SubcategoriesInfo.aspx.cs" Inherits="WebToolsStore.SubcategoriesInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>หมวดย่อย
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">หมวดหลัก</li>
        <li class="active">หมวดย่อย</li>
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
                        <asp:TextBox ID="txt_subcategories_code" runat="server" type="text" class="form-control" placeholder="ตัวอย่าง ABC-1.5" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_subcategories_code" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <label class="col-sm-2 control-label">ชื่อ
                        <label style="color: red">*</label></label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_subcategories_name" runat="server" type="text" class="form-control" MaxLength="30" ToolTip="ความยาวไม่เกิน 30 ตัวอักษร" placeholder="ชื่อประเภท" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_subcategories_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <%--<br><br>--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">ลำดับการจัดเรียง
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_subcategories_index" runat="server" type="text" class="form-control" Text="0" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_subcategories_index" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
