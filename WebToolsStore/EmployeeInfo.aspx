<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo.aspx.cs" Inherits="WebToolsStore.EmployeeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1>พนักงาน
                <small>ข้อมูล</small>
    </h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">พนักงาน</li>
    </ol>

    <!-- call custom imageBrowser js -->
    <link href="../assets//custom/imageBrowser/imageBrowser.css" rel="stylesheet" type="text/css" />
    <script src="../assets/custom/imageBrowser/imageBrowser.js"></script>

    <script type="text/javascript">
        function UploadFile(fieUpload) {
            if (fieUpload.value != '') {
                document.getElementById("<%=btnUpload.ClientID %>").click();
            }
        }
        //$(function () {
        //    $('#datepicker').datetimepicker({
        //        yearRange:"1994:2000"
        //    });
        //});
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ul class="nav nav-tabs">
        <li class="active"><a data-toggle="tab" href="#home">ประวัติ</a></li>
        <li><a data-toggle="tab" href="#menu1">เข้าใช้งาน</a></li>
    </ul>
    <div class="box box-primary">
        <br />
        <div class="tab-content">
            <%-- <div class="row">
            <div class="box-body">--%>
            <div id="home" class="tab-pane fade in active">
                <div class="form-group" style="display:none">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">รหัสพนักงาน</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_emp_code" runat="server" type="text" class="form-control" />
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
                                    คำนำหน้า
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_title" runat="server" class="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="0" runat="server" ControlToValidate="ddl_title" Display="Dynamic" ErrorMessage="กรุณาเลือกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                    ชื่อ
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_emp_name" runat="server" type="text" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_emp_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                    นามสกุล
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_emp_last" runat="server" type="text" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_emp_last" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                    อายุ
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_emp_age" runat="server" type="text" class="form-control" TextMode="Number" Text="18" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_emp_age" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                <asp:RangeValidator Display="Dynamic" runat="server" ControlToValidate="txt_emp_age" ErrorMessage="จำกัดอายุ 18 ปีขึ้นไป" MaximumValue="100" MinimumValue="18" Type="Integer" ForeColor="#CC3300"></asp:RangeValidator>
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
                                    วัน/เดือน/ปีเกิด
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <div class="input-group date" id="datepicker" data-provide="datepicker" data-date-language="th">
                                    <asp:TextBox ID="txt_emp_birth" runat="server" type="text" class="form-control" />
                                    <div class="input-group-addon">
                                        <span class="glyphicon glyphicon-th"></span>
                                    </div>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_emp_birth" Display="Dynamic" ErrorMessage="กรุณาเลือกวันที่" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                    เลขบัตรประชาชน
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_emp_card" MaxLength="13" runat="server" type="text" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_emp_card" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                    เบอร์โทรศัพท์
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_emp_tel" MaxLength="10" runat="server" class="form-control" />
                                <asp:RegularExpressionValidator ValidationExpression="^[0][8|9][0-9]([0-9]{3})([0-9]{4}$)" runat="server" ControlToValidate="txt_emp_tel" Display="Dynamic" ErrorMessage="เบอร์โทรศัพท์ไม่ถูกต้อง (08|09xxxxxxxx)" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_emp_tel" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                <asp:TextBox ID="txt_emp_email" runat="server" TextMode="Email" class="form-control" />
                                <asp:RegularExpressionValidator ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" ControlToValidate="txt_emp_email" Display="Dynamic" ErrorMessage="E-mail ไม่ถูกต้อง" ForeColor="#CC3300"></asp:RegularExpressionValidator>
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
                                    สถานที่ตั้ง ที่อยู่
                                    <label style="color: red">*</label>
                                </label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_emp_address" runat="server" type="text" class="form-control" TextMode="MultiLine" MaxLength="300" ToolTip="ความยาวไม่เกิน 300 ตัวอักษร" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_emp_address" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                <label class="control-label">
                                    รูปภาพ
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_FileName" runat="server" class="form-control" />
                                <asp:FileUpload ID="imgUpload" runat="server" />
                                <asp:Button ID="btnUpload" runat="server" OnClick="Upload" Style="display: none" />
                                <hr />
                                <asp:Image ID="Image1" Style="width: 200px;height:200px" runat="server" />
                                <%--<div class="input-group image-preview">
                                    <asp:TextBox ID="txt_pic" runat="server" type="text" class="form-control image-preview-filename" ReadOnly="true" />
                                    <span class="input-group-btn">
                                        <button type="button" class="btn btn-default image-preview-clear" style="display: none;">
                                            <span class="glyphicon glyphicon-remove"></span>Clear          
                                        </button>
                                        <div class="btn btn-default image-preview-input">
                                            <span class="glyphicon glyphicon-folder-open"></span>
                                            <span class="image-preview-input-title">Browse</span>
                                            <input type="file" accept="image/png, image/jpeg, image/gif" name="input-file-preview" />
                                        </div>
                                    </span>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_pic" Display="Dynamic" ErrorMessage="กรุณาเลือกรูปภาพ" ForeColor="#CC3300"></asp:RequiredFieldValidator>--%>
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
                                <label class="control-label">หมายเหตุ</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtdescription" runat="server" type="text" class="form-control" TextMode="MultiLine" MaxLength="300" ToolTip="ความยาวไม่เกิน 300 ตัวอักษร" />
                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="menu1" class="tab-pane fade">
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">ชื่อผู้ใช้
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_user_name" runat="server" type="text" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_user_name" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                <label class="control-label">รหัสผ่าน
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_user_password" runat="server" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_user_password" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                <label class="control-label">ชื่อที่แสดง
                                    <label style="color: red">*</label></label>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txt_user_disname" runat="server" type="text" class="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_user_disname" Display="Dynamic" ErrorMessage="กรุณากรอกข้อมูล" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                </div>
                <%--                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">ประเภท</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddl_type" runat="server" class="form-control">
                                    <asp:ListItem Text="ใช้งาน" Value="True"></asp:ListItem>
                                    <asp:ListItem Text="ปิดใช้งาน" Value="False"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3"></div>
                        </div>
                    </div>
                </div>--%>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <label class="control-label">การใช้งาน</label>
                            </div>
                            <div class="col-sm-4">
                                <asp:CheckBox runat="server" ID="is_enabled" />
                            </div>
                            <div class="col-sm-3"></div>
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
    </div>


    <%--     <div>
        <asp:Label ID="lblEmpName" runat="server" Text="Employee Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblImage" runat="server" Text="Employee Image"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:FileUpload ID="imgUpload" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
            Text="Submit" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp       
        <asp:Label ID="lblResult" runat="server" ForeColor="#0066FF"></asp:Label>
        <br />
        <hr />
        <asp:Image ID="Image1" Style="width: 200px" runat="server" />
    </div>--%>
</asp:Content>
