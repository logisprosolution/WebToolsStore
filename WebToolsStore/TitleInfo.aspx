<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="TitleInfo.aspx.cs" Inherits="WebToolsStore.TitleInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>คำนำหน้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">คำนำหน้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="box box-primary">
        <br />
        <%--<div class="row">
            <div class="box-body">--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">รหัส</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_title_code" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="col-sm-2">
                        <label class="control-label">คำนำหน้า <label style="color:red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_title_name" runat="server" type="text" class="form-control" MaxLength="30" ToolTip="ความยาวไม่เกิน 30 ตัวอักษร" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_title_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <%--<br><br>--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label class="control-label">สถาณะ</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddl_is_enabled" runat="server" class="form-control">
                            <asp:ListItem Text="ใช้งาน" Value="True"></asp:ListItem>
                            <asp:ListItem Text="ปิดใช้งาน" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>

        <%-- </div>--%>
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
