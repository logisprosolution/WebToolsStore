<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="CustomerInfo.aspx.cs" Inherits="WebToolsStore.CustomerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>ลูกค้า
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">ลูกค้า</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="box box-primary">
        <br />
        <%-- <div class="row">
            <div class="box-body">--%>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12"  style="display:none">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">รหัสลูกค้า</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_customer_code" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">ชื่อบริษัท/ชื่อลูกค้า
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_customer_name" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_customer_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">เบอร์โทรศัพท์ 1
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_customer_tel1" runat="server" type="text" class="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_customer_tel1" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">เบอร์โทรศัพท์ 2</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_customer_tel2" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">โทรสาร</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_customer_fax" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">E - mail</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_customer_email" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">สถานที่ตั้ง ที่อยู่
                            <label style="color: red">*</label></label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txt_customer_address" runat="server" type="text" class="form-control" TextMode="MultiLine" MaxLength="300" ToolTip="ความยาวไม่เกิน 300 ตัวอักษร" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_customer_address" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-3"></div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    จังหวัด
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_province" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_province_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredProvince" EnableClientScript="true" InitialValue="0" runat="server" ControlToValidate="ddl_province" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    เขต/อำเภอ
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_distict" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddl_distict_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredDistict" InitialValue="0" runat="server" ControlToValidate="ddl_distict" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    แขวง/ตำบล
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_subdistict" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddl_subdistict_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredSubDistict" InitialValue="0" runat="server" ControlToValidate="ddl_subdistict" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">
                                    รหัสไปรษณีย์
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_zipcode" runat="server" MaxLength="5" ReadOnly="true" class="form-control" />
                                <%-- <asp:RegularExpressionValidator ValidationExpression="(\d{5})?$" runat="server" ControlToValidate="txt_zipcode" Display="Dynamic" ErrorMessage="รหัสไปรษณีย์ ไม่ถูกต้อง" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_zipcode" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-2">
                        <label class="control-label">หมายเหตุ</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtdescription" runat="server" type="text" class="form-control" TextMode="MultiLine" MaxLength="300" ToolTip="ความยาวไม่เกิน 300 ตัวอักษร" />
                    </div>
                    <div class="col-sm-3"></div>
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
